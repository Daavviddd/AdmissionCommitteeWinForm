using AdmissionCommittee.Contracts;
using AdmissionCommittee.Forms;
using AdmissionCommittee.Models;

namespace AdmissionCommittee
{
    /// <summary>
    /// Главная форма приложения "Приемная комиссия" для управления списком студентов
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// Список студентов
        /// </summary>
        public readonly List<Student> items;

        /// <summary>
        /// Источник данных для DataGridView
        /// </summary>
        public readonly BindingSource bindingSource = new();

        private readonly IStudentService iStudentService;

        /// <summary>
        /// Конструктор главной формы
        /// </summary>
        public MainForm(IStudentService studentService)
        {
            items = new List<Student>();
            items.Add(new Student()
            {
                Id = Guid.NewGuid(),
                FullName = "Тест Тест Тест",
                Gender = Gender.Male,
                Birthday = new DateTime(2002, 11, 11),
                EducationalForm = EducationalForm.FullTime,
                MathScores = 85f,
                PointsInRussianLanguage = 80f,
                ComputerScienceScores = 70f,
            });
            items.Add(new Student()
            {
                Id = Guid.NewGuid(),
                FullName = "Тест2 Тест2 Тест2",
                Gender = Gender.Male,
                Birthday = new DateTime(2003, 11, 12),
                EducationalForm = EducationalForm.FullTime,
                MathScores = 15f,
                PointsInRussianLanguage = 40f,
                ComputerScienceScores = 30f,
            });
            iStudentService = studentService;
            InitializeComponent();

            var students = iStudentService.GetAllStudentsAsync();

            SetStatistic();

            StudentDataGridView.AutoGenerateColumns = false;
            bindingSource.DataSource = items;
            StudentDataGridView.DataSource = bindingSource;

            ConfigureDataGridViewColumns();
        }

        private void StudentDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var col = StudentDataGridView.Columns[e.ColumnIndex];

            if (!(StudentDataGridView.Rows[e.RowIndex].DataBoundItem is Student student))
            {
                return;
            }

            if (col.DataPropertyName == nameof(Student.Gender))
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

            if (col.DataPropertyName == nameof(Student.EducationalForm))
            {
                switch (student.EducationalForm)
                {
                    case EducationalForm.FullTime:
                        e.Value = "Очная";
                        break;
                    case EducationalForm.FullTimeAndPartTime:
                        e.Value = "Очно-заочная";
                        break;
                    case EducationalForm.CorrespondenceEducation:
                        e.Value = "Заочная";
                        break;
                }

            }

        }

        private void StudentDataGridView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            var totalPoints = ValidationConstants.MaxTotalScore;
            var padding = ValidationConstants.ProgressBarPadding;
            var progressBarHeightReduction = ValidationConstants.ProgressBarHeightReduction;

            if (e.ColumnIndex < 0 || e.RowIndex < 0)
            {
                return;
            }

            var col = StudentDataGridView.Columns[e.ColumnIndex];
            var colName = col.Name;

            if (colName != nameof(Student.TotalAmountOfPoints))
            {
                e.Handled = false;
                return;
            }

            if (!(StudentDataGridView.Rows[e.RowIndex].DataBoundItem is Student student))
            {
                e.Handled = false;
                return;
            }

            var graphics = e.Graphics;
            var rect = e.CellBounds;

            e.PaintBackground(rect, true);

            var width = rect.Width * (student.TotalAmountOfPoints / totalPoints);
            var targetRect = new Rectangle(rect.Left + padding, rect.Top + padding, (int)width, rect.Height - progressBarHeightReduction);

            graphics?.FillRectangle(Brushes.Bisque, targetRect);
            graphics?.DrawRectangle(Pens.Gold, targetRect);

            var format = new StringFormat();

            format.LineAlignment = StringAlignment.Center;
            format.Alignment = StringAlignment.Center;

            var rectF = new RectangleF(rect.X, rect.Y, rect.Width, rect.Height);

            graphics?.DrawString(e.Value?.ToString(), DefaultFont, Brushes.Black, rectF, format);
            e.Handled = true;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            var applicants = new ApplicantsForm();

            if (applicants.ShowDialog(this) == DialogResult.OK)
            {
                items.Add(applicants.CurrentStudent);

                OnUpdate();
            }
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            if (StudentDataGridView.SelectedRows.Count == 0)
            {
                return;
            }

            var student = (Student)StudentDataGridView.SelectedRows[0].DataBoundItem;
            var applicants = new ApplicantsForm(student);

            if (applicants.ShowDialog(this) == DialogResult.OK)
            {
                var target = items.FirstOrDefault(x => x.Id == applicants.CurrentStudent.Id);

                if (target != null)
                {
                    target.FullName = applicants.CurrentStudent.FullName;
                    target.Gender = applicants.CurrentStudent.Gender;
                    target.Birthday = applicants.CurrentStudent.Birthday;
                    target.EducationalForm = applicants.CurrentStudent.EducationalForm;
                    target.MathScores = applicants.CurrentStudent.MathScores;
                    target.PointsInRussianLanguage = applicants.CurrentStudent.PointsInRussianLanguage;
                    target.ComputerScienceScores = applicants.CurrentStudent.ComputerScienceScores;

                    OnUpdate();
                }
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (StudentDataGridView.SelectedRows.Count == 0)
            {
                return;
            }

            var student = (Student)StudentDataGridView.SelectedRows[0].DataBoundItem;
            var target = items.FirstOrDefault(x => x.Id == student.Id);

            if (target != null &&
                MessageBox.Show($"Вы действительно желаете удалить '{target.FullName}' ?", "Удаление студента", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                items.Remove(target);

                OnUpdate();
            }
        }

        private void OnUpdate()
        {
            bindingSource.ResetBindings(false);
            SetStatistic();
        }

        private void SetStatistic()
        {
            NumberOfApplicantsStatusLabel.Text = $"Количество абитуриентов: {items.Count}";
            ScoreEnoughPointsStatusLabel.Text = $"Набрали больше {ValidationConstants.RequiredNumberOfPoints} баллов: " + $"{items.Count(x => x.TotalAmountOfPoints > ValidationConstants.RequiredNumberOfPoints)}";
        }

        private void ConfigureDataGridViewColumns()
        {
            FullNameColumn.DataPropertyName = nameof(Student.FullName);
            BirthdayColumn.DataPropertyName = nameof(Student.BirthdayDisplay);
            GenderColumn.DataPropertyName = nameof(Student.Gender);
            EducationalFormColumn.DataPropertyName = nameof(Student.EducationalForm);
            MathScoreColumn.DataPropertyName = nameof(Student.MathScores);
            PointsInRussianLanguage.DataPropertyName = nameof(Student.PointsInRussianLanguage);
            ComputerScienceScores.DataPropertyName = nameof(Student.ComputerScienceScores);
            TotalAmountOfPoints.DataPropertyName = nameof(Student.TotalAmountOfPoints);
        }
    }
}
