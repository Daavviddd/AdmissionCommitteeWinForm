using AdmissionCommittee.Forms;
using AdmissionCommittee.Manager.Contracts;
using AdmissionCommittee.Models;

namespace AdmissionCommittee
{
    /// <summary>
    /// Главная форма приложения "Приемная комиссия" для управления списком студентов
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// Источник данных для DataGridView
        /// </summary>
        private readonly BindingSource bindingSource = new();

        private readonly IStudentsManager studentService;

        /// <summary>
        /// Конструктор главной формы
        /// </summary>
        public MainForm(IStudentsManager studentService)
        {
            this.studentService = studentService;

            InitializeComponent();

            InitializeDataAsync();
            ConfigureDataGridViewColumns();
        }

        private async void InitializeDataAsync()
        {
            try
            {
                var students = await studentService.GetAllStudentsAsync();

                bindingSource.DataSource = students;
                StudentDataGridView.AutoGenerateColumns = false;
                StudentDataGridView.DataSource = bindingSource;

                await SetStatisticAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private async void AddButton_Click(object sender, EventArgs e)
        {
            var applicants = new ApplicantsForm();

            if (applicants.ShowDialog(this) == DialogResult.OK)
            {
                try
                {
                    await studentService.AddStudentAsync(applicants.CurrentStudent);
                    await LoadDataAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка добавления студента: {ex.Message}", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void EditButton_Click(object sender, EventArgs e)
        {
            if (StudentDataGridView.SelectedRows.Count == 0)
            {
                return;
            }

            var student = (Student)StudentDataGridView.SelectedRows[0].DataBoundItem;
            var applicants = new ApplicantsForm(student);

            if (applicants.ShowDialog(this) == DialogResult.OK)
            {
                try
                {
                    await studentService.UpdateStudentAsync(applicants.CurrentStudent);
                    await LoadDataAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка обновления студента: {ex.Message}", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void DeleteButton_Click(object sender, EventArgs e)
        {
            if (StudentDataGridView.SelectedRows.Count == 0)
            {
                return;
            }

            var student = (Student)StudentDataGridView.SelectedRows[0].DataBoundItem;
            var message = MessageBox.Show($"Вы действительно желаете удалить '{student.FullName}' ?", "Удаление студента", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (message == DialogResult.Yes)
            {
                try
                {
                    await studentService.DeleteStudentAsync(student.Id);
                    await LoadDataAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка удаления студента: {ex.Message}", "Ошибка",
                         MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async Task LoadDataAsync()
        {
            var students = await studentService.GetAllStudentsAsync();
            bindingSource.DataSource = students;
            bindingSource.ResetBindings(false);
            await SetStatisticAsync();
        }

        private async Task SetStatisticAsync()
        {
            try
            {
                var stats = await studentService.GetStatisticsAsync();
                NumberOfApplicantsStatusLabel.Text = $"Количество абитуриентов: {stats.TotalCount}";
                ScoreEnoughPointsStatusLabel.Text = $"Набрали больше {ValidationConstants.RequiredNumberOfPoints} баллов: {stats.PassedCount}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки статистики: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
