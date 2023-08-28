using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POC.CodeWiz.Exceptions.Template
{
    public class EmptyTemplateException : Exception
    {
        public EmptyTemplateException(string path) : base("Template does not have any content.")
        {
        }
    }
}
