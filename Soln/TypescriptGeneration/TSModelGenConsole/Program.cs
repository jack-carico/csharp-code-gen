using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.MSBuild;


using System.Reflection;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace TSModelGenConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            UseReflection();
        }

        static void UseReflection()
        {
            var assembly = Assembly.LoadFrom("DataTransferLib");
            foreach (Type t in assembly.GetTypes())
            {
                if (t.GetCustomAttribute<DataTransferLib.DTOModelAttribute>() != null)
                {
                    Console.WriteLine(t.Name);
                }
            }
        }

        static void OldTry()
        {
            string basePath = @"C:\GitHubLocal\csharp-code-gen\Soln\TypescriptGeneration\DataTransferLib\";
            string baseSlnPath = @"C:\GitHubLocal\csharp-code-gen\Soln\TypescriptGeneration";

            using (var sReader = new System.IO.StreamReader(basePath + @"DTO\UserProfile.cs"))
            {
                Environment.SetEnvironmentVariable("VSINSTALLDIR", @"C:\Program Files (x86)\Microsoft Visual Studio\2017\Community");
                Environment.SetEnvironmentVariable("VisualStudioVersion", @"15.0");

                var msbWorkspace = MSBuildWorkspace.Create();
                msbWorkspace.WorkspaceFailed += MsbWorkspace_WorkspaceFailed;
                var sln = msbWorkspace.OpenSolutionAsync(baseSlnPath + @"\TypescriptGeneration.sln").Result;
                foreach (var p in sln.ProjectIds)
                {
                    Console.WriteLine(p.Id.ToString());
                    var project = sln.GetProject(p);
                    Console.WriteLine(project.Name);
                }

                /*
                var projType = project.GetType();
                var compilation = project.GetCompilationAsync().Result;
                
                foreach (var tree in compilation.SyntaxTrees)
                {
                    Console.WriteLine(tree.FilePath);
                }
                */
                // var classVisitor = new ClassVirtualizationVisitor();
                
            }
        }

        private static void MsbWorkspace_WorkspaceFailed(object sender, WorkspaceDiagnosticEventArgs e)
        {
            Console.WriteLine(e.Diagnostic.Message);
        }
    }
}
