namespace TManager.entity
{
    public class Configuration
    {
        public SaveSlot SaveSlot { get; set; }

        public Configuration(string SaveSlot)
        {
            this.SaveSlot = (SaveSlot)Enum.Parse(typeof(SaveSlot), SaveSlot, true);
        }

        public override string ToString()
        {
            return SaveSlot.ToString();
        }
    }
}
