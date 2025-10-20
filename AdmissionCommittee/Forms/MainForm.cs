using AdmissionCommittee.Forms;
using AdmissionCommittee.Models;
using System.Drawing;

namespace AdmissionCommittee
{
    public partial class MainForm : System.Windows.Forms.Form
    {
        public readonly List<StudentModel> items;
        public readonly BindingSource bindingSource = new();
        public MainForm()
        {
            float math, russian, computer;
            items = new List<StudentModel>();
            items.Add(new StudentModel()
            {
                id = Guid.NewGuid(),
                FullName = "Тест Тест Тест",
                Gender = Gender.Male,
                Birthday = DateOnly.Parse("11.11.2002"),
                EducationalForm = EducationalForm.FullTime,
                MathScores = math = 85f,
                PointsInRussianLanguage = russian = 80f,
                ComputerScienceScores = computer = 70f,
                TotalAmountOfPoints = math + russian + computer,
            });
            items.Add(new StudentModel()
            {
                id = Guid.NewGuid(),
                FullName = "Тест2 Тест2 Тест2",
                Gender = Gender.Male,
                Birthday = DateOnly.Parse("11.11.2002"),
                EducationalForm = EducationalForm.FullTime,
                MathScores = math = 15f,
                PointsInRussianLanguage = russian = 40f,
                ComputerScienceScores = computer = 30f,
                TotalAmountOfPoints = math + russian + computer,
            });
            InitializeComponent();
            SetStatistic();

            StudentDataGridView.AutoGenerateColumns = false;
            bindingSource.DataSource = items;
            StudentDataGridView.DataSource = bindingSource;

            ConfigureDataGridViewColumns();
        }

        private void StudentDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            if (e.RowIndex >= StudentDataGridView.Rows.Count) return;

            var row = StudentDataGridView.Rows[e.RowIndex];
            if (row.DataBoundItem == null) return;

            var col = StudentDataGridView.Columns[e.ColumnIndex];
            var student = (StudentModel)row.DataBoundItem;

            if (col.DataPropertyName == nameof(StudentModel.Gender))
            {
                switch (student.Gender)
                {
                    case Gender.Male:
                        e.Value = "Мужской";
                        break;
                    case Gender.Female:
                        e.Value = "Женский";
                        break;
                    default:
                        e.Value = string.Empty;
                        break;
                }
            }

            if (col.DataPropertyName == nameof(StudentModel.EducationalForm))
            {
                switch (student.EducationalForm)
                {
                    case EducationalForm.FullTime:
                        e.Value = "Очная";
                        break;
                    case EducationalForm.FullTimeAndPartTime:
                        e.Value = "Очно-заочная";
                        break;
                    case EducationalForm.Correspondence:
                        e.Value = "Заочная";
                        break;
                }

            }

        }

        private void StudentDataGridView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            if (e.RowIndex >= StudentDataGridView.Rows.Count) return;

            var row = StudentDataGridView.Rows[e.RowIndex];
            if (row.DataBoundItem == null) return;

            var col = StudentDataGridView.Columns[e.ColumnIndex];
            var colName = col.Name;

            if (colName != nameof(StudentModel.TotalAmountOfPoints))
            {
                e.Handled = false;
                return;
            }

            var student = (StudentModel)row.DataBoundItem;
            var graphics = e.Graphics;
            var rect = e.CellBounds;
            var totalPoints = 300;
            var padding = 2;
            var progressBarHeightReduction = 4;
            var width = rect.Width * (student.TotalAmountOfPoints / totalPoints);
            var targetRect = new Rectangle(rect.Left + padding, rect.Top + padding, (int)width, rect.Height - progressBarHeightReduction);

            e.PaintBackground(e.CellBounds, true);

            graphics?.FillRectangle(Brushes.Bisque, targetRect);
            graphics?.DrawRectangle(Pens.Gold, targetRect);

            var format = new StringFormat();
            format.LineAlignment = StringAlignment.Center;
            format.Alignment = StringAlignment.Center;

            graphics?.DrawString(student.TotalAmountOfPoints.ToString(), this.Font, Brushes.Black, rect, format);
            e.Handled = true;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            var applicants = new ApplicantsForm();
            if (applicants.ShowDialog(this) == DialogResult.OK)
            {
                items.Add(applicants.CurrentStudent);
                bindingSource.ResetBindings(false);
                SetStatistic();
            }
        }
        private void EditButton_Click(object sender, EventArgs e)
        {
            if (StudentDataGridView.SelectedRows.Count == 0)
            {
                return;
            }

            var student = (StudentModel)StudentDataGridView.SelectedRows[0].DataBoundItem;
            var applicants = new ApplicantsForm();

            if (applicants.ShowDialog(this) == DialogResult.OK)
            {
                var target = items.FirstOrDefault(x => x.id == applicants.CurrentStudent.id);
                if (target != null)
                {
                    target.FullName = applicants.CurrentStudent.FullName;
                    target.Gender = applicants.CurrentStudent.Gender;
                    target.Birthday = applicants.CurrentStudent.Birthday;
                    target.EducationalForm = applicants.CurrentStudent.EducationalForm;
                    target.MathScores = applicants.CurrentStudent.MathScores;
                    target.PointsInRussianLanguage = applicants.CurrentStudent.PointsInRussianLanguage;
                    target.ComputerScienceScores = applicants.CurrentStudent.ComputerScienceScores;
                    target.TotalAmountOfPoints = applicants.CurrentStudent.TotalAmountOfPoints;
                    bindingSource.ResetBindings(false);
                    SetStatistic();
                }
            }
        }
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if(StudentDataGridView.SelectedRows.Count == 0)
            {
                return;
            }

            var student = (StudentModel)StudentDataGridView.SelectedRows[0].DataBoundItem;
            var target = items.FirstOrDefault(x => x.id == student.id);

            if (target != null && 
                MessageBox.Show($"Вы действительно желаете удалить '{target.FullName}' ?",
                "Удаление студента",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question)==DialogResult.Yes) 
            { 
                items.Remove(target);
                bindingSource.ResetBindings(false);
                SetStatistic();
            }
        }
        private void SetStatistic()
        {
            NumberOfApplicantsStatusLabel.Text = $"Количество абитуриентов: {items.Count}";
            ScoreEnoughPointsStatusLabel.Text = $"набрали больше 150 баллов: {items.Where(x => x.TotalAmountOfPoints > 150).Count()}";
        }

        private void ConfigureDataGridViewColumns()
        {
            FullNameColumn.DataPropertyName = nameof(StudentModel.FullName);
            BirthdayColumn.DataPropertyName = nameof(StudentModel.Birthday);
            GenderColumn.DataPropertyName = nameof(StudentModel.Gender);
            EducationalFormColumn.DataPropertyName = nameof(StudentModel.EducationalForm);
            MathScoreColumn.DataPropertyName = nameof(StudentModel.MathScores);
            PointsInRussianLanguage.DataPropertyName = nameof(StudentModel.PointsInRussianLanguage);
            ComputerScienceScores.DataPropertyName = nameof(StudentModel.ComputerScienceScores);
            TotalAmountOfPoints.DataPropertyName = nameof(StudentModel.TotalAmountOfPoints);
        }
    }
}
