namespace TManager
{
    partial class EditTaskForm
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
            label1 = new Label();
            noteTextBox = new TextBox();
            noteLabel = new Label();
            cancelEditTaskButton = new Button();
            saveTaskButton = new Button();
            deadlineDatePicker = new DateTimePicker();
            taskNameTextBox = new TextBox();
            taskIdTextBox = new TextBox();
            deadlineLabel = new Label();
            taskNameLabel = new Label();
            taskIdLabel = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(77, 196);
            label1.Name = "label1";
            label1.Size = new Size(33, 15);
            label1.TabIndex = 21;
            label1.Text = "Note";
            // 
            // noteTextBox
            // 
            noteTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            noteTextBox.Location = new Point(160, 196);
            noteTextBox.Multiline = true;
            noteTextBox.Name = "noteTextBox";
            noteTextBox.Size = new Size(489, 270);
            noteTextBox.TabIndex = 20;
            // 
            // noteLabel
            // 
            noteLabel.AutoSize = true;
            noteLabel.Location = new Point(82, 196);
            noteLabel.Name = "noteLabel";
            noteLabel.Size = new Size(0, 15);
            noteLabel.TabIndex = 19;
            // 
            // cancelEditTaskButton
            // 
            cancelEditTaskButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            cancelEditTaskButton.Location = new Point(453, 482);
            cancelEditTaskButton.Name = "cancelEditTaskButton";
            cancelEditTaskButton.Size = new Size(105, 31);
            cancelEditTaskButton.TabIndex = 18;
            cancelEditTaskButton.Text = "Cancel";
            cancelEditTaskButton.UseVisualStyleBackColor = true;
            // 
            // saveTaskButton
            // 
            saveTaskButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            saveTaskButton.Location = new Point(173, 482);
            saveTaskButton.Name = "saveTaskButton";
            saveTaskButton.Size = new Size(112, 30);
            saveTaskButton.TabIndex = 17;
            saveTaskButton.Text = "Save";
            saveTaskButton.UseVisualStyleBackColor = true;
            saveTaskButton.Click += saveTaskButton_Click;
            // 
            // deadlineDatePicker
            // 
            deadlineDatePicker.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            deadlineDatePicker.Location = new Point(160, 139);
            deadlineDatePicker.Name = "deadlineDatePicker";
            deadlineDatePicker.Size = new Size(344, 23);
            deadlineDatePicker.TabIndex = 16;
            // 
            // taskNameTextBox
            // 
            taskNameTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            taskNameTextBox.Location = new Point(160, 82);
            taskNameTextBox.Name = "taskNameTextBox";
            taskNameTextBox.Size = new Size(489, 23);
            taskNameTextBox.TabIndex = 15;
            // 
            // taskIdTextBox
            // 
            taskIdTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            taskIdTextBox.Location = new Point(160, 25);
            taskIdTextBox.Name = "taskIdTextBox";
            taskIdTextBox.Size = new Size(489, 23);
            taskIdTextBox.TabIndex = 14;
            // 
            // deadlineLabel
            // 
            deadlineLabel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            deadlineLabel.AutoSize = true;
            deadlineLabel.Location = new Point(77, 145);
            deadlineLabel.Name = "deadlineLabel";
            deadlineLabel.Size = new Size(53, 15);
            deadlineLabel.TabIndex = 13;
            deadlineLabel.Text = "Deadline";
            // 
            // taskNameLabel
            // 
            taskNameLabel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            taskNameLabel.AutoSize = true;
            taskNameLabel.Location = new Point(77, 90);
            taskNameLabel.Name = "taskNameLabel";
            taskNameLabel.Size = new Size(62, 15);
            taskNameLabel.TabIndex = 12;
            taskNameLabel.Text = "Task name";
            // 
            // taskIdLabel
            // 
            taskIdLabel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            taskIdLabel.AutoSize = true;
            taskIdLabel.Location = new Point(77, 33);
            taskIdLabel.Name = "taskIdLabel";
            taskIdLabel.Size = new Size(43, 15);
            taskIdLabel.TabIndex = 11;
            taskIdLabel.Text = "Task ID";
            // 
            // EditTaskForm
            // 
            AcceptButton = saveTaskButton;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = cancelEditTaskButton;
            ClientSize = new Size(725, 525);
            Controls.Add(label1);
            Controls.Add(noteTextBox);
            Controls.Add(noteLabel);
            Controls.Add(cancelEditTaskButton);
            Controls.Add(saveTaskButton);
            Controls.Add(deadlineDatePicker);
            Controls.Add(taskNameTextBox);
            Controls.Add(taskIdTextBox);
            Controls.Add(deadlineLabel);
            Controls.Add(taskNameLabel);
            Controls.Add(taskIdLabel);
            Name = "EditTaskForm";
            Text = "Update Task";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox noteTextBox;
        private Label noteLabel;
        private Button cancelEditTaskButton;
        private Button saveTaskButton;
        private DateTimePicker deadlineDatePicker;
        private TextBox taskNameTextBox;
        private TextBox taskIdTextBox;
        private Label deadlineLabel;
        private Label taskNameLabel;
        private Label taskIdLabel;
    }
}