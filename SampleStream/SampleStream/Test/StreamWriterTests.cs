using SampleStream.Service;
using Xunit;

namespace SampleStream.Test
{
    public class StreamWriterTests
    {
        [Fact]
        public void StreamWritePositiveTest()
        {
            //Arrange
            string pathToDirectory = Path.Combine("C:", "TestFiles");
            string fileName = "note.txt";

            StreamWriterRepository streamRepository = new StreamWriterRepository(pathToDirectory, fileName);

            string text = "Строка для записи";

            //Act
            streamRepository.WriteFileFromString(text);

            string textFromFile = streamRepository.ReadFileToString();

            //Assert
            Assert.Equal(text, textFromFile);
        }
    }
}
