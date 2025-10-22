using AdmissionCommittee.Models;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Windows.Forms;

namespace AdmissionCommittee.Forms
{
    public partial class ApplicantsForm : Form
    {
        private readonly StudentModel targetStudent;
        private readonly ErrorProvider errorProvider = new ErrorProvider();
        public ApplicantsForm(StudentModel? sourceStudent = null)
        {
            InitializeComponent();

            errorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;

            if (sourceStudent != null)
            {
                targetStudent = new StudentModel
                {
                    id = sourceStudent.id,
                    FullName = sourceStudent.FullName,
                    Gender = sourceStudent.Gender,
                    Birthday = sourceStudent.Birthday,
                    EducationalForm = sourceStudent.EducationalForm,
                    MathScores = sourceStudent.MathScores,
                    PointsInRussianLanguage = sourceStudent.PointsInRussianLanguage,
                    ComputerScienceScores = sourceStudent.ComputerScienceScores,
                    TotalAmountOfPoints = sourceStudent.TotalAmountOfPoints,
                };
                btnSave.Text = "Сохранить";
            }
            else
            {
                targetStudent = new StudentModel
                {
                    id = Guid.NewGuid(),
                    FullName = "",
                    Gender = Gender.Unknow,
                    Birthday = DateOnly.FromDateTime(DateTime.Now.AddYears(-18)),
                    EducationalForm = EducationalForm.FullTime,
                    MathScores = 0,
                    PointsInRussianLanguage = 0,
                    ComputerScienceScores = 0,
                    TotalAmountOfPoints = 0,
                };
            }
            GenderComboBox.DataSource = Enum.GetValues(typeof(Gender));
            EducationFormComboBox.DataSource = Enum.GetValues(typeof(EducationalForm));

            GenderComboBox.AddBinding(x => x.SelectedItem, targetStudent, x => x.Gender, errorProvider);
            EducationFormComboBox.AddBinding(x => x.SelectedItem, targetStudent, x => x.EducationalForm, errorProvider);

            var dateTimePickerBinding = new Binding("Value", targetStudent, "Birthday");
            dateTimePickerBinding.Format += new ConvertEventHandler(DateOnlyToDateTime!);
            dateTimePickerBinding.Parse += new ConvertEventHandler(DateTimeToDateOnly!);
            BirthdayDateTimePicker.DataBindings.Add(dateTimePickerBinding);

            FullNameTextBox.AddBinding(x => x.Text, targetStudent, x => x.FullName, errorProvider);
            MathNumericUpDown.AddBinding(x => x.Value, targetStudent, x => x.MathScores, errorProvider);
            RussianNumericUpDown.AddBinding(x => x.Value, targetStudent, x => x.PointsInRussianLanguage, errorProvider);
            ComputerNumericUpDown.AddBinding(x => x.Value, targetStudent, x => x.ComputerScienceScores, errorProvider);
            TotalPointsTextBox.AddBinding(x => x.Text, targetStudent, x => x.TotalAmountOfPoints, errorProvider);

            MathNumericUpDown.ValueChanged += NumericUpDown_ValueChanged;
            RussianNumericUpDown.ValueChanged += NumericUpDown_ValueChanged;
            ComputerNumericUpDown.ValueChanged += NumericUpDown_ValueChanged;

            UpdateTotalPoints();

            errorProvider.SetError(FullNameTextBox, "");
        }

        private void DateOnlyToDateTime(object sender, ConvertEventArgs e)
        {
            if (e.DesiredType == typeof(DateTime) && e.Value is DateOnly)
            {
                var dateOnly = (DateOnly)e.Value;
                e.Value = new DateTime(dateOnly.Year, dateOnly.Month, dateOnly.Day);
            }
        }

        private void DateTimeToDateOnly(object sender, ConvertEventArgs e)
        {
            if (e.DesiredType == typeof(DateOnly) && e.Value is DateTime)
            {
                e.Value = DateOnly.FromDateTime((DateTime)e.Value);
            }
        }

        private void NumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            UpdateTotalPoints();
        }

        private void UpdateTotalPoints()
        {
            var math = (float)MathNumericUpDown.Value;
            var russian = (float)RussianNumericUpDown.Value;
            var computer = (float)ComputerNumericUpDown.Value;

            targetStudent.TotalAmountOfPoints = math + russian + computer;

            TotalPointsTextBox.DataBindings["Text"]?.ReadValue();
        }

        private void GenderComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index >= 0)
            {
                e.DrawBackground();
                e.DrawFocusRectangle();
                var value = GenderComboBox.Items[e.Index];
                if (value is Gender genderValue)
                {
                    var valueString = genderValue.ToString();
                    switch (genderValue)
                    {
                        case Gender.Male:
                            valueString = "Мужской";
                            break;
                        case Gender.Female:
                            valueString = "Женский";
                            break;
                        case Gender.Unknow:
                            valueString = "-";
                            break;
                    }
                    var brush = SystemBrushes.Control;
                    if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                    {
                        brush = SystemBrushes.HighlightText;
                    }
                    e.Graphics.DrawString(valueString, e.Font!, Brushes.Black, new Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height));
                }
            }
        }

        private void EducationFormComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index >= 0)
            {
                e.DrawBackground();
                e.DrawFocusRectangle();
                var value = EducationFormComboBox.Items[e.Index];
                if (value is EducationalForm educationFormValue)
                {
                    var valueString = educationFormValue.ToString();
                    switch (educationFormValue)
                    {
                        case EducationalForm.FullTime:
                            valueString = "Очная";
                            break;
                        case EducationalForm.FullTimeAndPartTime:
                            valueString = "Очно-заочная";
                            break;
                        case EducationalForm.CorrespondenceEducation:
                            valueString = "Заочная";
                            break;
                    }
                    var brush = SystemBrushes.Control;
                    if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                    {
                        brush = SystemBrushes.HighlightText;
                    }
                    e.Graphics.DrawString(valueString, e.Font!, Brushes.Black, new Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height));
                }
            }
        }

        private void GenderComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (GenderComboBox.SelectedIndex > 0)
            {
                targetStudent.Gender = (Gender)GenderComboBox.SelectedItem;
            }
        }

        private void FullNameTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void BirthdayDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            var minYearStudent = -18;
            var maxYearStudent = -80;

            BirthdayDateTimePicker.MaxDate = DateTime.Now.AddYears(minYearStudent);
            BirthdayDateTimePicker.MinDate = DateTime.Now.AddYears(maxYearStudent);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();

            foreach (Binding binding in FullNameTextBox.DataBindings)
            {
                binding.WriteValue();
            }
            foreach (Binding binding in MathNumericUpDown.DataBindings)
            {
                binding.WriteValue();
            }
            foreach (Binding binding in RussianNumericUpDown.DataBindings)
            {
                binding.WriteValue();
            }
            foreach (Binding binding in ComputerNumericUpDown.DataBindings)
            {
                binding.WriteValue();
            }

            var validationContext = new ValidationContext(targetStudent);
            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(targetStudent, validationContext, validationResults, true);

            if (string.IsNullOrWhiteSpace(targetStudent.FullName))
            {
                errorProvider.SetError(FullNameTextBox, "ФИО обязательно для заполнения");
                isValid = false;
            }

            if (targetStudent.Gender == Gender.Unknow)
            {
                errorProvider.SetError(GenderComboBox, "Выберите пол");
                isValid = false;
            }

            if (targetStudent.TotalAmountOfPoints == 0)
            {
                errorProvider.SetError(TotalPointsTextBox, "Сумма баллов должна быть больше 0");
                isValid = false;
            }
            else
            {
                errorProvider.SetError(TotalPointsTextBox, "");
            }

            if (isValid)
            {
                MessageBox.Show("Данные успешно добавлены", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                var errorMessages = validationResults.Select(vr => vr.ErrorMessage);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            var resultClose = MessageBox.Show("Вы точно хотите отменить операцию ?", "Отмена", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultClose == DialogResult.Yes)
            {
                DialogResult = DialogResult.Cancel;
                Close();
            }

        }

        public StudentModel CurrentStudent => targetStudent;
    }
}
