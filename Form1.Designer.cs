namespace NoteApp
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            NoteInput = new TextBox();
            NoteLabel = new Label();
            AddBtn = new Button();
            SaveBtn = new Button();
            DeleteBtn = new Button();
            TitleInput = new TextBox();
            TitleLabel = new Label();
            TableContent = new DataGridView();
            CompletedBox = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)TableContent).BeginInit();
            SuspendLayout();
            // 
            // NoteInput
            // 
            NoteInput.Location = new Point(708, 90);
            NoteInput.Multiline = true;
            NoteInput.Name = "NoteInput";
            NoteInput.Size = new Size(444, 288);
            NoteInput.TabIndex = 0;
            // 
            // NoteLabel
            // 
            NoteLabel.AutoSize = true;
            NoteLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            NoteLabel.Location = new Point(705, 67);
            NoteLabel.Name = "NoteLabel";
            NoteLabel.Size = new Size(48, 20);
            NoteLabel.TabIndex = 3;
            NoteLabel.Text = "Note:";
            // 
            // AddBtn
            // 
            AddBtn.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            AddBtn.Location = new Point(466, 335);
            AddBtn.Name = "AddBtn";
            AddBtn.Size = new Size(222, 43);
            AddBtn.TabIndex = 6;
            AddBtn.Text = "Add New";
            AddBtn.UseVisualStyleBackColor = true;
            AddBtn.Click += AddBtn_Click;
            // 
            // SaveBtn
            // 
            SaveBtn.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            SaveBtn.Location = new Point(9, 334);
            SaveBtn.Name = "SaveBtn";
            SaveBtn.Size = new Size(222, 43);
            SaveBtn.TabIndex = 7;
            SaveBtn.Text = "Save";
            SaveBtn.UseVisualStyleBackColor = true;
            SaveBtn.Click += SaveBtn_Click;
            // 
            // DeleteBtn
            // 
            DeleteBtn.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            DeleteBtn.Location = new Point(238, 336);
            DeleteBtn.Name = "DeleteBtn";
            DeleteBtn.Size = new Size(222, 41);
            DeleteBtn.TabIndex = 8;
            DeleteBtn.Text = "Delete";
            DeleteBtn.UseVisualStyleBackColor = true;
            DeleteBtn.Click += DeleteBtn_Click;
            // 
            // TitleInput
            // 
            TitleInput.Location = new Point(705, 36);
            TitleInput.Name = "TitleInput";
            TitleInput.Size = new Size(319, 27);
            TitleInput.TabIndex = 9;
            // 
            // TitleLabel
            // 
            TitleLabel.AutoSize = true;
            TitleLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            TitleLabel.Location = new Point(708, 14);
            TitleLabel.Name = "TitleLabel";
            TitleLabel.Size = new Size(44, 20);
            TitleLabel.TabIndex = 10;
            TitleLabel.Text = "Title:";
            // 
            // TableContent
            // 
            TableContent.AllowUserToAddRows = false;
            TableContent.AllowUserToDeleteRows = false;
            TableContent.AllowUserToResizeColumns = false;
            TableContent.AllowUserToResizeRows = false;
            TableContent.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            TableContent.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            TableContent.ColumnHeadersHeight = 29;
            TableContent.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Window;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            TableContent.DefaultCellStyle = dataGridViewCellStyle1;
            TableContent.Location = new Point(12, 13);
            TableContent.Margin = new Padding(3, 4, 3, 4);
            TableContent.Name = "TableContent";
            TableContent.ReadOnly = true;
            TableContent.RowHeadersVisible = false;
            TableContent.RowHeadersWidth = 51;
            TableContent.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            TableContent.RowTemplate.Height = 25;
            TableContent.RowTemplate.ReadOnly = true;
            TableContent.RowTemplate.Resizable = DataGridViewTriState.False;
            TableContent.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            TableContent.Size = new Size(679, 315);
            TableContent.TabIndex = 11;
            TableContent.CellDoubleClick += TableContent_CellDoubleClick;
            // 
            // CompletedBox
            // 
            CompletedBox.AutoSize = true;
            CompletedBox.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            CompletedBox.Location = new Point(1030, 39);
            CompletedBox.Name = "CompletedBox";
            CompletedBox.Size = new Size(107, 24);
            CompletedBox.TabIndex = 13;
            CompletedBox.Text = "Completed";
            CompletedBox.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1164, 392);
            Controls.Add(CompletedBox);
            Controls.Add(TableContent);
            Controls.Add(TitleLabel);
            Controls.Add(TitleInput);
            Controls.Add(DeleteBtn);
            Controls.Add(SaveBtn);
            Controls.Add(AddBtn);
            Controls.Add(NoteLabel);
            Controls.Add(NoteInput);
            Name = "MainForm";
            Text = "Note App";
            Load += MainForm_Load;
            ((System.ComponentModel.ISupportInitialize)TableContent).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox NoteInput;
        private Label TitleLabel;
        private Label NoteLabel;
        private Button AddBtn;
        private Button SaveBtn;
        private Button DeleteBtn;
        private TextBox TitleInput;
        private DataGridView TableContent;
        private CheckBox CompletedBox;
    }
}