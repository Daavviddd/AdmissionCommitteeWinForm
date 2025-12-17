using AdmissionCommittee.Models;

namespace AdmissionCommittee.MemoryStorage.Contracts
{
    /// <summary>
    /// Интерфейс сервиса для управления студентами
    /// </summary>
    public interface IStudentStorage
    {
        /// <summary>
        /// Получает список всех студентов асинхронно
        /// </summary>
        Task<List<Student>> GetAllStudentsAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Получает студента по идентификатору асинхронно
        /// </summary>
        Task<Student?> GetStudentByIdAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Добавляет нового студента асинхронно
        /// </summary>
        Task AddStudentAsync(Student student, CancellationToken cancellationToken);

        /// <summary>
        /// Обновляет данные студента асинхронно
        /// </summary>
        Task UpdateStudentAsync(Student student, CancellationToken cancellationToken);

        /// <summary>
        /// Удаляет студента по идентификатору асинхронно
        /// </summary>
        Task DeleteStudentAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Получает статистику по студентам асинхронно
        /// </summary>
        Task<StatisticsResult> GetStatisticsAsync(CancellationToken cancellationToken);
    }
}