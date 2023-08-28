using POC.CodeWiz.Exceptions.Template;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POC.CodeWiz.Template
{
    public class Template
    {
        public string Path { get; set; }
        public string Name { get; set; }
        public string? Body { get; set; } = null;
        public Dictionary<string, string> Arguments { get; set; }

        public Template(string path)
        {
            Path = path;

        }

        public void Build()
        {
            if (DoesTemplateFileExist() == false)
                throw new FileNotFoundException(Path);

            SetBody();

            if (IsBodyEmptyOrNull())
                throw new EmptyTemplateException(Path);

            SetArguments();
        }


        private bool DoesTemplateFileExist()
        {
            return File.Exists(Path);
        }

        private void SetBody()
        {
            Body = File.ReadAllText(Path);
        }

        private bool IsBodyEmptyOrNull()
        {
            return Body == null || Body.Length == 0;
        }
    }
}
