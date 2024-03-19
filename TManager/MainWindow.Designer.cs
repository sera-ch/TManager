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
            ((System.ComponentModel.ISupportInitialize)taskListView).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // taskListView
            // 
            taskListView.AllowUserToAddRows = false;
            taskListView.AllowUserToDeleteRows = false;
            taskListView.AllowUserToResizeRows = false;
            taskListView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            taskListView.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            taskListView.Dock = DockStyle.Fill;
            taskListView.Location = new Point(0, 24);
            taskListView.Name = "taskListView";
            taskListView.ReadOnly = true;
            taskListView.Size = new Size(800, 426);
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
            registerToolStripMenuItem.Size = new Size(180, 22);
            registerToolStripMenuItem.Text = "Register";
            registerToolStripMenuItem.Click += registerToolStripMenuItem_Click;
            // 
            // switchUserToolStripMenuItem
            // 
            switchUserToolStripMenuItem.Name = "switchUserToolStripMenuItem";
            switchUserToolStripMenuItem.Size = new Size(180, 22);
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
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
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
    }
}