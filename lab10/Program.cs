using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace compiler
{
    class Program
    {
        static SyntaxAnalyzer syntaxAnalyzer = new SyntaxAnalyzer();
        static void Main()
        {
            InputOutput.Init("pascal.pas");
            syntaxAnalyzer.Analyze();
            InputOutput.End();
        }
    }
}
