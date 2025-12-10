using AdmissionCommittee.MemoryStorage.Contracts;
using AdmissionCommittee.Models;

namespace AdmissionCommittee.Services
{
    /// <summary>
    /// Сервис для доступа к студентам в памяти
    /// </summary>
    public class StudentMemoryStorage : IStudentStorage
    {
        private readonly List<Student> students;

        /// <summary>
        /// Инициализация экземпляра StudentMemoryStorage
        /// </summary>
        public StudentMemoryStorage()
        {
            students = new List<Student>
            {
                new Student
                {
                    Id = Guid.NewGuid(),
                    FullName = "Тест Тест Тест",
                    Gender = Gender.Male,
                    Birthday = new DateTime(2002, 11, 11),
                    EducationalForm = EducationalForm.FullTime,
                    MathScores = 85f,
                    PointsInRussianLanguage = 80f,
                    ComputerScienceScores = 70f,
                },
                new Student
                {
                    Id = Guid.NewGuid(),
                    FullName = "Тест2 Тест2 Тест2",
                    Gender = Gender.Male,
                    Birthday = new DateTime(2003, 11, 12),
                    EducationalForm = EducationalForm.FullTime,
                    MathScores = 15f,
                    PointsInRussianLanguage = 40f,
                    ComputerScienceScores = 30f,
                }
            };
        }

        async Task<List<Student>> IStudentStorage.GetAllStudentsAsync() =>
            await Task.FromResult(students.ToList());

        async Task<Student?> IStudentStorage.GetStudentByIdAsync(Guid id) =>
            await Task.FromResult(students.FirstOrDefault(s => s.Id == id));

        async Task IStudentStorage.AddStudentAsync(Student student)
        {
            students.Add(student);
            await Task.CompletedTask;
        }

        async Task IStudentStorage.UpdateStudentAsync(Student student)
        {
            var target = students.FirstOrDefault(s => s.Id == student.Id);
            if (target != null)
            {
                target.FullName = student.FullName;
                target.Gender = student.Gender;
                target.Birthday = student.Birthday;
                target.EducationalForm = student.EducationalForm;
                target.MathScores = student.MathScores;
                target.PointsInRussianLanguage = student.PointsInRussianLanguage;
                target.ComputerScienceScores = student.ComputerScienceScores;

                await Task.CompletedTask;
            }
        }

        async Task IStudentStorage.DeleteStudentAsync(Guid id)
        {
            var target = students.FirstOrDefault(s => s.Id == id);
            if (target != null)
            {
                students.Remove(target);
                await Task.CompletedTask;
            }
        }

        async Task<StatisticsResult> IStudentStorage.GetStatisticsAsync()
        {
            var total = students.Count;
            var passed = students.Count(s => s.TotalAmountOfPoints >= ValidationConstants.RequiredNumberOfPoints);

            return await Task.FromResult(new StatisticsResult(total, passed));
        }
    }
}