namespace CodeWiz.UntTests.CodeGen
{
    [TestFixture]
    public class TemplateTests
    {
        private string _validTemplatePath;
        private string _nonexistentTemplatePath;
        private string _emptyTemplatePath;

        [SetUp]
        public void Setup()
        {
            _validTemplatePath = CreatFakeTemplate(false); // Replace with an actual valid template path
            _nonexistentTemplatePath = "nonexistent-template.txt";
            _emptyTemplatePath = CreatFakeTemplate(true);
        }

        private string CreatFakeTemplate(bool shouldBeEmpty)
        {
            var templateName = "FakeTemplateFile.txt";
            var content = "Hello, it is test file @<arg>@";

            if (shouldBeEmpty)
            {
                templateName = "FakeEmptyTemplateFile.txt";
                content = String.Empty;
            }

            // Use a using statement to ensure the file stream is properly disposed
            using (StreamWriter writer = new StreamWriter(templateName))
            {
                writer.Write(content);
            }

            return templateName;
        }

        [TearDown]
        public void Teardown()
        {
            // Perform cleanup operations here
            File.Delete(_validTemplatePath);
            File.Delete(_emptyTemplatePath);
        }

        [Test]
        public void Load_ValidTemplate_ShouldLoadBody()
        {
            // Arrange
            var template = new Template(_validTemplatePath);

            // Act
            template.Load();

            // Assert
            Assert.IsFalse(string.IsNullOrEmpty(template.Body));
        }

        [Test]
        public void Load_NonexistentTemplate_ShouldThrowFileNotFoundException()
        {
            // Arrange
            var template = new Template(_nonexistentTemplatePath);

            // Act & Assert
            Assert.Throws<FileNotFoundException>(() => template.Load());
        }

        [Test]
        public void Load_EmptyTemplate_ShouldThrowEmptyTemplateException()
        {
            // Arrange
            var template = new Template(_emptyTemplatePath);

            // Act & Assert
            Assert.Throws<EmptyTemplateException>(() => template.Load());
        }

        [Test]
        public void Load_NullOrWhiteSpacePath_ShouldThrowArgumentException()
        {
            // Act & Assert
            Assert.Throws<ArgumentException>(() => new Template(null));
            Assert.Throws<ArgumentException>(() => new Template(""));
            Assert.Throws<ArgumentException>(() => new Template(" "));
        }
    }
}
