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
        private readonly FileInfo _templateFileInfo;

        public string Name { get; }
        public string? Body { get; private set; }
        public Dictionary<string, string> Arguments { get; private set; }

        public Template(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
                throw new ArgumentException("Path cannot be null or empty.", nameof(path));

            _templateFileInfo = new FileInfo(path);
            Name = _templateFileInfo.Name;
        }

        public void Load()
        {
            if (!DoesTemplateFileExist())
                throw new FileNotFoundException($"Template file not found: {_templateFileInfo.FullName}");

            Body = File.ReadAllText(_templateFileInfo.FullName);

            if (IsBodyEmptyOrNull())
                throw new EmptyTemplateException(_templateFileInfo.FullName);
        }

        private void SetArguments(Dictionary<string, string> arguments)
        {
            Arguments = arguments ?? throw new ArgumentNullException(nameof(arguments));
        }

        private bool DoesTemplateFileExist()
        {
            return _templateFileInfo.Exists;
        }

        private bool IsBodyEmptyOrNull()
        {
            return string.IsNullOrEmpty(Body);
        }
    }
}
