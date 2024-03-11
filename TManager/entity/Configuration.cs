namespace TManager.entity
{
    public class Configuration
    {
        public SaveSlot SaveSlot { get; set; }

        public int UserId { get; set; }

        public Configuration(string userId)
        {
            this.SaveSlot = entity.SaveSlot.A;
            this.UserId = int.Parse(userId);
        }

        public override string ToString()
        {
            return UserId.ToString();
        }
    }
}
