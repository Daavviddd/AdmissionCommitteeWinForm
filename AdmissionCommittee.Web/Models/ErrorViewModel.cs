namespace AdmissionCommittee.Web.Models
{
    public class ErrorViewModel
    {
        /// <summary>
        /// Получает или задает идентификатор запроса, связанного с ошибкой
        /// </summary>
        public string? RequestId { get; set; }

        /// <summary>
        /// Получает значение, указывающее, должен ли отображаться идентификатор запроса
        /// </summary>
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
