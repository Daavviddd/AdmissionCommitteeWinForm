using AdmissionCommittee.Models;
using Microsoft.EntityFrameworkCore;

namespace AdmissionCommittee.DataBaseStorage
{
    public class AdmissionCommitteeContext : DbContext
    {
        /// <summary>
        /// Сущность <see cref="Student"/>
        /// </summary>
        public DbSet<Student> Students { get; set; }

        /// <summary>
        /// Создает экземпляр <see cref="AdmissionCommitteeContext"/>
        /// </summary>
        public AdmissionCommitteeContext() => Database.EnsureCreated();

        /// <summary>
        /// Настройка подключения к базе данных
        /// </summary>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer(
                @"Server=(localdb)\mssqllocaldb;Database=AdmissionCommitteeDatabase;Trusted_Connection=True;");

        /// <summary>
        /// Настройка модели данных
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Gender)
                    .HasConversion<int>();

                entity.Property(e => e.EducationalForm)
                    .HasConversion<int>();

                entity.Property(e => e.Birthday)
                    .IsRequired();

                entity.Property(e => e.MathScores).HasColumnType("decimal(5,2)");


                entity.Property(e => e.PointsInRussianLanguage).HasColumnType("decimal(5,2)");

                entity.Property(e => e.ComputerScienceScores).HasColumnType("decimal(5,2)");
            });
        }

    }
}
