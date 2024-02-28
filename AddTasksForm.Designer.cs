namespace TManager
{
    partial class AddTasksForm
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
            taskIdLabel = new Label();
            taskNameLabel = new Label();
            deadlineLabel = new Label();
            taskIdTextBox = new TextBox();
            taskNameTextBox = new TextBox();
            deadlineDatePicker = new DateTimePicker();
            addTaskButton = new Button();
            cancelAddTaskButton = new Button();
            noteLabel = new Label();
            noteTextBox = new TextBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // taskIdLabel
            // 
            taskIdLabel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            taskIdLabel.AutoSize = true;
            taskIdLabel.Location = new Point(26, 38);
            taskIdLabel.Name = "taskIdLabel";
            taskIdLabel.Size = new Size(43, 15);
            taskIdLabel.TabIndex = 0;
            taskIdLabel.Text = "Task ID";
            // 
            // taskNameLabel
            // 
            taskNameLabel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            taskNameLabel.AutoSize = true;
            taskNameLabel.Location = new Point(26, 95);
            taskNameLabel.Name = "taskNameLabel";
            taskNameLabel.Size = new Size(62, 15);
            taskNameLabel.TabIndex = 1;
            taskNameLabel.Text = "Task name";
            // 
            // deadlineLabel
            // 
            deadlineLabel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            deadlineLabel.AutoSize = true;
            deadlineLabel.Location = new Point(26, 154);
            deadlineLabel.Name = "deadlineLabel";
            deadlineLabel.Size = new Size(53, 15);
            deadlineLabel.TabIndex = 2;
            deadlineLabel.Text = "Deadline";
            // 
            // taskIdTextBox
            // 
            taskIdTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            taskIdTextBox.Location = new Point(109, 30);
            taskIdTextBox.Name = "taskIdTextBox";
            taskIdTextBox.Size = new Size(564, 23);
            taskIdTextBox.TabIndex = 3;
            // 
            // taskNameTextBox
            // 
            taskNameTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            taskNameTextBox.Location = new Point(109, 87);
            taskNameTextBox.Name = "taskNameTextBox";
            taskNameTextBox.Size = new Size(564, 23);
            taskNameTextBox.TabIndex = 4;
            // 
            // deadlineDatePicker
            // 
            deadlineDatePicker.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            deadlineDatePicker.Location = new Point(109, 148);
            deadlineDatePicker.Name = "deadlineDatePicker";
            deadlineDatePicker.Size = new Size(419, 23);
            deadlineDatePicker.TabIndex = 5;
            deadlineDatePicker.ValueChanged += deadlineDatePicker_ValueChanged;
            // 
            // addTaskButton
            // 
            addTaskButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            addTaskButton.Location = new Point(112, 458);
            addTaskButton.Name = "addTaskButton";
            addTaskButton.Size = new Size(112, 30);
            addTaskButton.TabIndex = 6;
            addTaskButton.Text = "Add";
            addTaskButton.UseVisualStyleBackColor = true;
            addTaskButton.Click += addTaskButton_Click;
            // 
            // cancelAddTaskButton
            // 
            cancelAddTaskButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            cancelAddTaskButton.Location = new Point(467, 458);
            cancelAddTaskButton.Name = "cancelAddTaskButton";
            cancelAddTaskButton.Size = new Size(105, 31);
            cancelAddTaskButton.TabIndex = 7;
            cancelAddTaskButton.Text = "Cancel";
            cancelAddTaskButton.UseVisualStyleBackColor = true;
            // 
            // noteLabel
            // 
            noteLabel.AutoSize = true;
            noteLabel.Location = new Point(31, 217);
            noteLabel.Name = "noteLabel";
            noteLabel.Size = new Size(0, 15);
            noteLabel.TabIndex = 8;
            // 
            // noteTextBox
            // 
            noteTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            noteTextBox.Location = new Point(109, 209);
            noteTextBox.Multiline = true;
            noteTextBox.Name = "noteTextBox";
            noteTextBox.Size = new Size(564, 229);
            noteTextBox.TabIndex = 9;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(31, 217);
            label1.Name = "label1";
            label1.Size = new Size(33, 15);
            label1.TabIndex = 10;
            label1.Text = "Note";
            // 
            // AddTasksForm
            // 
            AcceptButton = addTaskButton;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = cancelAddTaskButton;
            ClientSize = new Size(708, 519);
            ControlBox = false;
            Controls.Add(label1);
            Controls.Add(noteTextBox);
            Controls.Add(noteLabel);
            Controls.Add(cancelAddTaskButton);
            Controls.Add(addTaskButton);
            Controls.Add(deadlineDatePicker);
            Controls.Add(taskNameTextBox);
            Controls.Add(taskIdTextBox);
            Controls.Add(deadlineLabel);
            Controls.Add(taskNameLabel);
            Controls.Add(taskIdLabel);
            Name = "AddTasksForm";
            Text = "Add Tasks";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label taskIdLabel;
        private Label taskNameLabel;
        private Label deadlineLabel;
        private TextBox taskIdTextBox;
        private TextBox taskNameTextBox;
        private DateTimePicker deadlineDatePicker;
        private Button addTaskButton;
        private Button cancelAddTaskButton;
        private Label noteLabel;
        private TextBox noteTextBox;
        private Label label1;
    }
}