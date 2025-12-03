using AdmissionCommittee.Contracts;
using AdmissionCommittee.Services;

namespace AdmissionCommittee
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            IStudentService studentService = new StudentService();

            Application.Run(new MainForm(studentService));
        }
    }
}