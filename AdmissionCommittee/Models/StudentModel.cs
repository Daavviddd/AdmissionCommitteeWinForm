namespace AdmissionCommittee.Models
{
    /// <summary>
    /// LolMiner
    /// </summary>
    public class StudentModel
    {
        /// <summary>
        /// id
        /// </summary>
        public Guid id { get; set; }

        /// <summary>
        /// ФИО
        /// </summary>
        public string FullName { get; set; } = string.Empty;

        /// <summary>
        /// Гендер
        /// </summary>
        public Gender Gender { get; set; }

        /// <summary>
        /// дата рождения
        /// </summary>
        public DateOnly Birthday { get; set; }

        /// <summary>
        /// форма обучения
        /// </summary>
        public EducationalForm EducationalForm { get; set; }

        /// <summary>
        /// баллы ЕГЭ по математике
        /// </summary>
        public float MathScores { get; set; }

        /// <summary>
        /// баллы ЕГЭ по русскому языку
        /// </summary>
        public float PointsInRussianLanguage { get; set; }

        /// <summary>
        /// баллы ЕГЭ по информатике
        /// </summary>
        public float ComputerScienceScores { get; set; }

        /// <summary>
        /// общая сумма баллов
        /// </summary>
        public float TotalAmountOfPoints { get; set; }
    }
}
