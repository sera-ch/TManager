using System.Text;
using Task = TManager.entity.Task;

namespace TManager.util
{
    public class FileUtil
    {
        const string FILE_PATH = "../../../resource/";
        const string FILE_EXTENSION = ".txt";
        const Int32 BUFFER_SIZE = 128;
        const char ATTRIBUTE_SPLIT_REGEX = '|';
        public static List<Task> ReadFileToTaskList(string fileName)
        {
            List<Task> taskList = new List<Task>();
            using (var fileStream = File.OpenRead(FILE_PATH + fileName + FILE_EXTENSION))
            {
                using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BUFFER_SIZE))
                {
                    String line;
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
            string newLine = "\n" + task.ToDataString();
            string filePath = FILE_PATH + fileName + FILE_EXTENSION;
            File.AppendAllText(filePath, newLine);
        }
    }
}
