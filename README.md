💉 Pro DLL Injector (x86 Edition)

A lightweight, high-performance, and standalone 32-bit (x86) DLL Injector built with C# and .NET 8. This tool utilizes the standard Win32 API (CreateRemoteThread + LoadLibraryA) to seamlessly map and execute custom payloads inside target processes.

Perfect for reverse engineering, offline modding of classic 32-bit games, and educational memory management projects.

✨ Features

Standalone Executable: Compiled as a single .exe file. No need to install the .NET Runtime on the target machine.

Modern Dark UI: A sleek, responsive, and professional user interface.

Smart Process Scanner: Automatically filters out system idle processes and displays clear window titles alongside their PIDs.

Robust Error Handling: Built-in privilege checks, architecture mismatch detection, and memory allocation validation to prevent silent crashes.

📸 Screenshot

<img width="483" height="286" alt="image" src="https://github.com/user-attachments/assets/c017295e-3fc5-424c-ae21-901cebb812ec" />


🚀 How to Use

Go to the Releases page and download the latest MyDLLInjector.exe.

Run the injector as Administrator (Crucial: Windows requires elevated privileges to access other processes' memory).

Select your target 32-bit process from the dropdown list.

Click Browse... and select your .dll payload.

Click INJECT DLL.

A success message will appear if the injection is completed successfully.

🛠️ Building from Source

If you prefer to compile the tool yourself, follow these steps:

Clone this repository:

git clone [https://github.com/YourUsername/YourRepository.git](https://github.com/YourUsername/YourRepository.git)


Navigate to the project directory:

cd YourRepository/MyDLLInjector


Publish the project as a standalone single file:

dotnet publish -c Release -r win-x86 --self-contained true -p:PublishSingleFile=true -p:IncludeNativeLibrariesForSelfExtract=true


The compiled executable will be located in: \bin\Release\net8.0-windows\win-x86\publish\

⚠️ Disclaimer

Educational Purposes Only.
This software is provided for educational purposes, security research, and offline modding of legally owned software.
Do NOT use this tool on modern multiplayer games protected by Kernel-level Anti-Cheat systems (e.g., Vanguard, EasyAntiCheat, BattlEye). Doing so will violate Terms of Service and result in permanent account bans. The author assumes no responsibility for any misuse of this tool.

📄 License

This project is licensed under the MIT License - see the LICENSE file for details.
