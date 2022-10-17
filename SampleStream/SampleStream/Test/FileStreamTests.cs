using SampleStream.Service;
using Xunit;

namespace SampleStream.Test
{
    public class FileStreamTests
    {
        [Fact]
        public void FileStreamPositiveTest()
        {
            //Arrange
            string pathToDirectory = Path.Combine("C:", "TestFiles");
            string fileName = "note.txt";

            FileStreamRepository streamRepository = new FileStreamRepository(pathToDirectory, fileName);

            string text = "Строка для записи";

            //Act
            streamRepository.WriteFileFromString(text);

            string textFromFile = streamRepository.ReadFileToString();

            //Assert
            Assert.Equal(text, textFromFile);
        }

        [Fact]
        public void FileModeNegativeTest()
        {
            //Arrange
            string pathToDirectory = Path.Combine("C:", "TestFiles");
            string fileName = "note.txt";

            FileStreamRepository streamRepository = new FileStreamRepository(pathToDirectory, fileName);

            string text = "Строка для записи";

            //Act
            streamRepository.WriteFileFromStringWrongFileMode(text);

            string textFromFile = streamRepository.ReadFileToString();

            //Assert
            Assert.Equal(text, textFromFile);
        }

        [Fact]
        public void WryteByteNegativeTest()
        {
            //Arrange
            string pathToDirectory = Path.Combine("C:", "TestFiles");
            string fileName = "note.txt";

            FileStreamRepository streamRepository = new FileStreamRepository(pathToDirectory, fileName);

            //Act
            streamRepository.WriteByteNegative();

            string textFromFile = streamRepository.ReadFileToString();
        }
    }
}
