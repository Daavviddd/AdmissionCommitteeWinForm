namespace AdmissionCommittee.Services.Contracts
{
    /// <summary>
    /// Результат статистики по студентам
    /// </summary>
    public class StatisticsResult
    {
        /// <summary>
        /// Общее количество студентов
        /// </summary>
        public int TotalCount { get; set; }

        /// <summary>
        /// Количество студентов, набравших проходной балл
        /// </summary>
        public int PassedCount { get; set; }

        /// <summary>
        /// Количество студентов, не набравших проходной балл
        /// </summary>
        public int NotPassedCount => TotalCount - PassedCount;

        /// <summary>
        /// Процент студентов, прошедших по баллам
        /// </summary>
        public double PassedPercentage => TotalCount > 0 ? (double)PassedCount / TotalCount * 100 : 0;

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public StatisticsResult() { }

        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        public StatisticsResult(int totalCount, int passedCount)
        {
            TotalCount = totalCount;
            PassedCount = passedCount;
        }
    }
}
