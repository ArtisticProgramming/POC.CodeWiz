using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POC.CodeWiz.Exceptions
{
    public class TemplateMissingArgumentException : Exception
    {
        public TemplateMissingArgumentException(string argumentName)
      : base($"Template does not have the argument: {argumentName}")
        {
        }
    }
}
