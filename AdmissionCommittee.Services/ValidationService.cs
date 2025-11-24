using System.ComponentModel.DataAnnotations;
using AdmissionCommittee.Contracts;
using AdmissionCommittee.Models;
using AdmissionCommittee.Services.Contracts;

namespace AdmissionCommittee.Services
{
    /// <summary>
    /// Реализация сервиса для валидации данных студентов
    /// </summary>
    public class ValidationService : IValidationService
    {
        /// <summary>
        /// Выполняет валидацию данных студента асинхронно
        /// </summary>
        public async Task<StudentValidationResult> ValidateStudentAsync(Student student)
        {
            return await Task.Run(() =>
            {
                var errors = new List<string>();
                var context = new ValidationContext(student);
                var results = new List<ValidationResult>();

                var isValid = Validator.TryValidateObject(student, context, results, true);

                if (!isValid)
                {
                    errors.AddRange(results.Select(r => r.ErrorMessage));
                }

                var age = DateTime.Now.Year - student.Birthday.Year;

                if (student.Birthday > DateTime.Now.AddYears(-age))
                {
                    age--;
                }

                if (age < ValidationConstants.MinStudentAge || age > ValidationConstants.MaxStudentAge)
                {
                    errors.Add($"Возраст должен быть от {ValidationConstants.MinStudentAge}" +
                        $" до {ValidationConstants.MaxStudentAge} лет");
                }
                   
                return new StudentValidationResult(errors.Count == 0, errors);
            });
        }

        /// <summary>
        /// Проверяет, прошел ли студент по баллам асинхронно
        /// </summary>
        public bool IsStudentPassed(Student student)
        {
            return student.TotalAmountOfPoints >= ValidationConstants.RequiredNumberOfPoints;
        }
    }
}