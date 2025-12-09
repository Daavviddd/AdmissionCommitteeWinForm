using System.ComponentModel.DataAnnotations;
using AdmissionCommittee.Infrostructure;
using AdmissionCommittee.Models;

namespace AdmissionCommittee.Forms
{
    /// <summary>
    /// Форма для добавления и редактирования данных абитуриента
    /// </summary>
    public partial class ApplicantsForm : Form
    {
        private readonly Student targetStudent;
        private readonly ErrorProvider errorProvider = new ErrorProvider();

        /// <summary>
        /// Текущий абитуриент 
        /// </summary>
        public Student CurrentStudent => targetStudent;

        /// <summary>
        /// Конструктор добавления и редактирования студента
        /// </summary>
        public ApplicantsForm(Student? sourceStudent = null)
        {
            InitializeComponent();

            errorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;

            if (sourceStudent != null)
            {
                targetStudent = sourceStudent.Clone();
                btnSave.Text = "Сохранить";
            }
            else
            {
                targetStudent = new Student();
            }

            GenderComboBox.DrawMode = DrawMode.OwnerDrawFixed;
            EducationFormComboBox.DrawMode = DrawMode.OwnerDrawFixed;

            GenderComboBox.DataSource = Enum.GetValues(typeof(Gender));
            EducationFormComboBox.DataSource = Enum.GetValues(typeof(EducationalForm));

            if (sourceStudent != null)
            {
                GenderComboBox.SelectedItem = sourceStudent.Gender;
                EducationFormComboBox.SelectedItem = sourceStudent.EducationalForm;
            }
            else
            {
                GenderComboBox.SelectedItem = Gender.Male;
                EducationFormComboBox.SelectedItem = EducationalForm.FullTime;
            }

            BirthdayDateTimePicker.MaxDate = DateTime.Now.AddYears(-ValidationConstants.MinStudentAge);
            BirthdayDateTimePicker.MinDate = DateTime.Now.AddYears(-ValidationConstants.MaxStudentAge);

            BirthdayDateTimePicker.AddBinding(x => x.Value, targetStudent, x => x.Birthday, errorProvider);

            GenderComboBox.AddBinding(x => x.SelectedValue!, targetStudent, x => x.Gender, errorProvider);
            EducationFormComboBox.AddBinding(x => x.SelectedValue!, targetStudent, x => x.EducationalForm, errorProvider);
            MathNumericUpDown.AddBinding(x => x.Value, targetStudent, x => x.MathScores, errorProvider);
            RussianNumericUpDown.AddBinding(x => x.Value, targetStudent, x => x.PointsInRussianLanguage, errorProvider);
            ComputerNumericUpDown.AddBinding(x => x.Value, targetStudent, x => x.ComputerScienceScores, errorProvider);
            
            MathNumericUpDown.ValueChanged += NumericUpDown_ValueChanged!;
            RussianNumericUpDown.ValueChanged += NumericUpDown_ValueChanged!;
            ComputerNumericUpDown.ValueChanged += NumericUpDown_ValueChanged!;

            FullNameTextBox.TextChanged += (sender, e) =>
            {
                errorProvider.SetError(FullNameTextBox, "");
            };

            UpdateTotalPoints();

            errorProvider.SetError(FullNameTextBox, "");
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
            var total = math + russian + computer;

            TotalPointsTextBox.Text = total.ToString();
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
                    var valueString = string.Empty;

                    switch (genderValue)
                    {
                        case Gender.Male:
                            valueString = "Мужской";
                            break;
                        case Gender.Female:
                            valueString = "Женский";
                            break;
                        default:
                            valueString = "-";
                            break;
                    }

                    var brush = SystemBrushes.ControlText;

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

        private void FullNameTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();

            targetStudent.FullName = FullNameTextBox.Text;

            var validationContext = new ValidationContext(targetStudent);
            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(targetStudent, validationContext, validationResults, true);

            foreach (var validationResult in validationResults)
            {
                foreach (var memberName in validationResult.MemberNames)
                {
                    switch (memberName)
                    {
                        case nameof(Student.FullName):
                            errorProvider.SetError(FullNameTextBox, validationResult.ErrorMessage);
                            break;
                        case nameof(Student.Gender):
                            errorProvider.SetError(GenderComboBox, validationResult.ErrorMessage);
                            break;
                        case nameof(Student.MathScores):
                            errorProvider.SetError(MathNumericUpDown, validationResult.ErrorMessage);
                            break;
                        case nameof(Student.PointsInRussianLanguage):
                            errorProvider.SetError(RussianNumericUpDown, validationResult.ErrorMessage);
                            break;
                        case nameof(Student.ComputerScienceScores):
                            errorProvider.SetError(ComputerNumericUpDown, validationResult.ErrorMessage);
                            break;
                    }
                }
            }

            if (isValid)
            {
                MessageBox.Show("Данные успешно добавлены", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
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
    }
}
