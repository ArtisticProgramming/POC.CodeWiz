using POC.CodeWiz.Exceptions.CodeGen;
using System.Text.RegularExpressions;

namespace POC.CodeWiz.CodeGen
{
    public class TemplateCodeGenerator : ITemplateCodeGenerator
    {
        public string? ArgumentBeginingSign { get; set; }
        public string? ArgumentEndign { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="templateText"></param>
        /// <param name="arguments"></param>
        /// <returns></returns>
        public string GenerateOnce(string templateText, Dictionary<string, string> arguments)
        {
            if (string.IsNullOrEmpty(templateText))
                return templateText;

            string result = GenerateTemplate(templateText, arguments);

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="templateText"></param>
        /// <param name="argumentsList"></param>
        /// <param name="appendBy"></param>
        /// <returns></returns>
        public string GenerateMultiTimeAndAppend(string templateText, List<Dictionary<string, string>> argumentsList, string appendBy)
        {
            var result = string.Empty;

            foreach (var arguments in argumentsList)
                result += GenerateOnce(templateText, arguments) + appendBy;

            return result;
        }

        #region Private Methodes

        /// <summary>
        /// 
        /// </summary>
        /// <param name="templateText"></param>
        /// <param name="arguments"></param>
        /// <returns></returns>
        /// <exception cref="TemplateUnresolvedArgumentsException"></exception>
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
        #endregion
    }
}
