using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POC.CodeWiz.CodeGen
{
    internal interface ICodeGenerator
    {
        string GenerateSignleTime(string templateText, Dictionary<string, string> arguments);
        string GenerateMultiTime(string templateText, List<Dictionary<string, string>> argumentsList, string separatedBy);
    }
}
