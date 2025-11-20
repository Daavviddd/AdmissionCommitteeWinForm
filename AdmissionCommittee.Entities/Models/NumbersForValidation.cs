namespace AdmissionCommittee.Models
{
    /// <summary>
    /// Числа для валидации
    /// </summary>
    public static class NumbersForValidation
    {
        /// <summary>
        /// Минимальные баллы экзамена
        /// </summary>
        public const float MinExamScore = 0f;

        /// <summary>
        /// Максимальные баллы экзамена
        /// </summary>
        public const float MaxExamScore = 100f;

        /// <summary>
        /// Максимальная сумма баллов
        /// </summary>
        public const float MaxTotalScore = 300f;

        /// <summary>
        /// Необходимое количество баллов
        /// </summary>
        public const float RequiredNumberOfPoints = 150f;
        
        /// <summary>
        /// Максимальная длина ФИО
        /// </summary>
        public const int MaxFullNameSize = 255;

        /// <summary>
        /// Минимальный возраст студента
        /// </summary>
        public const int MinStudentAge = 18;

        /// <summary>
        /// Максимальный возраст студента
        /// </summary>
        public const int MaxStudentAge = 80;

        /// <summary>
        /// Отступ для ProgressBar в ячейке
        /// </summary>
        public const int ProgressBarPadding = 2;

        /// <summary>
        /// Уменьшение высоты ProgressBar
        /// </summary>
        public const int ProgressBarHeightReduction = 4;
    }
}
