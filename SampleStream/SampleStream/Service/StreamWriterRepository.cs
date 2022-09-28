namespace SampleStream.Service
{
    public class StreamWriterRepository
    {
        private string _pathToDirectory { get; set; }
        private string _textFileName { get; set; }

        public StreamWriterRepository(string pathToDirectory, string textFileName)
        {
            _pathToDirectory = pathToDirectory;
            _textFileName = textFileName;
        }

        public void WriteFileFromString(string text)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(_pathToDirectory);

            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }

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

        public string ReadFileToString()
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


        private string GetFullPathToFile(string pathToFile, string fileName)
        {
            return Path.Combine(pathToFile, fileName);
        }
    }
}
