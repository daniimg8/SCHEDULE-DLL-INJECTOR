using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace MyDLLInjector
{
    public partial class Form1 : Form
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr OpenProcess(uint processAccess, bool bInheritHandle, int dwProcessId);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr VirtualAllocEx(IntPtr hProcess, IntPtr lpAddress, uint dwSize, uint flAllocationType, uint flProtect);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, uint nSize, out IntPtr lpNumberOfBytesWritten);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr GetProcAddress(IntPtr hModule, string lpProcName);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr CreateRemoteThread(IntPtr hProcess, IntPtr lpThreadAttributes, uint dwStackSize, IntPtr lpStartAddress, IntPtr lpParameter, uint dwCreationFlags, IntPtr lpThreadId);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool CloseHandle(IntPtr hObject);

        private const uint PROCESS_ALL_ACCESS = 0x001F0FFF;
        private const uint MEM_COMMIT = 0x00001000;
        private const uint MEM_RESERVE = 0x00002000;
        private const uint PAGE_READWRITE = 0x04;

        public Form1()
        {
            InitializeComponent();
            LoadProcesses();
        }

        private void LoadProcesses()
        {
            comboBoxProcesos.Items.Clear();
            Process[] processes = Process.GetProcesses();
            Array.Sort(processes, (p1, p2) => string.Compare(p1.ProcessName, p2.ProcessName, StringComparison.OrdinalIgnoreCase));

            foreach (Process p in processes)
            {
                if (p.Id != 0) // Evitar el proceso Idle
                {
                    string windowTitle = string.IsNullOrEmpty(p.MainWindowTitle) ? "" : $" - [{p.MainWindowTitle}]";
                    comboBoxProcesos.Items.Add($"{p.ProcessName}.exe (PID: {p.Id}){windowTitle}");
                }
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e) => LoadProcesses();

        private void btnExaminar_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "DLL Files (*.dll)|*.dll";
                ofd.Title = "Select DLL to Inject";
                if (ofd.ShowDialog() == DialogResult.OK) txtRutaDLL.Text = ofd.FileName;
            }
        }

        private void btnInyectar_Click(object sender, EventArgs e)
        {
            if (comboBoxProcesos.SelectedItem == null || string.IsNullOrEmpty(txtRutaDLL.Text) || !File.Exists(txtRutaDLL.Text))
            {
                MessageBox.Show("Please select a valid target process and DLL payload.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try 
            {
                string selection = comboBoxProcesos.SelectedItem.ToString()!;
                int indexPID = selection.IndexOf("(PID: ") + 6;
                int pid = int.Parse(selection.Substring(indexPID, selection.IndexOf(')', indexPID) - indexPID));

                IntPtr hProcess = OpenProcess(PROCESS_ALL_ACCESS, false, pid);
                if (hProcess == IntPtr.Zero) 
                {
                    MessageBox.Show("Failed to open target process. Make sure to run this injector as Administrator.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                byte[] bufferPath = Encoding.ASCII.GetBytes(txtRutaDLL.Text + "\0");
                IntPtr dirMemory = VirtualAllocEx(hProcess, IntPtr.Zero, (uint)bufferPath.Length, MEM_COMMIT | MEM_RESERVE, PAGE_READWRITE);
                
                if (dirMemory != IntPtr.Zero && WriteProcessMemory(hProcess, dirMemory, bufferPath, (uint)bufferPath.Length, out _))
                {
                    IntPtr dirLoadLibrary = GetProcAddress(GetModuleHandle("kernel32.dll"), "LoadLibraryA");
                    IntPtr hThread = CreateRemoteThread(hProcess, IntPtr.Zero, 0, dirLoadLibrary, dirMemory, 0, IntPtr.Zero);
                    if (hThread != IntPtr.Zero)
                    {
                        MessageBox.Show($"Successfully injected into PID: {pid}", "Injection Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CloseHandle(hThread);
                    }
                    else 
                    {
                        MessageBox.Show("Failed to create remote thread. Architecture mismatch (x86/x64)?", "Injection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else 
                {
                    MessageBox.Show("Failed to allocate or write memory in the target process.", "Memory Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                CloseHandle(hProcess);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
