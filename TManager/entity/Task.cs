namespace TManager.entity
{
    public class Task
    {
        const char ATTRIBUTE_SPLIT_REGEX = '|';
        public string Id { get; set; }
        public string Name { get; set; }
        public DateOnly? Assigned { get; set; }
        public DateOnly? Started { get; set; }
        public DateOnly? PrSent { get; set; }
        public DateOnly? Merged { get; set; }
        public DateOnly? Closed { get; set; }
        public DateOnly? Done { get; set; }
        public TaskStatus Status { get; set; }
        public DateOnly Deadline { get; set; }
        public string Note { get; set; }

        public override string ToString()
        {
            return Id + " " + Name;
        }

        public bool IsWip()
        {
            return Status == TaskStatus.TODO || Status == TaskStatus.IN_PROGRESS;
        }

        public string ToDataString()
        {
            return string.Join(ATTRIBUTE_SPLIT_REGEX, Id, Name, Assigned.ToString(), Started.ToString(), PrSent.ToString(), Merged.ToString(), Closed.ToString(), Done.ToString(), Status.ToString(),
                Deadline.ToString(), Note);
        }

        public string GetSearchKey()
        {
            return string.Join(ATTRIBUTE_SPLIT_REGEX, Id, Name);
        }

        public bool IsDone()
        {
            return Status != TaskStatus.TODO && Status != TaskStatus.IN_PROGRESS && Status != TaskStatus.CODE_REVIEW;
        }

        public Task(string Id, string Name, string Assigned, String Started, String PrSent, String Merged, String Closed, String Done, String Status, String Deadline, String Note)
        {
            this.Id = Id;
            this.Name = Name;
            this.Assigned = Assigned == String.Empty ? null : DateOnly.Parse(Assigned);
            this.Started = Started == String.Empty ? null : DateOnly.Parse(Started);
            this.PrSent = PrSent == String.Empty ? null : DateOnly.Parse(PrSent);
            this.Merged = Merged == String.Empty ? null : DateOnly.Parse(Merged);
            this.Closed = Closed == String.Empty ? null : DateOnly.Parse(Closed);
            this.Done = Done == String.Empty ? null : DateOnly.Parse(Done);
            this.Status = (TaskStatus)Enum.Parse(typeof(TaskStatus), Status, true);
            this.Deadline = DateOnly.Parse(Deadline);
            this.Note = Note;
        }

        public bool IsMatch(string status, string searchText)
        {
            return IsStatusMatch(status) && (Id.ToLower().Contains(searchText.ToLower()) || Name.ToLower().Contains(searchText.ToLower()));
        }

        public bool IsStatusMatch(string status)
        {
            if (status == string.Empty)
            {
                return true;
            }
            return Status.ToString().ToLower().Contains(status.ToLower());
        }

    }
}
