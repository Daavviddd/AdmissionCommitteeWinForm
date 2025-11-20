using System.ComponentModel.DataAnnotations;
using AdmissionCommittee.Contracts;
using AdmissionCommittee.Models;

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
        public async Task<(bool isValid, List<string> errors)> ValidateStudentAsync(Student student)
        {
            return await Task.Run(() =>
            {
                var errors = new List<string>();
                var context = new ValidationContext(student);
                var results = new List<ValidationResult>();

                var isValid = Validator.TryValidateObject(student, context, results, true);

                if (!isValid)
                    errors.AddRange(results.Select(r => r.ErrorMessage));

                var age = DateTime.Now.Year - student.Birthday.Year;
                if (student.Birthday > DateTime.Now.AddYears(-age)) age--;

                if (age < NumbersForValidation.MinStudentAge || age > NumbersForValidation.MaxStudentAge)
                    errors.Add($"Возраст должен быть от {NumbersForValidation.MinStudentAge} до {NumbersForValidation.MaxStudentAge} лет");

                return (errors.Count == 0, errors);
            });
        }

        /// <summary>
        /// Проверяет, прошел ли студент по баллам асинхронно
        /// </summary>
        public async Task<bool> IsStudentPassedAsync(Student student)
        {
            return await Task.Run(() =>
                student.TotalAmountOfPoints >= NumbersForValidation.RequiredNumberOfPoints);
        }
    }
}