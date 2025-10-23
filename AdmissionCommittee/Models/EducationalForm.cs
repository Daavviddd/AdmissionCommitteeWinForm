namespace AdmissionCommittee.Models
{
    /// <summary>
    /// Форма обучения
    /// </summary>
    public enum EducationalForm : byte
    {
        /// <summary>
        /// Очная
        /// </summary>
        FullTime = 0,

        /// <summary>
        /// Очно-заочная
        /// </summary>
        FullTimeAndPartTime = 1,

        /// <summary>
        /// Заочная
        /// </summary>
        CorrespondenceEducation = 2
    }
}
