using POC.CodeWiz.Exceptions;
using System.Text.RegularExpressions;

namespace POC.CodeWiz.CodeGen
{
    public class CodeGenerator : ICodeGenerator
    {
        public string? ArgumentBeginingSign { get; set; }
        public string? ArgumentEndign { get; set; }

        public string GenerateSignleTime(string templateText, Dictionary<string, string> arguments)
        {
            if (string.IsNullOrEmpty(templateText))
                throw new ArgumentNullException("Template text is empty or null");

            string result = GenerateTemplate(templateText, arguments);

            return result;
        }

        public string GenerateMultiTime(string templateText, List<Dictionary<string, string>> argumentsList, string separatedBy)
        {
            var result = string.Empty;

            if (string.IsNullOrEmpty(templateText))
                throw new ArgumentNullException("Template text is empty or null");

            foreach (var arguments in argumentsList)
                result += GenerateTemplate(templateText, arguments) + separatedBy;

            return result;
        }

        private string GenerateTemplate(string templateText, Dictionary<string, string> arguments)
        {
            string result = ReplaceTemplateArguments(templateText, arguments);

            if (ContainsUnresolvedArguments(result))
                throw new TemplateUnresolvedArgumentsException();

            return result;
        }

        private string ReplaceTemplateArguments(string templateText, Dictionary<string, string> arguments)
        {
            foreach (var item in arguments)
            {
                var templateArgument = $"{ArgumentBeginingSign}{item.Key}{ArgumentEndign}";
                var generatedActualValue = item.Value;

                if (ContainsArgument(templateText, templateArgument) == false)
                    throw new TemplateMissingArgumentException(templateArgument);

                templateText = templateText.Replace(templateArgument, generatedActualValue);
            }
            return templateText;
        }

        private static bool ContainsArgument(string templateText, string templateArgument)
        {
            return templateText.Contains(templateArgument);
        }

        private bool ContainsUnresolvedArguments(string text)
        {
            return Regex.IsMatch(text, @"@<[A-Za-z0-9]+>");
        }
    }
}
