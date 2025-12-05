using AdmissionCommittee.Manager;
using AdmissionCommittee.Manager.Contracts;
using AdmissionCommittee.Services;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Core;

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
            using var log = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Debug()
                .WriteTo.File("logs/log-.txt",
                    rollingInterval: RollingInterval.Day,
                    outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}")
                .WriteTo.Seq("http://localhost:5341",
                    apiKey: "HSCK1jhU59ROAkmSMRTL")
                .CreateLogger();

            using var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddSerilog(log);
            });

            var studentStorage = new StudentMemoryStorage();
            var studentManager = new StudentsManager(studentStorage, loggerFactory);

            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm(studentManager));
        }
    }
}