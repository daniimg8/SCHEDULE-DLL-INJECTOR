namespace MyDLLInjector
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitulo, lblProceso, lblDLL;
        private System.Windows.Forms.ComboBox comboBoxProcesos;
        private System.Windows.Forms.Button btnActualizar, btnExaminar, btnInyectar;
        private System.Windows.Forms.TextBox txtRutaDLL;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblProceso = new System.Windows.Forms.Label();
            this.lblDLL = new System.Windows.Forms.Label();
            this.comboBoxProcesos = new System.Windows.Forms.ComboBox();
            this.txtRutaDLL = new System.Windows.Forms.TextBox();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnExaminar = new System.Windows.Forms.Button();
            this.btnInyectar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            
            // lblTitulo
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(139, 92, 246); 
            this.lblTitulo.Location = new System.Drawing.Point(20, 15);
            this.lblTitulo.Text = "SCHEDULE DLL INJECTOR";

            // lblProceso
            this.lblProceso.AutoSize = true;
            this.lblProceso.ForeColor = System.Drawing.Color.LightGray;
            this.lblProceso.Location = new System.Drawing.Point(22, 60);
            this.lblProceso.Text = "TARGET PROCESS:";
            this.lblProceso.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);

            // comboBoxProcesos
            this.comboBoxProcesos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxProcesos.Location = new System.Drawing.Point(25, 80);
            this.comboBoxProcesos.Size = new System.Drawing.Size(340, 23);
            this.comboBoxProcesos.BackColor = System.Drawing.Color.FromArgb(40, 40, 45);
            this.comboBoxProcesos.ForeColor = System.Drawing.Color.White;
            this.comboBoxProcesos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;

            // btnActualizar
            this.btnActualizar.Location = new System.Drawing.Point(375, 80);
            this.btnActualizar.Size = new System.Drawing.Size(85, 23);
            this.btnActualizar.Text = "Refresh";
            this.btnActualizar.BackColor = System.Drawing.Color.FromArgb(60, 60, 65);
            this.btnActualizar.ForeColor = System.Drawing.Color.White;
            this.btnActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizar.FlatAppearance.BorderSize = 0;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);

            // lblDLL
            this.lblDLL.AutoSize = true;
            this.lblDLL.ForeColor = System.Drawing.Color.LightGray;
            this.lblDLL.Location = new System.Drawing.Point(22, 120);
            this.lblDLL.Text = "PAYLOAD (DLL PATH):";
            this.lblDLL.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);

            // txtRutaDLL
            this.txtRutaDLL.ReadOnly = true;
            this.txtRutaDLL.Location = new System.Drawing.Point(25, 140);
            this.txtRutaDLL.Size = new System.Drawing.Size(340, 23);
            this.txtRutaDLL.BackColor = System.Drawing.Color.FromArgb(40, 40, 45);
            this.txtRutaDLL.ForeColor = System.Drawing.Color.White;
            this.txtRutaDLL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            // btnExaminar
            this.btnExaminar.Location = new System.Drawing.Point(375, 140);
            this.btnExaminar.Size = new System.Drawing.Size(85, 23);
            this.btnExaminar.Text = "Browse...";
            this.btnExaminar.BackColor = System.Drawing.Color.FromArgb(60, 60, 65);
            this.btnExaminar.ForeColor = System.Drawing.Color.White;
            this.btnExaminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExaminar.FlatAppearance.BorderSize = 0;
            this.btnExaminar.Click += new System.EventHandler(this.btnExaminar_Click);

            // btnInyectar
            this.btnInyectar.BackColor = System.Drawing.Color.FromArgb(16, 185, 129);
            this.btnInyectar.ForeColor = System.Drawing.Color.White;
            this.btnInyectar.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnInyectar.Location = new System.Drawing.Point(25, 190);
            this.btnInyectar.Size = new System.Drawing.Size(435, 45);
            this.btnInyectar.Text = "INJECT DLL";
            this.btnInyectar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInyectar.FlatAppearance.BorderSize = 0;
            this.btnInyectar.Click += new System.EventHandler(this.btnInyectar_Click);

            // Form1
            this.BackColor = System.Drawing.Color.FromArgb(24, 24, 28); 
            this.ClientSize = new System.Drawing.Size(484, 261);
            this.Controls.Add(this.btnInyectar);
            this.Controls.Add(this.btnExaminar);
            this.Controls.Add(this.txtRutaDLL);
            this.Controls.Add(this.lblDLL);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.comboBoxProcesos);
            this.Controls.Add(this.lblProceso);
            this.Controls.Add(this.lblTitulo);
            this.Text = "Schedule DLL Injector - x64 Architecture";
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}