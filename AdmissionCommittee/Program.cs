using AdmissionCommittee.Contracts;
using AdmissionCommittee.Services;
using Serilog;

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
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Debug()
                .WriteTo.File("logs/log-.txt",
                    rollingInterval: RollingInterval.Day,
                    outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}")
                .WriteTo.Seq("http://localhost:5341",
                    apiKey: "br0jBx1kqPztmNwXmsJB")
                .CreateLogger();

            Log.Debug("Тестовый лог в Debug окне");

            ApplicationConfiguration.Initialize();

            IStudentService studentService = new StudentService();

            Application.Run(new MainForm(studentService));
        }
    }
}