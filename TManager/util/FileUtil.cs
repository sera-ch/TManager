using System.Text;
using TManager.entity;
using Task = TManager.entity.Task;

namespace TManager.util
{
    public class FileUtil
    {
        const string FILE_PATH = "./data/";
        const string FILE_EXTENSION = ".dat";
        const string CONFIG_FILE_PATH = "./config/";
        const string CONFIG_FILE_NAME = "config";
        const string CONFIG_FILE_EXT = ".cfg";
        const int BUFFER_SIZE = 128;
        public const char ATTRIBUTE_SPLIT_REGEX = '|';
        const string TEMP = "_temp";
        public static List<Task> ReadFileToTaskList(string fileName)
        {
            List<Task> taskList = new List<Task>();
            var filePath = FILE_PATH + fileName + FILE_EXTENSION;
            CheckAndCreateFile(filePath);
            using (var fileStream = File.OpenRead(filePath))
            {
                using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BUFFER_SIZE))
                {
                    string line;
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        string[] attributes = line.Split(ATTRIBUTE_SPLIT_REGEX);
                        taskList.Add(new Task(attributes[0], attributes[1], attributes[2], attributes[3], attributes[4], attributes[5], attributes[6], attributes[7], attributes[8], attributes[9], attributes[10]));
                    }
                }
            }
            return taskList;
        }

        public static void WriteTaskToFile(string fileName, Task task)
        {
            string filePath = FILE_PATH + fileName + FILE_EXTENSION;
            CheckAndCreateFile(filePath);
            string newLine = "";
            if (File.ReadAllLines(filePath).Count() != 0)
            {
                newLine += "\n";
            }
            newLine += task.ToDataString();
            File.AppendAllText(filePath, newLine);
        }

        public static void EditLine(string fileName, string textToSearchFor, string newLine)
        {
            string filePath = FILE_PATH + fileName + FILE_EXTENSION;
            string tempFilePath = FILE_PATH + fileName + TEMP + FILE_EXTENSION;
            int lineToEdit = Find(fileName, textToSearchFor);
            if (lineToEdit == -1)
            {
                return;
            }
            using (StreamReader reader = new StreamReader(filePath))
            {
                using (StreamWriter writer = new StreamWriter(tempFilePath))
                {
                    int lineNumber = -1;
                    string line;
                    int totalNumberOfLines = File.ReadAllLines(filePath).Length;
                    while ((line = reader.ReadLine()) != null)
                    {
                        lineNumber++;
                        if (lineNumber == lineToEdit)
                        {
                            if (lineNumber < totalNumberOfLines - 1)
                            {
                                writer.WriteLine(newLine);
                                continue;
                            }
                            writer.Write(newLine);
                            continue;
                        }
                        if (lineNumber < totalNumberOfLines - 1)
                        {
                            writer.WriteLine(line);
                            continue;
                        }
                        writer.Write(line);
                    }
                }
            }
            File.Delete(filePath);
            File.Move(tempFilePath, filePath);
        }

        public static void DeleteLine(string fileName, string textToSearchFor)
        {
            string filePath = FILE_PATH + fileName + FILE_EXTENSION;
            string tempFilePath = FILE_PATH + fileName + TEMP + FILE_EXTENSION;
            int lineToEdit = Find(fileName, textToSearchFor);
            if (lineToEdit == -1)
            {
                return;
            }
            using (StreamReader reader = new StreamReader(filePath))
            {
                using (StreamWriter writer = new StreamWriter(tempFilePath))
                {
                    int lineNumber = -1;
                    string line;
                    int totalNumberOfLines = File.ReadAllLines(filePath).Length;
                    while ((line = reader.ReadLine()) != null)
                    {
                        lineNumber++;
                        if (lineNumber == lineToEdit)
                        {
                            writer.Write("");
                            continue;
                        }
                        if (lineNumber < totalNumberOfLines - 1)
                        {
                            writer.WriteLine(line);
                            continue;
                        }
                        writer.Write(line);
                    }
                }
            }
            File.Delete(filePath);
            File.Move(tempFilePath, filePath);
        }

        private static int Find(string fileName, string textToSearchFor)
        {
            string filePath = FILE_PATH + fileName + FILE_EXTENSION;
            int index = -1;
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    index++;
                    if (line.Contains(textToSearchFor))
                    {
                        return index;
                    }
                }
            }
            return -1;
        }

        private static bool CheckAndCreateFile(string fileName)
        {
            if (!File.Exists(fileName))
            {
                File.Create(fileName).Close();
                return true;
            }
            return false;
        }

        public static void WriteConfigurationToFile(Configuration configuration)
        {
            string filePath = CONFIG_FILE_PATH + CONFIG_FILE_NAME + CONFIG_FILE_EXT;
            CheckAndCreateFile(filePath);
            File.WriteAllText(filePath, configuration.ToString());
        }

        public static Configuration ReadConfigurationFromFile()
        {
            string filePath = CONFIG_FILE_PATH + CONFIG_FILE_NAME + CONFIG_FILE_EXT;
            return new Configuration(File.ReadAllText(filePath));
        }
    }
}
