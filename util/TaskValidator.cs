using TManager.error;

namespace TManager.util
{
    public class TaskValidator
    {
        public static void ValidateIdAndName(string id, string name)
        {
            if (id == "" || name == "")
            {
                throw new InvalidIdOrNameException();
            }
        }

        public static void ValidateDeadline(string deadline)
        {
            DateOnly deadlineDate = DateOnly.Parse(deadline);
            if (deadlineDate < DateOnly.FromDateTime(DateTime.Now))
            {
                throw new InvalidDeadlineException();
            }
        }
    }
}
