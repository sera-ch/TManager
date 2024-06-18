using TManager.service;
using Task = TManager.entity.Task;

namespace TManager.business
{
    public class GenerateDailyReportFormBusiness
    {
        const string PR_SENT = "(PR sent)";
        const string CODE_REVIEW = "(Fix comments)";
        const string MERGED = "(Merged)";
        const string BULLET = "• ";
        TaskService taskService;

        public GenerateDailyReportFormBusiness(TaskService taskService)
        {
            this.taskService = taskService;
        }

        public string GenerateDailyReport(int userId, DateOnly date)
        {
            List<Task> taskList = taskService.GetAllTasksByUserId(userId);

            List<Task> prSentTasks = taskList.FindAll(task => task.IsPrSent(date));

            List<Task> mergedTasks = taskList.FindAll(task => task.IsMerged(date));

            List<Task> inProgressTasks = taskList.FindAll(task => task.IsInProgress(date));

            List<Task> reviewingTasks = taskList.FindAll(task => task.IsInCodeReview(date));

            List<Task> todoTasks = taskList.FindAll(task => task.IsToDo(date));

            string dailyReport = "DONE:\n";
            if (prSentTasks.Count == 0 && mergedTasks.Count == 0)
            {
                dailyReport += BULLET + "N/A\n";
            }
            else
            {
                prSentTasks.ForEach(task =>
                {
                    dailyReport += BULLET + task.ToString() + " " + PR_SENT + "\n";
                });
                mergedTasks.ForEach(task =>
                {
                    dailyReport += BULLET + task.ToString() + " " + MERGED + "\n";
                });
            }
            dailyReport += "IN PROGRESS:\n";
            if (inProgressTasks.Count == 0 && reviewingTasks.Count == 0)
            {
                dailyReport += BULLET + "N/A\n";
            }
            else
            {
                inProgressTasks.ForEach(task =>
                {
                    dailyReport += BULLET + task.ToString() + "\n";
                });
                reviewingTasks.ForEach(task =>
                {
                    dailyReport += BULLET + task.ToString() + " " + CODE_REVIEW + "\n";
                });
            }
            dailyReport += "TODO:\n";
            if (todoTasks.Count == 0)
            {
                dailyReport += BULLET + "N/A";
            }
            else
            {
                int i = 0;
                todoTasks.ForEach(task =>
                {
                    dailyReport += BULLET + task.ToString();
                    i++;
                    if (i < todoTasks.Count)
                    {
                        dailyReport += "\n";
                    }
                });
            }
            return dailyReport;
        }

    }
}
