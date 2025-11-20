using AdmissionCommittee.Models;

namespace AdmissionCommittee.Contracts
{
    /// <summary>
    /// Интерфейс сервиса для управления студентами
    /// </summary>
    public interface IStudentService
    {
        /// <summary>
        /// Получает список всех студентов асинхронно
        /// </summary>
        Task<List<Student>> GetAllStudentsAsync();

        /// <summary>
        /// Получает студента по идентификатору асинхронно
        /// </summary>
        Task<Student?> GetStudentByIdAsync(Guid id);

        /// <summary>
        /// Добавляет нового студента асинхронно
        /// </summary>
        Task AddStudentAsync(Student student);

        /// <summary>
        /// Обновляет данные студента асинхронно
        /// </summary>
        Task UpdateStudentAsync(Student student);

        /// <summary>
        /// Удаляет студента по идентификатору асинхронно
        /// </summary>
        Task DeleteStudentAsync(Guid id);

        /// <summary>
        /// Получает статистику по студентам асинхронно
        /// </summary>
        Task<(int totalCount, int passedCount)> GetStatisticsAsync();
    }
}