using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POC.CodeWiz.Template
{
    internal interface ITemplateHandler
    {
        bool DoesTemplateFileExist(string name);
        string GetTemplateText(string name);
        bool IsTemplateValid(string templateText);
    }
}
