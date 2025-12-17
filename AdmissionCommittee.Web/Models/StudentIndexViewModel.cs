using AdmissionCommittee.MemoryStorage.Contracts;
using AdmissionCommittee.Models;

namespace AdmissionCommittee.Web.Models
{
    /// <summary>
    /// Модель представления для главной страницы студентов
    /// </summary>
    public class StudentIndexViewModel
    {
        /// <summary>
        /// Список всех студентов, отображаемых в таблице
        /// </summary>
        public List<Student> Students { get; set; } = new();

        /// <summary>
        /// Общая статистика по студентам
        /// </summary>
        public StatisticsResult Statistics { get; set; } = new();
    }
}
