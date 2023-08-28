using NUnit.Framework;
using POC.CodeWiz.Template;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWiz.UntTests.CodeGen
{
    [TestFixture]
    public class TemplateHandlerTests
    {
        private TemplateHandler templateHandler;
        private string templateName;
        private string content;

        [SetUp]
        public void SetUp()
        {
            templateHandler = new TemplateHandler();
            templateName = "TestTemplateFile";
            content = "Hello, it is test file @<arg>@";
            // Use a using statement to ensure the file stream is properly disposed
            using (StreamWriter writer = new StreamWriter(templateName))
            {
                writer.Write(content);
            }
        }

        [TearDown]
        public void Teardown()
        {
            // Perform cleanup operations here
            File.Delete(templateName);

        }

        [Test]
        public void DoesTemplateFileExist_WhenFileExists_ReturnsTrue()
        {
            // Arrange

            // Act
            bool result = templateHandler.DoesTemplateFileExist(templateName);

            // Assert
            Assert.IsTrue(result);

        }

        [Test]
        public void DoesTemplateFileExist_WhenFileDoesNotExist_ReturnsFalse()
        {
            // Arrange
            string invalidTemplateName = "fileNotExist.txt";

            // Act
            bool result = templateHandler.DoesTemplateFileExist(invalidTemplateName);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void GetTemplateText_WhenCalledWithValidTemplateName_ReturnsTemplateText()
        {
            // Arrange

            // Act
            string result = templateHandler.GetTemplateText(templateName);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotEmpty(result);
            Assert.That(result, Is.EqualTo(content));
        }

        [Test]
        public void GetTemplateText_WhenCalledWithInValidTemplateName_ThrowFileNotFoundException()
        {
            // Arrange
            var inValideName = "InvalideName";
            // Act
            TestDelegate act = () => templateHandler.GetTemplateText(inValideName);

            // Assert
            Assert.Throws<FileNotFoundException>(act);
        }


    }
}