using System.Diagnostics;
using AdmissionCommittee.Manager.Contracts;
using AdmissionCommittee.MemoryStorage.Contracts;
using AdmissionCommittee.Models;
using Microsoft.Extensions.Logging;

namespace AdmissionCommittee.Manager
{
    /// <summary>
    /// Менеджер для работы со студентами
    /// </summary>
    public class StudentsManager : IStudentsManager
    {
        private readonly IStudentStorage studentService;
        private readonly ILogger logger;

        /// <summary>
        /// Инициализирует экземпляр <see cref="StudentsManager"/>
        /// </summary>
        public StudentsManager(IStudentStorage studentService, ILoggerFactory loggerFactory)
        {
            this.studentService = studentService;
            logger = loggerFactory.CreateLogger<StudentsManager>();
        }

        async Task<List<Student>> IStudentsManager.GetAllStudentsAsync()
        {
            var sw = Stopwatch.StartNew();
            try
            {
                var result = await studentService.GetAllStudentsAsync();
                return result;
            }
            finally
            {
                sw.Stop();
                var ms = sw.ElapsedTicks * 1000.0 / Stopwatch.Frequency;
                logger.LogInformation("GetAllStudents() выполнен за {ms:F6} мс", ms);
            }
        }

        async Task IStudentsManager.AddStudentAsync(Student student)
        {
            var sw = Stopwatch.StartNew();
            try
            {
                await studentService.AddStudentAsync(student);
            }
            finally
            {
                sw.Stop();
                var ms = sw.ElapsedTicks * 1000.0 / Stopwatch.Frequency;
                logger.LogInformation("AddStudent() выполнен за {ms:F6} мс", ms);
            }
        }

        async Task IStudentsManager.UpdateStudentAsync(Student student)
        {
            var sw = Stopwatch.StartNew();

            try
            {
                await studentService.UpdateStudentAsync(student);
            }
            finally
            {
                sw.Stop();
                var ms = sw.ElapsedTicks * 1000.0 / Stopwatch.Frequency;
                logger.LogInformation("UpdateStudent() выполнен за {ms:F6} мс", ms);
            }
        }

        async Task IStudentsManager.DeleteStudentAsync(Guid id)
        {
            var sw = Stopwatch.StartNew();

            try
            {
                await studentService.DeleteStudentAsync(id);
            }
            finally
            {
                sw.Stop();
                var ms = sw.ElapsedTicks * 1000.0 / Stopwatch.Frequency;
                logger.LogInformation("DeleteStudent() выполнен за {ms:F6} мс", ms);
            }
        }

        async Task<Student?> IStudentsManager.GetStudentByIdAsync(Guid id)
        {
            var sw = Stopwatch.StartNew();

            try
            {
                var result = await studentService.GetStudentByIdAsync(id);

                return result;
            }
            finally
            {
                sw.Stop();
                var ms = sw.ElapsedTicks * 1000.0 / Stopwatch.Frequency;
                logger.LogInformation("GetStudentById() выполнен за {ms:F6} мс", ms);
            }
        }

        async Task<StatisticsResult> IStudentsManager.GetStatisticsAsync()
        {
            var sw = Stopwatch.StartNew();

            try
            {
                var result = await studentService.GetStatisticsAsync();

                return result;
            }
            finally
            {
                sw.Stop();
                var ms = sw.ElapsedTicks * 1000.0 / Stopwatch.Frequency;
                logger.LogInformation("GetStatistics() выполнен за {ms:F6} мс", ms);
            }
        }
    }
}