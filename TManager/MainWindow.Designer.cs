namespace TManager
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            taskListView = new DataGridView();
            menuStrip1 = new MenuStrip();
            userToolStripMenuItem = new ToolStripMenuItem();
            registerToolStripMenuItem = new ToolStripMenuItem();
            switchUserToolStripMenuItem = new ToolStripMenuItem();
            taskToolStripMenuItem = new ToolStripMenuItem();
            taskListToolStripMenuItem = new ToolStripMenuItem();
            addTaskToolStripMenuItem = new ToolStripMenuItem();
            reportToolStripMenuItem = new ToolStripMenuItem();
            dailyReportToolStripMenuItem = new ToolStripMenuItem();
            ToFirstPageButton = new Button();
            toPreviousPageButton = new Button();
            toNextPageButton = new Button();
            toLastPageButton = new Button();
            pageNumberTextBox = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)taskListView).BeginInit();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pageNumberTextBox).BeginInit();
            SuspendLayout();
            // 
            // taskListView
            // 
            taskListView.AllowUserToAddRows = false;
            taskListView.AllowUserToDeleteRows = false;
            taskListView.AllowUserToResizeRows = false;
            taskListView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            taskListView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            taskListView.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            taskListView.Location = new Point(12, 24);
            taskListView.Name = "taskListView";
            taskListView.ReadOnly = true;
            taskListView.Size = new Size(776, 321);
            taskListView.TabIndex = 0;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { userToolStripMenuItem, taskToolStripMenuItem, reportToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // userToolStripMenuItem
            // 
            userToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { registerToolStripMenuItem, switchUserToolStripMenuItem });
            userToolStripMenuItem.Name = "userToolStripMenuItem";
            userToolStripMenuItem.Size = new Size(42, 20);
            userToolStripMenuItem.Text = "User";
            // 
            // registerToolStripMenuItem
            // 
            registerToolStripMenuItem.Name = "registerToolStripMenuItem";
            registerToolStripMenuItem.Size = new Size(134, 22);
            registerToolStripMenuItem.Text = "Register";
            registerToolStripMenuItem.Click += registerToolStripMenuItem_Click;
            // 
            // switchUserToolStripMenuItem
            // 
            switchUserToolStripMenuItem.Name = "switchUserToolStripMenuItem";
            switchUserToolStripMenuItem.Size = new Size(134, 22);
            switchUserToolStripMenuItem.Text = "Switch user";
            switchUserToolStripMenuItem.Click += switchUserToolStripMenuItem_Click;
            // 
            // taskToolStripMenuItem
            // 
            taskToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { taskListToolStripMenuItem, addTaskToolStripMenuItem });
            taskToolStripMenuItem.Name = "taskToolStripMenuItem";
            taskToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.T;
            taskToolStripMenuItem.Size = new Size(41, 20);
            taskToolStripMenuItem.Text = "Task";
            // 
            // taskListToolStripMenuItem
            // 
            taskListToolStripMenuItem.Name = "taskListToolStripMenuItem";
            taskListToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.L;
            taskListToolStripMenuItem.ShowShortcutKeys = false;
            taskListToolStripMenuItem.Size = new Size(113, 22);
            taskListToolStripMenuItem.Text = "Task list";
            taskListToolStripMenuItem.Click += taskListToolStripMenuItem_Click;
            // 
            // addTaskToolStripMenuItem
            // 
            addTaskToolStripMenuItem.Name = "addTaskToolStripMenuItem";
            addTaskToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.A;
            addTaskToolStripMenuItem.ShowShortcutKeys = false;
            addTaskToolStripMenuItem.Size = new Size(113, 22);
            addTaskToolStripMenuItem.Text = "Add task";
            addTaskToolStripMenuItem.Click += addTaskToolStripMenuItem_Click;
            // 
            // reportToolStripMenuItem
            // 
            reportToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { dailyReportToolStripMenuItem });
            reportToolStripMenuItem.Name = "reportToolStripMenuItem";
            reportToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.R;
            reportToolStripMenuItem.Size = new Size(54, 20);
            reportToolStripMenuItem.Text = "Report";
            // 
            // dailyReportToolStripMenuItem
            // 
            dailyReportToolStripMenuItem.Name = "dailyReportToolStripMenuItem";
            dailyReportToolStripMenuItem.Size = new Size(135, 22);
            dailyReportToolStripMenuItem.Text = "Daily report";
            dailyReportToolStripMenuItem.Click += dailyReportToolStripMenuItem_Click;
            // 
            // ToFirstPageButton
            // 
            ToFirstPageButton.Anchor = AnchorStyles.Bottom;
            ToFirstPageButton.Enabled = false;
            ToFirstPageButton.Location = new Point(262, 351);
            ToFirstPageButton.Name = "ToFirstPageButton";
            ToFirstPageButton.Size = new Size(44, 30);
            ToFirstPageButton.TabIndex = 2;
            ToFirstPageButton.Text = "<<";
            ToFirstPageButton.UseVisualStyleBackColor = true;
            ToFirstPageButton.Click += ToFirstPageButton_Click;
            // 
            // toPreviousPageButton
            // 
            toPreviousPageButton.Anchor = AnchorStyles.Bottom;
            toPreviousPageButton.Enabled = false;
            toPreviousPageButton.Location = new Point(312, 351);
            toPreviousPageButton.Name = "toPreviousPageButton";
            toPreviousPageButton.Size = new Size(44, 30);
            toPreviousPageButton.TabIndex = 3;
            toPreviousPageButton.Text = "<";
            toPreviousPageButton.UseVisualStyleBackColor = true;
            toPreviousPageButton.Click += toPreviousPageButton_Click;
            // 
            // toNextPageButton
            // 
            toNextPageButton.Anchor = AnchorStyles.Bottom;
            toNextPageButton.Location = new Point(424, 351);
            toNextPageButton.Name = "toNextPageButton";
            toNextPageButton.Size = new Size(44, 30);
            toNextPageButton.TabIndex = 4;
            toNextPageButton.Text = ">";
            toNextPageButton.UseVisualStyleBackColor = true;
            toNextPageButton.Click += toNextPageButton_Click;
            // 
            // toLastPageButton
            // 
            toLastPageButton.Anchor = AnchorStyles.Bottom;
            toLastPageButton.Location = new Point(474, 351);
            toLastPageButton.Name = "toLastPageButton";
            toLastPageButton.Size = new Size(44, 30);
            toLastPageButton.TabIndex = 5;
            toLastPageButton.Text = ">>";
            toLastPageButton.UseVisualStyleBackColor = true;
            toLastPageButton.Click += toLastPageButton_Click;
            // 
            // pageNumberTextBox
            // 
            pageNumberTextBox.Anchor = AnchorStyles.Bottom;
            pageNumberTextBox.Location = new Point(362, 357);
            pageNumberTextBox.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            pageNumberTextBox.Name = "pageNumberTextBox";
            pageNumberTextBox.Size = new Size(56, 23);
            pageNumberTextBox.TabIndex = 6;
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 393);
            Controls.Add(pageNumberTextBox);
            Controls.Add(toLastPageButton);
            Controls.Add(toNextPageButton);
            Controls.Add(toPreviousPageButton);
            Controls.Add(ToFirstPageButton);
            Controls.Add(taskListView);
            Controls.Add(menuStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Name = "MainWindow";
            Text = "TManager";
            WindowState = FormWindowState.Maximized;
            Load += MainWindow_Load;
            ((System.ComponentModel.ISupportInitialize)taskListView).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pageNumberTextBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView taskListView;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem taskToolStripMenuItem;
        private ToolStripMenuItem taskListToolStripMenuItem;
        private ToolStripMenuItem addTaskToolStripMenuItem;
        private ToolStripMenuItem reportToolStripMenuItem;
        private ToolStripMenuItem dailyReportToolStripMenuItem;
        private ToolStripMenuItem userToolStripMenuItem;
        private ToolStripMenuItem registerToolStripMenuItem;
        private ToolStripMenuItem switchUserToolStripMenuItem;
        private Button ToFirstPageButton;
        private Button toPreviousPageButton;
        private Button toNextPageButton;
        private Button toLastPageButton;
        private NumericUpDown pageNumberTextBox;
    }
}