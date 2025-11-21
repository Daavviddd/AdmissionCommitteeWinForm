using System.ComponentModel.DataAnnotations;

namespace AdmissionCommittee.Models
{
    /// <summary>
    /// Класс данных студента
    /// </summary>
    public class Student
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid Id { get; set; } = Guid.NewGuid();

        /// <summary>
        /// ФИО
        /// </summary>
        [Required(ErrorMessage = "Поле {0} обязательно для заполнения")]
        [StringLength(ValidationConstants.MaxFullNameSize, ErrorMessage = "Поле {0} должно содержать не более {1} символов")]
        public string FullName { get; set; } = string.Empty;

        /// <summary>
        /// Гендер
        /// </summary>
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
        [Range(ValidationConstants.MinExamScore, ValidationConstants.MaxExamScore,
            ErrorMessage = "Поле '{0}' должно быть в пределах от {1} до {2} баллов")]
        public float MathScores { get; set; }

        /// <summary>
        /// Баллы ЕГЭ по русскому языку
        /// </summary>
        [Display(Name = "Баллы по русскому языку")]
        [Range(ValidationConstants.MinExamScore, ValidationConstants.MaxExamScore,
            ErrorMessage = "Поле '{0}' должно быть в пределах от {1} до {2} баллов")]
        public float PointsInRussianLanguage { get; set; }

        /// <summary>
        /// Баллы ЕГЭ по информатике
        /// </summary>
        [Display(Name = "Баллы по информатике")]
        [Range(ValidationConstants.MinExamScore, ValidationConstants.MaxExamScore,
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
        public Student Clone()
        {
            return (Student)MemberwiseClone();
        }
    }
}
