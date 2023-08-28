using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POC.CodeWiz.Template
{
    public class TemplateHandler : ITemplateHandler
    {
        public bool DoesTemplateFileExist(string name)
        {
            return File.Exists(name);
        }

        public string GetTemplateText(string name)
        {
            if (DoesTemplateFileExist(name)==false)
                throw new FileNotFoundException(name);

            var text = File.ReadAllText(name);

            return text;
        }

        public bool IsTemplateValid(string templateText)
        {
            
            return true;
        }
    }
}
