namespace TManager
{
    partial class GenerateDailyReportForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dailyReportTextBox = new RichTextBox();
            copyDailyReportButton = new Button();
            exitDailyReportButton = new Button();
            dailyReportDateLabel = new Label();
            dailyReportDatePicker = new DateTimePicker();
            SuspendLayout();
            // 
            // dailyReportTextBox
            // 
            dailyReportTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dailyReportTextBox.Location = new Point(12, 57);
            dailyReportTextBox.Name = "dailyReportTextBox";
            dailyReportTextBox.Size = new Size(776, 300);
            dailyReportTextBox.TabIndex = 0;
            dailyReportTextBox.Text = "";
            // 
            // copyDailyReportButton
            // 
            copyDailyReportButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            copyDailyReportButton.Location = new Point(238, 395);
            copyDailyReportButton.Name = "copyDailyReportButton";
            copyDailyReportButton.Size = new Size(75, 23);
            copyDailyReportButton.TabIndex = 1;
            copyDailyReportButton.Text = "Copy";
            copyDailyReportButton.UseVisualStyleBackColor = true;
            copyDailyReportButton.Click += copyDailyReportButton_Click;
            // 
            // exitDailyReportButton
            // 
            exitDailyReportButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            exitDailyReportButton.Location = new Point(474, 395);
            exitDailyReportButton.Name = "exitDailyReportButton";
            exitDailyReportButton.Size = new Size(75, 23);
            exitDailyReportButton.TabIndex = 2;
            exitDailyReportButton.Text = "Close";
            exitDailyReportButton.UseVisualStyleBackColor = true;
            // 
            // dailyReportDateLabel
            // 
            dailyReportDateLabel.AutoSize = true;
            dailyReportDateLabel.Location = new Point(12, 20);
            dailyReportDateLabel.Name = "dailyReportDateLabel";
            dailyReportDateLabel.Size = new Size(82, 15);
            dailyReportDateLabel.TabIndex = 3;
            dailyReportDateLabel.Text = "Report for day";
            // 
            // dailyReportDatePicker
            // 
            dailyReportDatePicker.Location = new Point(100, 14);
            dailyReportDatePicker.Name = "dailyReportDatePicker";
            dailyReportDatePicker.Size = new Size(200, 23);
            dailyReportDatePicker.TabIndex = 4;
            dailyReportDatePicker.ValueChanged += dailyReportDatePicker_ValueChanged;
            // 
            // GenerateDailyReportForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = exitDailyReportButton;
            ClientSize = new Size(800, 450);
            ControlBox = false;
            Controls.Add(dailyReportDatePicker);
            Controls.Add(dailyReportDateLabel);
            Controls.Add(exitDailyReportButton);
            Controls.Add(copyDailyReportButton);
            Controls.Add(dailyReportTextBox);
            Name = "GenerateDailyReportForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Generate Daily Report";
            Load += GenerateDailyReportForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox dailyReportTextBox;
        private Button copyDailyReportButton;
        private Button exitDailyReportButton;
        private Label dailyReportDateLabel;
        private DateTimePicker dailyReportDatePicker;
    }
}