﻿namespace TManager
{
    partial class FullTaskListForm
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
            components = new System.ComponentModel.Container();
            fullTaskListView = new DataGridView();
            taskContextMenu = new ContextMenuStrip(components);
            addToolStripMenuItem = new ToolStripMenuItem();
            updateTaskMenuItem = new ToolStripMenuItem();
            changeTaskStatusMenuItem = new ToolStripMenuItem();
            changeStatusToInProgressItem = new ToolStripMenuItem();
            changeStatusToCodeReviewItem = new ToolStripMenuItem();
            changeStatusToMergedItem = new ToolStripMenuItem();
            changeStatusToClosedItem = new ToolStripMenuItem();
            changeStatusToDoneItem = new ToolStripMenuItem();
            deleteTaskMenuItem = new ToolStripMenuItem();
            reassignToolStripMenuItem = new ToolStripMenuItem();
            startWorkingButton = new Button();
            codeReviewButton = new Button();
            mergeButton = new Button();
            closeButton = new Button();
            doneButton = new Button();
            taskDeleteButton = new Button();
            SearchTextBox = new TextBox();
            SearchLabel = new Label();
            StatusComboBox = new ComboBox();
            StatusLabel = new Label();
            pageNumberTextBox = new NumericUpDown();
            toLastPageButton = new Button();
            toNextPageButton = new Button();
            toPreviousPageButton = new Button();
            ToFirstPageButton = new Button();
            totalCountLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)fullTaskListView).BeginInit();
            taskContextMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pageNumberTextBox).BeginInit();
            SuspendLayout();
            // 
            // fullTaskListView
            // 
            fullTaskListView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            fullTaskListView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            fullTaskListView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            fullTaskListView.ContextMenuStrip = taskContextMenu;
            fullTaskListView.Location = new Point(12, 52);
            fullTaskListView.MultiSelect = false;
            fullTaskListView.Name = "fullTaskListView";
            fullTaskListView.ReadOnly = true;
            fullTaskListView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            fullTaskListView.Size = new Size(1372, 610);
            fullTaskListView.TabIndex = 0;
            fullTaskListView.SelectionChanged += fullTaskListView_SelectionChanged;
            fullTaskListView.MouseDown += fullTaskListView_CellContentClick;
            // 
            // taskContextMenu
            // 
            taskContextMenu.Items.AddRange(new ToolStripItem[] { addToolStripMenuItem, updateTaskMenuItem, changeTaskStatusMenuItem, deleteTaskMenuItem, reassignToolStripMenuItem });
            taskContextMenu.Name = "taskContextMenu";
            taskContextMenu.Size = new Size(150, 114);
            // 
            // addToolStripMenuItem
            // 
            addToolStripMenuItem.Name = "addToolStripMenuItem";
            addToolStripMenuItem.Size = new Size(149, 22);
            addToolStripMenuItem.Text = "Add";
            addToolStripMenuItem.Click += addToolStripMenuItem_Click;
            // 
            // updateTaskMenuItem
            // 
            updateTaskMenuItem.Name = "updateTaskMenuItem";
            updateTaskMenuItem.Size = new Size(149, 22);
            updateTaskMenuItem.Text = "Update";
            updateTaskMenuItem.Click += updateTaskMenuItem_Click;
            // 
            // changeTaskStatusMenuItem
            // 
            changeTaskStatusMenuItem.DropDownItems.AddRange(new ToolStripItem[] { changeStatusToInProgressItem, changeStatusToCodeReviewItem, changeStatusToMergedItem, changeStatusToClosedItem, changeStatusToDoneItem });
            changeTaskStatusMenuItem.Name = "changeTaskStatusMenuItem";
            changeTaskStatusMenuItem.Size = new Size(149, 22);
            changeTaskStatusMenuItem.Text = "Change status";
            // 
            // changeStatusToInProgressItem
            // 
            changeStatusToInProgressItem.Name = "changeStatusToInProgressItem";
            changeStatusToInProgressItem.Size = new Size(150, 22);
            changeStatusToInProgressItem.Text = "IN_PROGRESS";
            changeStatusToInProgressItem.Click += changeStatusToInProgressItem_Click;
            // 
            // changeStatusToCodeReviewItem
            // 
            changeStatusToCodeReviewItem.Name = "changeStatusToCodeReviewItem";
            changeStatusToCodeReviewItem.Size = new Size(150, 22);
            changeStatusToCodeReviewItem.Text = "CODE_REVIEW";
            changeStatusToCodeReviewItem.Click += changeStatusToCodeReviewItem_Click;
            // 
            // changeStatusToMergedItem
            // 
            changeStatusToMergedItem.Name = "changeStatusToMergedItem";
            changeStatusToMergedItem.Size = new Size(150, 22);
            changeStatusToMergedItem.Text = "MERGED";
            changeStatusToMergedItem.Click += changeStatusToMergedItem_Click;
            // 
            // changeStatusToClosedItem
            // 
            changeStatusToClosedItem.Name = "changeStatusToClosedItem";
            changeStatusToClosedItem.Size = new Size(150, 22);
            changeStatusToClosedItem.Text = "CLOSED";
            changeStatusToClosedItem.Click += changeStatusToClosedItem_Click;
            // 
            // changeStatusToDoneItem
            // 
            changeStatusToDoneItem.Name = "changeStatusToDoneItem";
            changeStatusToDoneItem.Size = new Size(150, 22);
            changeStatusToDoneItem.Text = "DONE";
            changeStatusToDoneItem.Click += changeStatusToDoneItem_Click;
            // 
            // deleteTaskMenuItem
            // 
            deleteTaskMenuItem.Name = "deleteTaskMenuItem";
            deleteTaskMenuItem.Size = new Size(149, 22);
            deleteTaskMenuItem.Text = "Delete";
            deleteTaskMenuItem.Click += deleteTaskMenuItem_Click;
            // 
            // reassignToolStripMenuItem
            // 
            reassignToolStripMenuItem.Name = "reassignToolStripMenuItem";
            reassignToolStripMenuItem.Size = new Size(149, 22);
            reassignToolStripMenuItem.Text = "Reassign";
            // 
            // startWorkingButton
            // 
            startWorkingButton.Anchor = AnchorStyles.Bottom;
            startWorkingButton.Location = new Point(188, 732);
            startWorkingButton.Name = "startWorkingButton";
            startWorkingButton.Size = new Size(75, 23);
            startWorkingButton.TabIndex = 1;
            startWorkingButton.Text = "Start";
            startWorkingButton.UseVisualStyleBackColor = true;
            startWorkingButton.Click += startWorkingButton_Click;
            // 
            // codeReviewButton
            // 
            codeReviewButton.Anchor = AnchorStyles.Bottom;
            codeReviewButton.Location = new Point(361, 732);
            codeReviewButton.Name = "codeReviewButton";
            codeReviewButton.Size = new Size(75, 23);
            codeReviewButton.TabIndex = 2;
            codeReviewButton.Text = "Review";
            codeReviewButton.UseVisualStyleBackColor = true;
            codeReviewButton.Click += codeReviewButton_Click;
            // 
            // mergeButton
            // 
            mergeButton.Anchor = AnchorStyles.Bottom;
            mergeButton.Location = new Point(554, 732);
            mergeButton.Name = "mergeButton";
            mergeButton.Size = new Size(75, 23);
            mergeButton.TabIndex = 3;
            mergeButton.Text = "Merge";
            mergeButton.UseVisualStyleBackColor = true;
            mergeButton.Click += mergeButton_Click;
            // 
            // closeButton
            // 
            closeButton.Anchor = AnchorStyles.Bottom;
            closeButton.Location = new Point(732, 732);
            closeButton.Name = "closeButton";
            closeButton.Size = new Size(75, 23);
            closeButton.TabIndex = 4;
            closeButton.Text = "Close";
            closeButton.UseVisualStyleBackColor = true;
            closeButton.Click += closeButton_Click;
            // 
            // doneButton
            // 
            doneButton.Anchor = AnchorStyles.Bottom;
            doneButton.Location = new Point(910, 732);
            doneButton.Name = "doneButton";
            doneButton.Size = new Size(75, 23);
            doneButton.TabIndex = 5;
            doneButton.Text = "Done";
            doneButton.UseVisualStyleBackColor = true;
            doneButton.Click += doneButton_Click;
            // 
            // taskDeleteButton
            // 
            taskDeleteButton.Anchor = AnchorStyles.Bottom;
            taskDeleteButton.Location = new Point(1097, 732);
            taskDeleteButton.Name = "taskDeleteButton";
            taskDeleteButton.Size = new Size(75, 23);
            taskDeleteButton.TabIndex = 6;
            taskDeleteButton.Text = "Delete";
            taskDeleteButton.UseVisualStyleBackColor = true;
            taskDeleteButton.Click += taskDeleteButton_Click;
            // 
            // SearchTextBox
            // 
            SearchTextBox.Location = new Point(60, 12);
            SearchTextBox.Name = "SearchTextBox";
            SearchTextBox.Size = new Size(370, 23);
            SearchTextBox.TabIndex = 7;
            SearchTextBox.TextChanged += SearchTextBox_TextChanged;
            // 
            // SearchLabel
            // 
            SearchLabel.AutoSize = true;
            SearchLabel.Location = new Point(12, 15);
            SearchLabel.Name = "SearchLabel";
            SearchLabel.Size = new Size(42, 15);
            SearchLabel.TabIndex = 8;
            SearchLabel.Text = "Search";
            // 
            // StatusComboBox
            // 
            StatusComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            StatusComboBox.FormattingEnabled = true;
            StatusComboBox.Location = new Point(538, 12);
            StatusComboBox.Name = "StatusComboBox";
            StatusComboBox.Size = new Size(121, 23);
            StatusComboBox.TabIndex = 9;
            StatusComboBox.SelectedIndexChanged += StatusComboBox_SelectedIndexChanged;
            // 
            // StatusLabel
            // 
            StatusLabel.AutoSize = true;
            StatusLabel.Location = new Point(494, 15);
            StatusLabel.Name = "StatusLabel";
            StatusLabel.Size = new Size(39, 15);
            StatusLabel.TabIndex = 10;
            StatusLabel.Text = "Status";
            // 
            // pageNumberTextBox
            // 
            pageNumberTextBox.Anchor = AnchorStyles.Bottom;
            pageNumberTextBox.Location = new Point(643, 688);
            pageNumberTextBox.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            pageNumberTextBox.Name = "pageNumberTextBox";
            pageNumberTextBox.Size = new Size(56, 23);
            pageNumberTextBox.TabIndex = 15;
            // 
            // toLastPageButton
            // 
            toLastPageButton.Anchor = AnchorStyles.Bottom;
            toLastPageButton.Location = new Point(755, 682);
            toLastPageButton.Name = "toLastPageButton";
            toLastPageButton.Size = new Size(44, 30);
            toLastPageButton.TabIndex = 14;
            toLastPageButton.Text = ">>";
            toLastPageButton.UseVisualStyleBackColor = true;
            toLastPageButton.Click += toLastPageButton_Click;
            // 
            // toNextPageButton
            // 
            toNextPageButton.Anchor = AnchorStyles.Bottom;
            toNextPageButton.Location = new Point(705, 682);
            toNextPageButton.Name = "toNextPageButton";
            toNextPageButton.Size = new Size(44, 30);
            toNextPageButton.TabIndex = 13;
            toNextPageButton.Text = ">";
            toNextPageButton.UseVisualStyleBackColor = true;
            toNextPageButton.Click += toNextPageButton_Click;
            // 
            // toPreviousPageButton
            // 
            toPreviousPageButton.Anchor = AnchorStyles.Bottom;
            toPreviousPageButton.Enabled = false;
            toPreviousPageButton.Location = new Point(593, 682);
            toPreviousPageButton.Name = "toPreviousPageButton";
            toPreviousPageButton.Size = new Size(44, 30);
            toPreviousPageButton.TabIndex = 12;
            toPreviousPageButton.Text = "<";
            toPreviousPageButton.UseVisualStyleBackColor = true;
            toPreviousPageButton.Click += toPreviousPageButton_Click;
            // 
            // ToFirstPageButton
            // 
            ToFirstPageButton.Anchor = AnchorStyles.Bottom;
            ToFirstPageButton.Enabled = false;
            ToFirstPageButton.Location = new Point(543, 682);
            ToFirstPageButton.Name = "ToFirstPageButton";
            ToFirstPageButton.Size = new Size(44, 30);
            ToFirstPageButton.TabIndex = 11;
            ToFirstPageButton.Text = "<<";
            ToFirstPageButton.UseVisualStyleBackColor = true;
            ToFirstPageButton.Click += ToFirstPageButton_Click;
            // 
            // totalCountLabel
            // 
            totalCountLabel.Anchor = AnchorStyles.Bottom;
            totalCountLabel.AutoSize = true;
            totalCountLabel.Location = new Point(814, 697);
            totalCountLabel.Name = "totalCountLabel";
            totalCountLabel.Size = new Size(78, 15);
            totalCountLabel.TabIndex = 16;
            totalCountLabel.Text = "Total count: 0";
            // 
            // FullTaskListForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1396, 783);
            Controls.Add(totalCountLabel);
            Controls.Add(pageNumberTextBox);
            Controls.Add(toLastPageButton);
            Controls.Add(toNextPageButton);
            Controls.Add(toPreviousPageButton);
            Controls.Add(ToFirstPageButton);
            Controls.Add(StatusLabel);
            Controls.Add(StatusComboBox);
            Controls.Add(SearchLabel);
            Controls.Add(SearchTextBox);
            Controls.Add(taskDeleteButton);
            Controls.Add(doneButton);
            Controls.Add(closeButton);
            Controls.Add(mergeButton);
            Controls.Add(codeReviewButton);
            Controls.Add(startWorkingButton);
            Controls.Add(fullTaskListView);
            Name = "FullTaskListForm";
            Text = "Task List";
            Load += FullTaskListForm_Load;
            ((System.ComponentModel.ISupportInitialize)fullTaskListView).EndInit();
            taskContextMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pageNumberTextBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView fullTaskListView;
        private Button startWorkingButton;
        private Button codeReviewButton;
        private Button mergeButton;
        private Button closeButton;
        private Button doneButton;
        private ContextMenuStrip taskContextMenu;
        private ToolStripMenuItem updateTaskMenuItem;
        private ToolStripMenuItem changeTaskStatusMenuItem;
        private ToolStripMenuItem changeStatusToInProgressItem;
        private ToolStripMenuItem changeStatusToCodeReviewItem;
        private ToolStripMenuItem changeStatusToMergedItem;
        private ToolStripMenuItem changeStatusToClosedItem;
        private ToolStripMenuItem changeStatusToDoneItem;
        private Button taskDeleteButton;
        private ToolStripMenuItem deleteTaskMenuItem;
        private ToolStripMenuItem addToolStripMenuItem;
        private TextBox SearchTextBox;
        private Label SearchLabel;
        private ComboBox StatusComboBox;
        private Label StatusLabel;
        private ToolStripMenuItem reassignToolStripMenuItem;
        private NumericUpDown pageNumberTextBox;
        private Button toLastPageButton;
        private Button toNextPageButton;
        private Button toPreviousPageButton;
        private Button ToFirstPageButton;
        private Label totalCountLabel;
    }
}