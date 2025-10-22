namespace AdmissionCommittee.Models
{
    /// <summary>
    /// Форма обучения
    /// </summary>
    public enum EducationalForm : byte
    {
        /// <summary>
        /// очная
        /// </summary>
        FullTime = 0,

        /// <summary>
        /// очно-заочная
        /// </summary>
        FullTimeAndPartTime = 1,

        /// <summary>
        /// заочная
        /// </summary>
        CorrespondenceEducation = 2
    }
}
