using TManager.business;
using TManager.util;

namespace TManager
{
    public partial class GenerateDailyReportForm : Form
    {
        private GenerateDailyReportFormBusiness GenerateDailyReportFormBusiness;
        public GenerateDailyReportForm(GenerateDailyReportFormBusiness generateDailyReportFormBusiness)
        {
            GenerateDailyReportFormBusiness = generateDailyReportFormBusiness;
            InitializeComponent();
        }

        private void copyDailyReportButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Copied!", "Copied", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Clipboard.SetText(dailyReportTextBox.Text);
        }

        private void GenerateDailyReportForm_Load(object sender, EventArgs e)
        {
            dailyReportDatePicker.MaxDate = DateUtil.ToEndOfDay(DateUtil.Today());
            string dailyReport = GenerateDailyReportFormBusiness.GenerateDailyReport(MainWindow.User.Id, DateUtil.From(dailyReportDatePicker.Value));
            dailyReportTextBox.Text = dailyReport;
        }

        private void dailyReportDatePicker_ValueChanged(object sender, EventArgs e)
        {
            string dailyReport = GenerateDailyReportFormBusiness.GenerateDailyReport(MainWindow.User.Id, DateUtil.From(dailyReportDatePicker.Value));
            dailyReportTextBox.Text = dailyReport;
        }
    }
}
