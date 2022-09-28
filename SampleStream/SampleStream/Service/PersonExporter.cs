using CsvHelper;
using SampleStream.Model;
using System.Globalization;

namespace SampleStream.Service
{
    public class PersonExporter
    {
        private string _pathToDirecory { get; set; }
        private string _csvFileName { get; set; }

        public PersonExporter(string pathToDirectory, string csvFileName)
        {
            _pathToDirecory = pathToDirectory;
            _csvFileName = csvFileName;
        }

        public void WritePersonToCsv(Person person)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(_pathToDirecory);
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }

            string fullPath = GetFullPathToFile(_pathToDirecory, _csvFileName);

            using (FileStream fileStream = new FileStream(fullPath, FileMode.OpenOrCreate))
            {
                using (StreamWriter streamWriter = new StreamWriter(fileStream))
                {
                    using (var writer = new CsvWriter(streamWriter, CultureInfo.CurrentCulture))
                    {
                        writer.WriteField(nameof(Person.Name));
                        writer.WriteField(nameof(Person.Age));

                        writer.NextRecord();

                        writer.WriteField(person.Name);
                        writer.WriteField(person.Age);

                        writer.NextRecord();

                        writer.Flush();
                    }
                }
            }
        }

        public Person ReadPersonFromCsv()
        {
            string fullPath = GetFullPathToFile(_pathToDirecory, _csvFileName);
            using (FileStream fileStream = new FileStream(fullPath, FileMode.OpenOrCreate))
            {
                using (StreamReader streamReader = new StreamReader(fileStream))
                {
                    using (var reader = new CsvReader(streamReader, CultureInfo.CurrentCulture))
                    {
                        reader.Read();
                        return reader.GetRecord<Person>();
                    }
                }
            }
        }


        private string GetFullPathToFile(string pathToFile, string fileName)
        {
            return Path.Combine(pathToFile, fileName);
        }
    }
}
