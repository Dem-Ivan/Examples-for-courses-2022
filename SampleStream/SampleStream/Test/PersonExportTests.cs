using SampleStream.Model;
using SampleStream.Service;
using Xunit;

namespace SampleStream.Test
{
    public class PersonExportTests
    {
        [Fact]
        public void ExportPersonPositiveTest()
        {
            //Arrange
            string pathToDirectory = Path.Combine("C:", "TestFiles");
            string fileName = "person.csv";
            PersonExporter personExporter = new PersonExporter(pathToDirectory, fileName);

            Person person = new Person()
            {
                Name = "John",
                Age = 30
            };

            //Act
            personExporter.WritePersonToCsv(person);
            Person personFromFile = personExporter.ReadPersonFromCsv();

            //Assert
            Assert.Equal(person.Name, personFromFile.Name);
            Assert.Equal(person.Age, personFromFile.Age);
        }
    }
}
