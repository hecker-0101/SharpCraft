# 📜 README.md — SharpCraft v1.4.1

# ⚒️ SharpCraft  
**The MinGW‑Style Forge of C#**

**⚒️ Version 1.4.1 — Made by Sam M.**  
*The MinGW‑Style Forge of C# (Framework IL)*

---

## 🌋 What is SharpCraft?

SharpCraft is a command‑line C# compiler, built with paranoia and branding, designed to feel like GCC/MinGW, instead of relying on heavy Visual Studio projects.

It compiles your `.cs` files into `.exe` programs with one simple command:

```bash
sharpcraft file.cs -o program.exe
```

Because C# deserves a MinGW‑style toolchain.

---

## ✨ Features

- ✅ ASCII Logo + branding every time you run SharpCraft ⚡  
- ✅ Compile any `.cs` → `.exe` directly from the command line  
- ✅ Works globally once installed (PATH auto‑setup)  
- ✅ Outputs `.exe` + `.runtimeconfig.json` (the .NET manifest)  
- ⚠️ Produces Framework‑dependent IL executables  
  - Requires .NET Runtime (the `.runtimeconfig.json` tells .NET what runtime to use)  
- ❌ NativeAOT not bundled (too heavy dependencies, explained in roadmap)

---

## 🛠️ Installation

### Windows
1. Go to **Releases**.
2. Download `SharpCraftInstaller.exe`.
3. Run the installer → it adds `sharpcraft` to your PATH.

---

## 🚀 Usage

Example with our demo `hello.cs`:

```csharp
using System;

class Hello {
    static void Main() {
        Console.WriteLine("Hello from SharpCraft!");
    }
}
```

Compile with SharpCraft (from anywhere):

```powershell
sharpcraft hello.cs -o hello.exe
```

**Output:**
```
✅ Build succeeded: hello.exe
📝 Runtime config generated: hello.runtimeconfig.json

⚠️ Note: This is a .NET IL executable.
▶ Run it like this to be safe:
   dotnet hello.exe
```

Run:

```powershell
dotnet hello.exe
```

**Result:**
```
Hello from SharpCraft!
```

---

## 📦 What gets generated

Each compilation produces:

- `program.exe` → IL executable  
- `program.runtimeconfig.json` → runtime specification  

⚠️ **Both files must be together** (`.exe` + `.runtimeconfig.json`) for the program to run.  
*(Just like GCC produces `a.out` + needs glibc, SharpCraft programs need .NET runtime.)*

---

## 📋 Roadmap

### v1.4.1
- ✅ IL executable forging (`.exe` + `.runtimeconfig.json`)  
- ✅ Installable compiler with PATH integration  
- ✅ Sexy ASCII branding  

### v2.0 (future)
- Optional NativeAOT integration (true standalone `.exe`) once the MSVC/Installer headaches are resolved  
- Multi‑file support: `sharpcraft main.cs utils.cs -o app.exe`  
- NuGet integration: `sharpcraft add Newtonsoft.Json`  
- `--autorun` flag (auto run compiled exe GCC‑style)  

---

## ⚠️ Limitations

- SharpCraft compiles to IL managed executables, not fully native.  
- Executables require .NET Runtime installed on host (net9.0 currently).  
- This is intentional: avoiding the 50+ GB Visual Studio/MSVC dependency nightmare.  
- Standalone native executables will come later in v2 with NativeAOT.

---

## ❤️ Credits

- Built on **Roslyn**.  
- Inspired by **GCC & MinGW**.  
- Made by **Sam M.**, 2025.

---

> ⚒️ *“Forging C# programs like swords, one .exe at a time.”*


