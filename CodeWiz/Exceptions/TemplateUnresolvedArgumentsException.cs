using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POC.CodeWiz.Exceptions
{
    internal class TemplateUnresolvedArgumentsException : Exception
    {
        public TemplateUnresolvedArgumentsException()
            : base($"There is at least one unresolved arguments in template.")
        {
           
        }
    }
}
