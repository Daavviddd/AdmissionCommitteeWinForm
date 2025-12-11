using AdmissionCommittee.MemoryStorage.Contracts;
using AdmissionCommittee.Models;
using Microsoft.EntityFrameworkCore;

namespace AdmissionCommittee.DataBaseStorage 
{
    /// <summary>
    /// Хранилище данных с использованием базы данных
    /// </summary>
    public class AdmissionCommitteeStorage : IStudentStorage
    {
        /// <summary>
        /// Получить всех студентов
        /// </summary>
        public async Task<List<Student>> GetAllStudentsAsync()
        {
            using var database = new AdmissionCommitteeContext();
            return await database.Students.AsNoTracking().ToListAsync();
        }

        /// <summary>
        /// Добавить нового студента
        /// </summary>
        public async Task AddStudentAsync(Student student)
        {
            using var database = new AdmissionCommitteeContext();
            database.Students.Add(student);
            await database.SaveChangesAsync();
        }

        /// <summary>
        /// Изменить данные студента
        /// </summary>
        public async Task UpdateStudentAsync(Student student)
        {
            using var database = new AdmissionCommitteeContext();
            database.Students.Update(student);
            await database.SaveChangesAsync();
        }

        /// <summary>
        /// Удалить студента по Id
        /// </summary>
        public async Task DeleteStudentAsync(Guid id)
        {
            using var database = new AdmissionCommitteeContext();
            var student = await database.Students.FindAsync(id);
            if (student != null)
            {
                database.Students.Remove(student);
                await database.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Получить студента по идентификатору
        /// </summary>
        public async Task<Student?> GetStudentByIdAsync(Guid id)
        {
            using var database = new AdmissionCommitteeContext();
            return await database.Students
                .AsNoTracking()
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        /// <summary>
        /// Получить статистику по студентам
        /// </summary>
        public async Task<StatisticsResult> GetStatisticsAsync()
        {
            using var database = new AdmissionCommitteeContext();

            var allStudents = await database.Students
                .AsNoTracking()
                .ToListAsync();

            var totalCount = allStudents.Count;
            var passedCount = allStudents
                .Count(s => s.TotalAmountOfPoints >= ValidationConstants.RequiredNumberOfPoints);

            return new StatisticsResult(totalCount, passedCount);
        }
    }
}
