namespace AdmissionCommittee.Models
{
    /// <summary>
    /// Пол абитуриента
    /// </summary>
    public enum Gender: byte
    {
        /// <summary>
        /// Не известен пол
        /// </summary>
        Unknow = 0,

        /// <summary>
        /// мужской
        /// </summary>
        Male = 1,

        /// <summary>
        /// женский
        /// </summary>
        Female = 2,
    }
}
