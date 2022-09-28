using System.Globalization;
using CsvHelper;
using SampleStream.Model;

namespace SampleApp.Service
{
    public class StreamRepository
    {
        private string _pathToDirectory { get; set; }
        private string _textFileName { get; set; }
        private string _csvFileName { get; set; }

        public StreamRepository(string pathToDirectory, string csvFileName)
        {
            _pathToDirectory = pathToDirectory;
            // _textFileName = textFileName;
            _csvFileName = csvFileName;
        }

        public void WriteFileFromString(string text)
        {
            CheckFileExist(_pathToDirectory);

            string fullPath = GetFullPathToFile(_pathToDirectory, _textFileName);

            using (FileStream fileStream = new FileStream(fullPath, FileMode.OpenOrCreate))
            {
                // преобразуем строку в байты
                byte[] array = System.Text.Encoding.Default.GetBytes(text);

                // запись массива байтов в файл
                fileStream.Write(array, 0, array.Length);

                Console.WriteLine("Текст записан в файл");
            }
        }

        public void WriteFileFromString1(string text)
        {
            CheckFileExist(_pathToDirectory);

            string fullPath = GetFullPathToFile(_pathToDirectory, _textFileName);

            using (FileStream fileStream = new FileStream(fullPath, FileMode.OpenOrCreate))
            {
                using (StreamWriter streamWriter = new StreamWriter(fileStream))
                {
                    streamWriter.Write(text);
                }

                Console.WriteLine("Текст записан в файл");
            }
        }

        public void WritePersonToCsv(Person person)
        {
            CheckFileExist(_pathToDirectory);

            string fullPath = GetFullPathToFile(_pathToDirectory, _csvFileName);

            using (FileStream fileStream = new FileStream(fullPath, FileMode.OpenOrCreate))
            {
                using (StreamWriter streamWriter = new StreamWriter(fileStream))
                {
                    using (var writer = new CsvWriter(streamWriter, CultureInfo.InvariantCulture))
                    {
                        // Формируем заголовки будущей таблицы
                        writer.WriteField(nameof(Person.Name));
                        writer.WriteField(nameof(Person.Age));

                        // Переход на следующую строку таблицы
                        writer.NextRecord();

                        writer.WriteField(person.Name);
                        writer.WriteField(person.Age);

                        writer.NextRecord();

                        // Очищает буфер, который был задействован CsvWriter-ом
                        writer.Flush();
                    }
                }
            }

        }

        public string ReadFileToString()
        {
            string fullPath = GetFullPathToFile(_pathToDirectory, _textFileName);

            using (FileStream fileStream = File.OpenRead(fullPath))
            {
                // резервируем массив для хранить данных
                byte[] array = new byte[fileStream.Length];

                // считываем данные
                fileStream.Read(array, 0, array.Length);

                // декодируем байты в строку
                string textFromFile = System.Text.Encoding.Default.GetString(array);

                return textFromFile;
            }
        }

        public string ReadFileToString1()
        {
            string fullPath = GetFullPathToFile(_pathToDirectory, _textFileName);

            using (FileStream fileStream = File.OpenRead(fullPath))
            {
                using (StreamReader streamReader = new StreamReader(fileStream))
                {
                    string textFromFile = streamReader.ReadToEnd();

                    return textFromFile;
                }
            }
        }

public Person ReadPersonFromCsv()
        {
            CheckFileExist(_pathToDirectory);

            string fullPath = GetFullPathToFile(_pathToDirectory, _csvFileName);

            using (FileStream fileStream = new FileStream(fullPath, FileMode.OpenOrCreate))
            {
                using (StreamReader streamReader = new StreamReader(fileStream))
                {
                    using (var reader = new CsvReader(streamReader, CultureInfo.InvariantCulture))
                    {
                        // Считываем из файла данные объекта Person
                        reader.Read();
                        Person person = reader.GetRecord<Person>();

                        return person;
                    }
                }
            }
        }

        private string GetFullPathToFile(string pathToDirectory, string fileName)
        {
            return Path.Combine(pathToDirectory, fileName);
        }

        private void CheckFileExist(string pathToDirectory)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(pathToDirectory);
            // Проверяем, есть ли каталог по пришедшему пути
            if (!dirInfo.Exists)
            {
                // Создаём каталог для файла
                dirInfo.Create();
            }
        }
    }
}