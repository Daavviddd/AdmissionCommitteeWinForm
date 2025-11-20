namespace AdmissionCommittee.Forms
{
    partial class ApplicantsForm
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
            FullNameTextBox = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            GenderComboBox = new ComboBox();
            BirthdayDateTimePicker = new DateTimePicker();
            EducationFormComboBox = new ComboBox();
            MathNumericUpDown = new NumericUpDown();
            RussianNumericUpDown = new NumericUpDown();
            ComputerNumericUpDown = new NumericUpDown();
            TotalPointsTextBox = new TextBox();
            btnSave = new Button();
            btnClose = new Button();
            ((System.ComponentModel.ISupportInitialize)MathNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)RussianNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ComputerNumericUpDown).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(28, 35);
            label1.Name = "label1";
            label1.Size = new Size(45, 20);
            label1.TabIndex = 0;
            label1.Text = "ФИО:";
            // 
            // FullNameTextBox
            // 
            FullNameTextBox.Location = new Point(245, 32);
            FullNameTextBox.Name = "FullNameTextBox";
            FullNameTextBox.Size = new Size(376, 27);
            FullNameTextBox.TabIndex = 1;
            FullNameTextBox.KeyPress += FullNameTextBox_KeyPress;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(28, 87);
            label2.Name = "label2";
            label2.Size = new Size(40, 20);
            label2.TabIndex = 2;
            label2.Text = "Пол:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(28, 146);
            label3.Name = "label3";
            label3.Size = new Size(119, 20);
            label3.TabIndex = 3;
            label3.Text = "Дата рождения:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(28, 197);
            label4.Name = "label4";
            label4.Size = new Size(131, 20);
            label4.TabIndex = 4;
            label4.Text = "Форма обучения:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(28, 245);
            label5.Name = "label5";
            label5.Size = new Size(189, 20);
            label5.TabIndex = 5;
            label5.Text = "Баллы ЕГЭ по математике";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(28, 289);
            label6.Name = "label6";
            label6.Size = new Size(171, 20);
            label6.TabIndex = 6;
            label6.Text = "Баллы ЕГЭ по русскому";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(28, 342);
            label7.Name = "label7";
            label7.Size = new Size(202, 20);
            label7.TabIndex = 7;
            label7.Text = "Баллы ЕГЭ по информатике";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(28, 397);
            label8.Name = "label8";
            label8.Size = new Size(162, 20);
            label8.TabIndex = 8;
            label8.Text = "Общее кол-во баллов";
            // 
            // GenderComboBox
            // 
            GenderComboBox.FormattingEnabled = true;
            GenderComboBox.Location = new Point(245, 84);
            GenderComboBox.Name = "GenderComboBox";
            GenderComboBox.Size = new Size(376, 28);
            GenderComboBox.TabIndex = 9;
            GenderComboBox.DrawItem += GenderComboBox_DrawItem;
            //GenderComboBox.SelectedIndexChanged += GenderComboBox_SelectedIndexChanged;
            // 
            // BirthdayDateTimePicker
            // 
            BirthdayDateTimePicker.Location = new Point(245, 139);
            BirthdayDateTimePicker.Name = "BirthdayDateTimePicker";
            BirthdayDateTimePicker.Size = new Size(376, 27);
            BirthdayDateTimePicker.TabIndex = 10;
            //BirthdayDateTimePicker.ValueChanged += BirthdayDateTimePicker_ValueChanged;
            // 
            // EducationFormComboBox
            // 
            EducationFormComboBox.FormattingEnabled = true;
            EducationFormComboBox.Location = new Point(245, 189);
            EducationFormComboBox.Name = "EducationFormComboBox";
            EducationFormComboBox.Size = new Size(376, 28);
            EducationFormComboBox.TabIndex = 11;
            EducationFormComboBox.DrawItem += EducationFormComboBox_DrawItem;
            //EducationFormComboBox.SelectedIndexChanged += EducationFormComboBox_SelectedIndexChanged;
            // 
            // MathNumericUpDown
            // 
            MathNumericUpDown.Location = new Point(245, 243);
            MathNumericUpDown.Name = "MathNumericUpDown";
            MathNumericUpDown.Size = new Size(376, 27);
            MathNumericUpDown.TabIndex = 12;
            // 
            // RussianNumericUpDown
            // 
            RussianNumericUpDown.Location = new Point(245, 287);
            RussianNumericUpDown.Name = "RussianNumericUpDown";
            RussianNumericUpDown.Size = new Size(376, 27);
            RussianNumericUpDown.TabIndex = 13;
            // 
            // ComputerNumericUpDown
            // 
            ComputerNumericUpDown.Location = new Point(245, 335);
            ComputerNumericUpDown.Name = "ComputerNumericUpDown";
            ComputerNumericUpDown.Size = new Size(376, 27);
            ComputerNumericUpDown.TabIndex = 14;
            // 
            // TotalPointsTextBox
            // 
            TotalPointsTextBox.Location = new Point(245, 390);
            TotalPointsTextBox.Name = "TotalPointsTextBox";
            TotalPointsTextBox.ReadOnly = true;
            TotalPointsTextBox.Size = new Size(376, 27);
            TotalPointsTextBox.TabIndex = 15;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(142, 505);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(140, 29);
            btnSave.TabIndex = 16;
            btnSave.Text = "Сохранить";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(288, 505);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(140, 29);
            btnClose.TabIndex = 17;
            btnClose.Text = "Отмена";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // ApplicantsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(672, 559);
            Controls.Add(btnClose);
            Controls.Add(btnSave);
            Controls.Add(TotalPointsTextBox);
            Controls.Add(ComputerNumericUpDown);
            Controls.Add(RussianNumericUpDown);
            Controls.Add(MathNumericUpDown);
            Controls.Add(EducationFormComboBox);
            Controls.Add(BirthdayDateTimePicker);
            Controls.Add(GenderComboBox);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(FullNameTextBox);
            Controls.Add(label1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ApplicantsForm";
            Text = "ApplicantsForm";
            //FormClosing += ApplicantsForm_FormClosing;
            ((System.ComponentModel.ISupportInitialize)MathNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)RussianNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)ComputerNumericUpDown).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox FullNameTextBox;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private ComboBox GenderComboBox;
        private DateTimePicker BirthdayDateTimePicker;
        private ComboBox EducationFormComboBox;
        private NumericUpDown MathNumericUpDown;
        private NumericUpDown RussianNumericUpDown;
        private NumericUpDown ComputerNumericUpDown;
        private TextBox TotalPointsTextBox;
        private Button btnSave;
        private Button btnClose;
    }
}