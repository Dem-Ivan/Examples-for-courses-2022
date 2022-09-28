namespace SampleStream.Service
{
    public class FileStreamRepository
    {
        private string _pathToDirectory { get; set; }
        private string _textFileName { get; set; }

        public FileStreamRepository(string pathToDirectory, string textFileName)
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
                byte[] array = System.Text.Encoding.Default.GetBytes(text);
                fileStream.Write(array, 0, array.Length);

                Console.WriteLine("Текст записан в файл");
            }
        }

        public void WriteFileFromStringWrongFileMode(string text)
        {
            string fullPath = GetFullPathToFile(_pathToDirectory, _textFileName);

            using (FileStream fileStream = new FileStream(fullPath, FileMode.Open))
            {
                byte[] array = System.Text.Encoding.Default.GetBytes(text);
                fileStream.Write(array, 0, array.Length);

                Console.WriteLine("Текст записан в файл");
            }
        }

        public void WriteByteNegative()
        {
            DirectoryInfo dirInfo = new DirectoryInfo(_pathToDirectory);

            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }

            string fullPath = GetFullPathToFile(_pathToDirectory, _textFileName);

            using (FileStream fileStream = new FileStream(fullPath, FileMode.OpenOrCreate))
            {
                fileStream.WriteByte(13);
                fileStream.WriteByte(18);

                Console.WriteLine("Текст записан в файл");
            }
        }

        public string ReadFileToString()
        {
            string fullPath = GetFullPathToFile(_pathToDirectory, _textFileName);
            using (FileStream fileStream = File.OpenRead(fullPath))
            {
                byte[] array = new byte[fileStream.Length];
                fileStream.Read(array, 0, array.Length);

                string textFromFile = System.Text.Encoding.Default.GetString(array);

                return textFromFile;
            }
        }

        private string GetFullPathToFile(string pathToFile, string fileName)
        {
            return Path.Combine(pathToFile, fileName);
        }
    }
}
