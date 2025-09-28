using System;
using System.IO;
using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Emit;

class SharpCraft
{
    static int Main(string[] args)
    {
        // -------------------------------
        // ASCII Logo + Branding
        // -------------------------------
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(@"
  ____  _                         ____              __ _   
 / ___|| |__   __ _ _ __ _ __    / ___|_ __ __ _   / _| |_ 
 \___ \| '_ \ / _` | '__| '_ \  | |   | '__/ _` | | |_| __|
  ___) | | | | (_| | |  | |_) | | |___| | | (_| | |  _| |_ 
 |____/|_| |_|\__,_|_|  | .__/   \____|_|  \__,_| |_|  \__|
                        |_|                                

              ⚒️ SharpCraft v1.4.1 ⚒️
    The MinGW-Style Forge of C# (Framework IL)
                Made by Sam M :)
------------------------------------------------------------");
        Console.ResetColor();

        // -------------------------------
        // Validate input
        // -------------------------------
        if (args.Length == 0)
        {
            Console.WriteLine("Usage: sharpcraft <file.cs> [-o output.exe]");
            return 1;
        }

        string sourceFile = args[0];
        if (!File.Exists(sourceFile))
        {
            Console.WriteLine($"❌ Error: The file '{sourceFile}' does not exist.");
            return 1;
        }

        string outputFile = "a.exe";
        for (int i = 0; i < args.Length; i++)
        {
            if (args[i] == "-o" && i + 1 < args.Length)
                outputFile = args[i + 1];
        }

        // -------------------------------
        // Read source code
        // -------------------------------
        string code = File.ReadAllText(sourceFile);
        SyntaxTree syntaxTree = CSharpSyntaxTree.ParseText(code);

        // -------------------------------
        // Resolve references robustly
        // -------------------------------
        var references = new List<MetadataReference>();
        var tpaString = AppContext.GetData("TRUSTED_PLATFORM_ASSEMBLIES") as string;

        if (!string.IsNullOrWhiteSpace(tpaString))
        {
            foreach (var asm in tpaString.Split(Path.PathSeparator, StringSplitOptions.RemoveEmptyEntries))
            {
                if (File.Exists(asm))
                    references.Add(MetadataReference.CreateFromFile(asm));
            }
        }
        else
        {
            string baseDir = AppContext.BaseDirectory;
            Console.WriteLine("⚠️ Warning: No TPA found, scanning base directory: " + baseDir);

            foreach (var dll in Directory.EnumerateFiles(baseDir, "*.dll"))
            {
                references.Add(MetadataReference.CreateFromFile(dll));
            }
        }

        // -------------------------------
        // Compilation
        // -------------------------------
        var compilationOptions = new CSharpCompilationOptions(OutputKind.ConsoleApplication);

        var compilation = CSharpCompilation.Create(
            Path.GetFileNameWithoutExtension(outputFile),
            new[] { syntaxTree },
            references,
            compilationOptions
        );

        EmitResult result = compilation.Emit(outputFile);

        if (!result.Success)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("❌ Compilation failed:");
            Console.ResetColor();
            foreach (var diagnostic in result.Diagnostics)
            {
                Console.WriteLine(diagnostic.ToString());
            }
            return 1;
        }

        // -------------------------------
        // Create runtimeconfig.json
        // -------------------------------
        string runtimeConfig = $@"
{{
  ""runtimeOptions"": {{
    ""tfm"": ""net9.0"",
    ""framework"": {{
      ""name"": ""Microsoft.NETCore.App"",
      ""version"": ""9.0.0""
    }}
  }}
}}";
        string jsonPath = Path.ChangeExtension(outputFile, ".runtimeconfig.json");
        File.WriteAllText(jsonPath, runtimeConfig);

        // -------------------------------
        // Success message
        // -------------------------------
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"✅ Build succeeded: {outputFile}");
        Console.ResetColor();
        Console.WriteLine($"📝 Runtime config generated: {jsonPath}");

        // Hint to run like gcc
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\n⚠️ Note: This is a .NET IL executable.");
        Console.WriteLine("▶ Run it like this to be safe:");
        Console.WriteLine($"   dotnet {outputFile}");
        Console.ResetColor();

        return 0;
    }
}
// Made by Sam M. :)
// Github: hecker-0101
// Thanks for using SharpCraft!