using NUnit.Framework;
using POC.CodeWiz.CodeGen;
using POC.CodeWiz.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWiz.UntTests.CodeGen
{

    [TestFixture]
    internal class CodeGeneratorUnitTest
    {
        private CodeGenerator codeGenerator;
        private string templateText;

        [SetUp]
        public void SetUp()
        {
            // Code to set up arrangements before each test
            codeGenerator = new CodeGenerator()
            {
                ArgumentBeginingSign = "@<",
                ArgumentEndign = ">@"
            };

            templateText = "How are you @<customer>@@<questionMark>@";
        }


        [Test]
        public void GenerateSignleTime_TemplateAndTwoArguments_ReturnGeneratedTemplate()
        {
            Dictionary<string, string> arguments = new Dictionary<string, string>();
            arguments.Add("customer", "ali");
            arguments.Add("questionMark", "?");

            // Act
            string result = codeGenerator.GenerateSignleTime(templateText, arguments);

            // Assert
            Assert.AreEqual("How are you ali?", result);
        }

        [Test]
        public void GenerateSignleTime_TemplateAndWithOneMissedArguments_ThrowTemplateMissingArgumentException()
        {
            Dictionary<string, string> arguments = new Dictionary<string, string>();
            arguments.Add("customer", "ali");
            arguments.Add("MissedArgument", "-");

            // Act
            TestDelegate act = () => codeGenerator.GenerateSignleTime(templateText, arguments);

            // Assert
            Assert.Throws<TemplateMissingArgumentException>(act);
        }


        [Test]
        public void GenerateMultiTime_TemplateAndArguments_ReturnGeneratedTemplate()
        {
            //Arrange
            var templateText = "How are you @<customer>@@<questionMark>@";
            List<Dictionary<string, string>> argumentsList = new List<Dictionary<string, string>>();

            Dictionary<string, string> arg1 = new Dictionary<string, string>();
            arg1.Add("customer", "ali");
            arg1.Add("questionMark", "?");

            Dictionary<string, string> arg2 = new Dictionary<string, string>();
            arg2.Add("customer", "Mostafa");
            arg2.Add("questionMark", "???");

            argumentsList.Add(arg1);
            argumentsList.Add(arg2);

            // Act
            string result = codeGenerator.GenerateMultiTime(templateText, argumentsList, Environment.NewLine);

            // Assert
            Assert.AreEqual("How are you ali?" + Environment.NewLine + "How are you Mostafa???" + Environment.NewLine, result);
        }





        //  [Test]
        //public void GenerateSignleTime_TemplateAndArguments_ReturnGeneratedTemplate()
        //{
        //    //// Arrange
        //    //var mockService = new Mock<IMyService>();
        //    //mockService.Setup(service => service.GetValue()).Returns("Hello from Moq");

        //    var templateText = "How are you @<customer>@@<questionMark>@";

        //    Dictionary<string, string> arguments = new Dictionary<string, string>();
        //    arguments.Add("customer", "ali");
        //    arguments.Add("questionMark", "?");

        //    // Act
        //    string result = codeGenerator.GenerateSignleTime(templateText, arguments);

        //    // Assert
        //    Assert.AreEqual("How are you ali?", result);
        //}

    }
}
