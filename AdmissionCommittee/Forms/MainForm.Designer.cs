namespace AdmissionCommittee
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            MenuToolStrip = new ToolStrip();
            AddButton = new ToolStripButton();
            EditButton = new ToolStripButton();
            DeleteButton = new ToolStripButton();
            InfoStatusStrip = new StatusStrip();
            NumberOfApplicantsStatusLabel = new ToolStripStatusLabel();
            ScoreEnoughPointsStatusLabel = new ToolStripStatusLabel();
            StudentDataGridView = new DataGridView();
            FullNameColumn = new DataGridViewTextBoxColumn();
            BirthdayColumn = new DataGridViewTextBoxColumn();
            GenderColumn = new DataGridViewTextBoxColumn();
            EducationalFormColumn = new DataGridViewTextBoxColumn();
            MathScoreColumn = new DataGridViewTextBoxColumn();
            PointsInRussianLanguage = new DataGridViewTextBoxColumn();
            ComputerScienceScores = new DataGridViewTextBoxColumn();
            TotalAmountOfPoints = new DataGridViewTextBoxColumn();
            MenuToolStrip.SuspendLayout();
            InfoStatusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)StudentDataGridView).BeginInit();
            SuspendLayout();
            // 
            // MenuToolStrip
            // 
            MenuToolStrip.ImageScalingSize = new Size(20, 20);
            MenuToolStrip.Items.AddRange(new ToolStripItem[] { AddButton, EditButton, DeleteButton });
            MenuToolStrip.Location = new Point(0, 0);
            MenuToolStrip.Name = "MenuToolStrip";
            MenuToolStrip.Size = new Size(999, 27);
            MenuToolStrip.TabIndex = 0;
            MenuToolStrip.Text = "toolStrip1";
            // 
            // AddButton
            // 
            AddButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            AddButton.Image = (Image)resources.GetObject("AddButton.Image");
            AddButton.ImageTransparentColor = Color.Magenta;
            AddButton.Name = "AddButton";
            AddButton.Size = new Size(29, 24);
            AddButton.Text = "добавление";
            AddButton.Click += AddButton_Click;
            // 
            // EditButton
            // 
            EditButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            EditButton.Image = (Image)resources.GetObject("EditButton.Image");
            EditButton.ImageTransparentColor = Color.Magenta;
            EditButton.Name = "EditButton";
            EditButton.Size = new Size(29, 24);
            EditButton.Text = "Редактирование";
            EditButton.Click += EditButton_Click;
            // 
            // DeleteButton
            // 
            DeleteButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            DeleteButton.Image = (Image)resources.GetObject("DeleteButton.Image");
            DeleteButton.ImageTransparentColor = Color.Magenta;
            DeleteButton.Name = "DeleteButton";
            DeleteButton.Size = new Size(29, 24);
            DeleteButton.Text = "Удаление";
            DeleteButton.Click += DeleteButton_Click;
            // 
            // InfoStatusStrip
            // 
            InfoStatusStrip.ImageScalingSize = new Size(20, 20);
            InfoStatusStrip.Items.AddRange(new ToolStripItem[] { NumberOfApplicantsStatusLabel, ScoreEnoughPointsStatusLabel });
            InfoStatusStrip.Location = new Point(0, 446);
            InfoStatusStrip.Name = "InfoStatusStrip";
            InfoStatusStrip.Size = new Size(999, 26);
            InfoStatusStrip.TabIndex = 1;
            InfoStatusStrip.Text = "statusStrip1";
            // 
            // NumberOfApplicantsStatusLabel
            // 
            NumberOfApplicantsStatusLabel.Name = "NumberOfApplicantsStatusLabel";
            NumberOfApplicantsStatusLabel.Size = new Size(204, 20);
            NumberOfApplicantsStatusLabel.Text = "количество абитуриентов: 0";
            // 
            // ScoreEnoughPointsStatusLabel
            // 
            ScoreEnoughPointsStatusLabel.Name = "ScoreEnoughPointsStatusLabel";
            ScoreEnoughPointsStatusLabel.Size = new Size(224, 20);
            ScoreEnoughPointsStatusLabel.Text = "набрали больше 150 баллов: 0";
            // 
            // StudentDataGridView
            // 
            StudentDataGridView.AllowUserToAddRows = false;
            StudentDataGridView.AllowUserToDeleteRows = false;
            StudentDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            StudentDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            StudentDataGridView.Columns.AddRange(new DataGridViewColumn[] { FullNameColumn, BirthdayColumn, GenderColumn, EducationalFormColumn, MathScoreColumn, PointsInRussianLanguage, ComputerScienceScores, TotalAmountOfPoints });
            StudentDataGridView.Dock = DockStyle.Fill;
            StudentDataGridView.Location = new Point(0, 27);
            StudentDataGridView.Name = "StudentDataGridView";
            StudentDataGridView.ReadOnly = true;
            StudentDataGridView.RowHeadersWidth = 51;
            StudentDataGridView.Size = new Size(999, 419);
            StudentDataGridView.TabIndex = 2;
            StudentDataGridView.CellFormatting += StudentDataGridView_CellFormatting;
            StudentDataGridView.CellPainting += StudentDataGridView_CellPainting;
            // 
            // FullNameColumn
            // 
            FullNameColumn.HeaderText = "ФИО";
            FullNameColumn.MinimumWidth = 6;
            FullNameColumn.Name = "FullNameColumn";
            FullNameColumn.ReadOnly = true;
            // 
            // BirthdayColumn
            // 
            BirthdayColumn.HeaderText = "Дата рождения";
            BirthdayColumn.MinimumWidth = 6;
            BirthdayColumn.Name = "BirthdayColumn";
            BirthdayColumn.ReadOnly = true;
            // 
            // GenderColumn
            // 
            GenderColumn.HeaderText = "Пол";
            GenderColumn.MinimumWidth = 6;
            GenderColumn.Name = "GenderColumn";
            GenderColumn.ReadOnly = true;
            // 
            // EducationalFormColumn
            // 
            EducationalFormColumn.HeaderText = "Форма обучения";
            EducationalFormColumn.MinimumWidth = 6;
            EducationalFormColumn.Name = "EducationalFormColumn";
            EducationalFormColumn.ReadOnly = true;
            // 
            // MathScoreColumn
            // 
            MathScoreColumn.HeaderText = "Баллы по математике";
            MathScoreColumn.MinimumWidth = 6;
            MathScoreColumn.Name = "MathScoreColumn";
            MathScoreColumn.ReadOnly = true;
            // 
            // PointsInRussianLanguage
            // 
            PointsInRussianLanguage.HeaderText = "Баллы по русскому языку";
            PointsInRussianLanguage.MinimumWidth = 6;
            PointsInRussianLanguage.Name = "PointsInRussianLanguage";
            PointsInRussianLanguage.ReadOnly = true;
            // 
            // ComputerScienceScores
            // 
            ComputerScienceScores.HeaderText = "Баллы по информатике";
            ComputerScienceScores.MinimumWidth = 6;
            ComputerScienceScores.Name = "ComputerScienceScores";
            ComputerScienceScores.ReadOnly = true;
            // 
            // TotalAmountOfPoints
            // 
            TotalAmountOfPoints.HeaderText = "Общее кол-во балов";
            TotalAmountOfPoints.MinimumWidth = 6;
            TotalAmountOfPoints.Name = "TotalAmountOfPoints";
            TotalAmountOfPoints.ReadOnly = true;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(999, 472);
            Controls.Add(StudentDataGridView);
            Controls.Add(InfoStatusStrip);
            Controls.Add(MenuToolStrip);
            Name = "MainForm";
            Text = "Form1";
            MenuToolStrip.ResumeLayout(false);
            MenuToolStrip.PerformLayout();
            InfoStatusStrip.ResumeLayout(false);
            InfoStatusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)StudentDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip MenuToolStrip;
        private ToolStripButton AddButton;
        private ToolStripButton EditButton;
        private StatusStrip InfoStatusStrip;
        private DataGridView StudentDataGridView;
        private ToolStripStatusLabel NumberOfApplicantsStatusLabel;
        private ToolStripStatusLabel ScoreEnoughPointsStatusLabel;
        private DataGridViewTextBoxColumn FullNameColumn;
        private DataGridViewTextBoxColumn BirthdayColumn;
        private DataGridViewTextBoxColumn GenderColumn;
        private DataGridViewTextBoxColumn EducationalFormColumn;
        private DataGridViewTextBoxColumn MathScoreColumn;
        private DataGridViewTextBoxColumn PointsInRussianLanguage;
        private DataGridViewTextBoxColumn ComputerScienceScores;
        private DataGridViewTextBoxColumn TotalAmountOfPoints;
        private ToolStripButton DeleteButton;
    }
}
