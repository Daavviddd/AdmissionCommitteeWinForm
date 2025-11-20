using System.ComponentModel.DataAnnotations;
using System.Windows.Forms;

namespace AdmissionCommittee.Models
{
    /// <summary>
    /// Класс данных студента
    /// </summary>
    public class StudentModel
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid Id { get; set; } = Guid.NewGuid();

        /// <summary>
        /// ФИО
        /// </summary>
        [Required(ErrorMessage = "Поле {0} обязательно для заполнения")]
        [StringLength(NumbersForValidation.MaxFullNameSize, ErrorMessage = "Поле {0} должно содержать не более {1} символов")]
        public string FullName { get; set; } = string.Empty;

        /// <summary>
        /// Гендер
        /// </summary>
        [Display(Name = "Пол")]
        [Range(1, 2, ErrorMessage = "Поле '{0}' обязательно для выбора")]
        public Gender Gender { get; set; }

        /// <summary>
        /// Дата рождения
        /// </summary>
        public DateTime Birthday { get; set; } = DateTime.Now;

        /// <summary>
        /// Форма обучения
        /// </summary>
        public EducationalForm EducationalForm { get; set; }

        /// <summary>
        /// Баллы ЕГЭ по математике
        /// </summary>
        [Display(Name = "Баллы по математике")]
        [Range(NumbersForValidation.MinExamScore, NumbersForValidation.MaxExamScore,
            ErrorMessage = "Поле '{0}' должно быть в пределах от {1} до {2} баллов")]
        public float MathScores { get; set; }

        /// <summary>
        /// Баллы ЕГЭ по русскому языку
        /// </summary>
        [Display(Name = "Баллы по русскому языку")]
        [Range(NumbersForValidation.MinExamScore, NumbersForValidation.MaxExamScore,
            ErrorMessage = "Поле '{0}' должно быть в пределах от {1} до {2} баллов")]
        public float PointsInRussianLanguage { get; set; }

        /// <summary>
        /// Баллы ЕГЭ по информатике
        /// </summary>
        [Display(Name = "Баллы по информатике")]
        [Range(NumbersForValidation.MinExamScore, NumbersForValidation.MaxExamScore,
            ErrorMessage = "Поле '{0}' должно быть в пределах от {1} до {2} баллов")]
        public float ComputerScienceScores { get; set; }

        /// <summary>
        /// Общая сумма баллов
        /// </summary>
        public float TotalAmountOfPoints => ComputerScienceScores + PointsInRussianLanguage + MathScores;

        /// <summary>
        /// Форматированная дата рождения для отображения
        /// </summary>
        public string BirthdayDisplay => Birthday.ToString("dd.MM.yyyy");

        /// <summary>
        /// Создает поверхностную копию объекта StudentModel
        /// </summary>
        public StudentModel Clone()
        {
            return (StudentModel)MemberwiseClone();
        }
    }
}
