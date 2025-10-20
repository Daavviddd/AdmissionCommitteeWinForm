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
            textBox1 = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            comboBox1 = new ComboBox();
            dateTimePicker1 = new DateTimePicker();
            comboBox2 = new ComboBox();
            numericUpDown1 = new NumericUpDown();
            numericUpDown2 = new NumericUpDown();
            numericUpDown3 = new NumericUpDown();
            textBox2 = new TextBox();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown3).BeginInit();
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
            // textBox1
            // 
            textBox1.Location = new Point(245, 32);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(376, 27);
            textBox1.TabIndex = 1;
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
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(245, 84);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(376, 28);
            comboBox1.TabIndex = 9;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(245, 139);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(376, 27);
            dateTimePicker1.TabIndex = 10;
            dateTimePicker1.ValueChanged += dateTimePicker1_ValueChanged;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(245, 189);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(376, 28);
            comboBox2.TabIndex = 11;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(245, 243);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(376, 27);
            numericUpDown1.TabIndex = 12;
            // 
            // numericUpDown2
            // 
            numericUpDown2.Location = new Point(245, 287);
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.Size = new Size(376, 27);
            numericUpDown2.TabIndex = 13;
            // 
            // numericUpDown3
            // 
            numericUpDown3.Location = new Point(245, 335);
            numericUpDown3.Name = "numericUpDown3";
            numericUpDown3.Size = new Size(376, 27);
            numericUpDown3.TabIndex = 14;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(245, 390);
            textBox2.Name = "textBox2";
            textBox2.ReadOnly = true;
            textBox2.Size = new Size(376, 27);
            textBox2.TabIndex = 15;
            // 
            // ApplicantsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(633, 559);
            Controls.Add(textBox2);
            Controls.Add(numericUpDown3);
            Controls.Add(numericUpDown2);
            Controls.Add(numericUpDown1);
            Controls.Add(comboBox2);
            Controls.Add(dateTimePicker1);
            Controls.Add(comboBox1);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(textBox1);
            Controls.Add(label1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ApplicantsForm";
            Text = "ApplicantsForm";
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBox1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private ComboBox comboBox1;
        private DateTimePicker dateTimePicker1;
        private ComboBox comboBox2;
        private NumericUpDown numericUpDown1;
        private NumericUpDown numericUpDown2;
        private NumericUpDown numericUpDown3;
        private TextBox textBox2;
    }
}