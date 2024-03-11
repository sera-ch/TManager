<<<<<<< HEAD
﻿using TManager.business;
using TManager.util;
=======
﻿using TManager.util;
using Task = TManager.entity.Task;
>>>>>>> 0e502141f256c07c2be5b5ff8b667f906c62e2c9

namespace TManager
{
    public partial class GenerateDailyReportForm : Form
    {
        private GenerateDailyReportFormBusiness GenerateDailyReportFormBusiness;
        public GenerateDailyReportForm(GenerateDailyReportFormBusiness generateDailyReportFormBusiness)
        {
            GenerateDailyReportFormBusiness = generateDailyReportFormBusiness;
            InitializeComponent();
<<<<<<< HEAD
=======
        }

        private string GenerateDailyReport(DateOnly date)
        {
            List<Task> prSentTasks = MainWindow.TaskList.FindAll(task => task.IsPrSent(date));

            List<Task> mergedTasks = MainWindow.TaskList.FindAll(task => task.IsMerged(date));

            List<Task> inProgressTasks = MainWindow.TaskList.FindAll(task => task.IsInProgress(date));

            List<Task> reviewingTasks = MainWindow.TaskList.FindAll(task => task.IsInCodeReview(date));

            List<Task> todoTasks = MainWindow.TaskList.FindAll(task => task.IsToDo(date));

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
>>>>>>> 0e502141f256c07c2be5b5ff8b667f906c62e2c9
        }

        private void copyDailyReportButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Copied!", "Copied", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Clipboard.SetText(dailyReportTextBox.Text);
        }

        private void GenerateDailyReportForm_Load(object sender, EventArgs e)
        {
            dailyReportDatePicker.MaxDate = DateUtil.ToEndOfDay(DateUtil.Today());
<<<<<<< HEAD
            string dailyReport = GenerateDailyReportFormBusiness.GenerateDailyReport(MainWindow.TaskList, DateUtil.From(dailyReportDatePicker.Value));
=======
            string dailyReport = GenerateDailyReport(DateUtil.From(dailyReportDatePicker.Value));
>>>>>>> 0e502141f256c07c2be5b5ff8b667f906c62e2c9
            dailyReportTextBox.Text = dailyReport;
        }

        private void dailyReportDatePicker_ValueChanged(object sender, EventArgs e)
        {
<<<<<<< HEAD
            string dailyReport = GenerateDailyReportFormBusiness.GenerateDailyReport(MainWindow.TaskList, DateUtil.From(dailyReportDatePicker.Value));
            dailyReportTextBox.Text = dailyReport;
=======
            GenerateDailyReport(DateUtil.From(dailyReportDatePicker.Value));
>>>>>>> 0e502141f256c07c2be5b5ff8b667f906c62e2c9
        }
    }
}
