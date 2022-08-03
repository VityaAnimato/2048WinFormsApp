using System.IO;
using System.Text;


namespace _2048WinFormsApp
{
    public static class FileProvider
    {

        public static void Write(string fileName, string value)
        {
            var writer = new StreamWriter(fileName, false, Encoding.UTF8);
            writer.WriteLine(value);
            writer.Close();
        }

        public static bool Exists(string fileName)
        {
            return File.Exists(fileName);
        }

        public static string Get(string fileName)
        {
            var reader = new StreamReader(fileName, Encoding.UTF8);
            var value = reader.ReadToEnd();
            reader.Close();
            return value;
        }
    }
}

