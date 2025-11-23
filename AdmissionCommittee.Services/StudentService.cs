using AdmissionCommittee.Contracts;
using AdmissionCommittee.Models;
using AdmissionCommittee.Services.Contracts;

namespace AdmissionCommittee.Services
{
    /// <summary>
    /// Реализация сервиса для управления студентами с in-memory хранилищем
    /// </summary>
    public class StudentService : IStudentService
    {
        private readonly List<Student> students = new();

        /// <summary>
        /// Инициализируем тестовые данные
        /// </summary>
        public StudentService()
        {
            InitializeTestData();
        }

        private void InitializeTestData()
        {
            students.Add(new Student()
            {
                Id = Guid.NewGuid(),
                FullName = "Тест Тест Тест",
                Gender = Gender.Male,
                Birthday = new DateTime(2002, 11, 11),
                EducationalForm = EducationalForm.FullTime,
                MathScores = 85f,
                PointsInRussianLanguage = 80f,
                ComputerScienceScores = 70f,
            });
            students.Add(new Student()
            {
                Id = Guid.NewGuid(),
                FullName = "Тест2 Тест2 Тест2",
                Gender = Gender.Male,
                Birthday = new DateTime(2003, 11, 12),
                EducationalForm = EducationalForm.FullTime,
                MathScores = 15f,
                PointsInRussianLanguage = 40f,
                ComputerScienceScores = 30f,
            });
        }

        /// <summary>
        /// Получает список всех студентов асинхронно
        /// </summary>
        public async Task<List<Student>> GetAllStudentsAsync()
        {
            return await Task.Run(() => students.ToList());
        }

        /// <summary>
        /// Получает студента по идентификатору асинхронно
        /// </summary>
        public async Task<Student?> GetStudentByIdAsync(Guid id)
        {
            return await Task.Run(() => students.FirstOrDefault(s => s.Id == id));
        }

        /// <summary>
        /// Добавляет нового студента асинхронно
        /// </summary>
        public async Task AddStudentAsync(Student student)
        {
            await Task.Run(() => students.Add(student));
        }

        /// <summary>
        /// Обновляет данные студента асинхронно
        /// </summary>
        public async Task UpdateStudentAsync(Student student)
        {
            await Task.Run(() =>
            {
                var existing = students.FirstOrDefault(s => s.Id == student.Id);
                if (existing != null)
                {
                    var index = students.IndexOf(existing);
                    students[index] = student;
                }
            });
        }

        /// <summary>
        /// Удаляет студента по идентификатору асинхронно
        /// </summary>
        public async Task DeleteStudentAsync(Guid id)
        {
            await Task.Run(() =>
            {
                var student = students.FirstOrDefault(s => s.Id == id);
                if (student != null)
                {
                    students.Remove(student);
                }
            });
        }

        /// <summary>
        /// Получает статистику по студентам асинхронно
        /// </summary>
        public async Task<StatisticsResult> GetStatisticsAsync()
        {
            return await Task.Run(() =>
            {
                var total = students.Count;
                var passed = students.Count(s => s.TotalAmountOfPoints >= ValidationConstants.RequiredNumberOfPoints);
                return new StatisticsResult(total, passed);
            });
        }
    }
}