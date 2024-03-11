using TManager.entity;

namespace TManager.util
{
    public class FileUtil
    {
        const string CONFIG_FILE_PATH = "./config/";
        const string CONFIG_FILE_NAME = "config";
        const string CONFIG_FILE_EXT = ".cfg";

        private bool CheckAndCreateFile(string fileName)
        {
            if (!File.Exists(fileName))
            {
                File.Create(fileName).Close();
                return true;
            }
            return false;
        }

        public virtual void WriteConfigurationToFile(Configuration configuration)
        {
            string filePath = CONFIG_FILE_PATH + CONFIG_FILE_NAME + CONFIG_FILE_EXT;
            CheckAndCreateFile(filePath);
            File.WriteAllText(filePath, configuration.ToString());
        }

        public virtual Configuration ReadConfigurationFromFile()
        {
            string filePath = CONFIG_FILE_PATH + CONFIG_FILE_NAME + CONFIG_FILE_EXT;
            return new Configuration(File.ReadAllText(filePath));
        }
    }
}
