using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Text;

namespace Grpc
{
    [Generator]
    public class CodeGenerator : ISourceGenerator
    {
        public void Execute(GeneratorExecutionContext context)
        {
            Debug.WriteLine("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            context.AddSource("myGeneratedFile.cs", SourceText.From($@"
                    namespace GeneratedNamespace
                    {{
                        public class GeneratedClass
                        {{
                            public string s = ""hallo"";
                        }}
                    }}", Encoding.UTF8));
        }

        public void Initialize(GeneratorInitializationContext context)
        {
        }
    }
}
