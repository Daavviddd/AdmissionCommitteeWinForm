namespace AdmissionCommittee.Services.Contracts
{
    /// <summary>
    /// Результат валидации студента
    /// </summary>
    public class StudentValidationResult
    {
        /// <summary>
        /// Признак успешной валидации
        /// </summary>
        public bool IsValid { get; set; }

        /// <summary>
        /// Список ошибок валидации
        /// </summary>
        public List<string> Errors { get; set; } = new List<string>();

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public StudentValidationResult() { }

        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        public StudentValidationResult(bool isValid, List<string> errors)
        {
            IsValid = isValid;
            if (errors == null)
            {
                Errors = new List<string>();
            }
            else
            {
                Errors = errors;
            }
        }
    }
}
