using AdmissionCommittee.Models;
using AdmissionCommittee.Services.Contracts;

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
        Task<StudentValidationResult> ValidateStudentAsync(Student student);

        /// <summary>
        /// Проверяет, прошел ли студент по баллам
        /// </summary>
        bool IsStudentPassed(Student student);
    }
}