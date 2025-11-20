using AdmissionCommittee.Models;

namespace AdmissionCommittee.Contracts
{
    /// <summary>
    /// Интерфейс сервиса для валидации данных студентов
    /// </summary>
    public interface IValidationService
    {
        /// <summary>
        /// Выполняет валидацию данных студента асинхронно
        /// </summary>
        Task<(bool isValid, List<string> errors)> ValidateStudentAsync(Student student);

        /// <summary>
        /// Проверяет, прошел ли студент по баллам асинхронно
        /// </summary>
        Task<bool> IsStudentPassedAsync(Student student);
    }
}