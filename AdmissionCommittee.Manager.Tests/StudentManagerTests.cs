using AdmissionCommittee.Manager.Contracts;
using AdmissionCommittee.MemoryStorage.Contracts;
using AdmissionCommittee.Models;
using Ahatornn.TestGenerator;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;

namespace AdmissionCommittee.Manager.Tests
{
    /// <summary>
    /// Набор модульных тестов для проверки работы класса <see cref="StudentsManager"/>
    /// </summary>
    public class StudentManagerTests
    {
        private readonly IStudentsManager studentsManager;
        private readonly Mock<IStudentStorage> storageMock;
        private readonly Mock<ILogger> loggerMock;

        /// <summary>
        /// Инициализирует экземпляр <see cref="StudentsManagerTests"/>
        /// </summary>
        public StudentManagerTests()
        {
            storageMock = new Mock<IStudentStorage>();
            loggerMock = new Mock<ILogger>();

            var mockLoggerFactory = new Mock<ILoggerFactory>();
            mockLoggerFactory
                .Setup(f => f.CreateLogger(It.IsAny<string>()))
                .Returns(loggerMock.Object);

            studentsManager = new StudentsManager(storageMock.Object, mockLoggerFactory.Object);
        }

        /// <summary>
        /// Проверяет, что метод получения всех студентов возвращает корректную коллекцию
        /// </summary>
        [Fact]
        public async Task GetAllStudentsAsyncShouldReturnAllStudents()
        {
            var student1 = TestEntityProvider.Shared.Create<Student>();
            var student2 = TestEntityProvider.Shared.Create<Student>();

            storageMock.Setup(x => x.GetAllStudentsAsync())
                .ReturnsAsync(new List<Student> { student1, student2 });

            var result = await studentsManager.GetAllStudentsAsync();

            result.Should().BeEquivalentTo(new[] { student1, student2 });
            storageMock.Verify(x => x.GetAllStudentsAsync(), Times.Once);
            storageMock.VerifyNoOtherCalls();
        }

        /// <summary>
        /// Проверяет, что метод получения студента по ID возвращает корректного студента
        /// </summary>
        [Fact]
        public async Task GetStudentByIdAsyncShouldReturnStudent()
        {
            var student = TestEntityProvider.Shared.Create<Student>();
            storageMock.Setup(x => x.GetStudentByIdAsync(student.Id))
                .ReturnsAsync(student);

            var result = await studentsManager.GetStudentByIdAsync(student.Id);

            result.Should().BeEquivalentTo(student);
            storageMock.Verify(x => x.GetStudentByIdAsync(student.Id), Times.Once);
            storageMock.VerifyNoOtherCalls();
        }

        /// <summary>
        /// Проверяет, что метод получения студента по ID возвращает null при отсутствии студента
        /// </summary>
        [Fact]
        public async Task GetStudentByIdAsyncShouldReturnNull()
        {
            var nonExistentId = Guid.NewGuid();
            storageMock.Setup(x => x.GetStudentByIdAsync(nonExistentId))
                .ReturnsAsync((Student?)null);

            var result = await studentsManager.GetStudentByIdAsync(nonExistentId);

            result.Should().BeNull();
            storageMock.Verify(x => x.GetStudentByIdAsync(nonExistentId), Times.Once);
            storageMock.VerifyNoOtherCalls();
        }

        /// <summary>
        /// Проверяет, что метод добавления студента вызывает хранилище
        /// </summary>
        [Fact]
        public async Task AddStudentAsyncShouldCallStorage()
        {
            var student = TestEntityProvider.Shared.Create<Student>();
            storageMock.Setup(x => x.AddStudentAsync(student))
                .Returns(Task.CompletedTask);

            var act = () => studentsManager.AddStudentAsync(student);

            await act.Should().NotThrowAsync();
            storageMock.Verify(x => x.AddStudentAsync(student), Times.Once);
            storageMock.VerifyNoOtherCalls();
        }

        /// <summary>
        /// Проверяет, что метод обновления студента вызывает хранилище
        /// </summary>
        [Fact]
        public async Task UpdateStudentAsyncShouldCallStorage()
        {
            var student = TestEntityProvider.Shared.Create<Student>();
            storageMock.Setup(x => x.UpdateStudentAsync(student))
                .Returns(Task.CompletedTask);

            var act = () => studentsManager.UpdateStudentAsync(student);

            await act.Should().NotThrowAsync();
            storageMock.Verify(x => x.UpdateStudentAsync(student), Times.Once);
            storageMock.VerifyNoOtherCalls();
        }

        /// <summary>
        /// Проверяет, что метод удаления студента вызывает хранилище
        /// </summary>
        [Fact]
        public async Task DeleteStudentAsyncShouldCallStorage()
        {
            var studentId = Guid.NewGuid();
            storageMock.Setup(x => x.DeleteStudentAsync(studentId))
                .Returns(Task.CompletedTask);

            var act = () => studentsManager.DeleteStudentAsync(studentId);

            await act.Should().NotThrowAsync();
            storageMock.Verify(x => x.DeleteStudentAsync(studentId), Times.Once);
            storageMock.VerifyNoOtherCalls();
        }

        /// <summary>
        /// Проверяет, что метод получения статистики корректно вычисляет показатели
        /// </summary>
        [Fact]
        public async Task GetStatisticsAsyncShouldReturnCorrectStatistics()
        {
            var expectedStatistics = new StatisticsResult(3, 2); // 3 всего студентов, 2 прошли

            storageMock.Setup(x => x.GetStatisticsAsync()).ReturnsAsync(expectedStatistics);

            var result = await studentsManager.GetStatisticsAsync();

            result.Should().NotBeNull();
            result.TotalCount.Should().Be(3);
            result.PassedCount.Should().Be(2);
            result.NotPassedCount.Should().Be(1);
            result.PassedPercentage.Should().BeApproximately(66.67, 0.01); 

            storageMock.Verify(x => x.GetStatisticsAsync(), Times.Once);
            storageMock.VerifyNoOtherCalls();
        }

        /// <summary>
        /// Проверяет, что метод получения статистики корректно работает с пустым списком
        /// </summary>
        [Fact]
        public async Task GetStatisticsAsyncShouldReturnZeroStatistics()
        {
            var expectedStatistics = new StatisticsResult(0, 0);

            storageMock.Setup(x => x.GetStatisticsAsync())
                .ReturnsAsync(expectedStatistics);

            var result = await studentsManager.GetStatisticsAsync();

            result.Should().NotBeNull();
            result.TotalCount.Should().Be(0);
            result.PassedCount.Should().Be(0);
            result.NotPassedCount.Should().Be(0);
            result.PassedPercentage.Should().Be(0);

            storageMock.Verify(x => x.GetStatisticsAsync(), Times.Once);
        }

        /// <summary>
        /// Проверяет, что конструктор выбрасывает исключение при null фабрике логгера
        /// </summary>
        [Fact]
        public void ConstructorShouldThrowArgumentNullException()
        {
            var mockStorage = new Mock<IStudentStorage>();

            var act = () => new StudentsManager(mockStorage.Object, null!);

            act.Should().Throw<ArgumentNullException>();
        }

        /// <summary>
        /// Проверяет, что метод получения статистики корректно считает количество студентов и проходные баллы
        /// </summary>
        [Fact]
        public async Task GetStatisticsAsyncShouldCalculateCorrectly()
        {
            var student1 = TestEntityProvider.Shared.Create<Student>();

            student1.MathScores = 40;
            student1.PointsInRussianLanguage = 50;
            student1.ComputerScienceScores = 30;

            var student2 = TestEntityProvider.Shared.Create<Student>();

            student2.MathScores = 70;
            student2.PointsInRussianLanguage = 80;
            student2.ComputerScienceScores = 100;

            storageMock.Setup(x => x.GetAllStudentsAsync())
                .ReturnsAsync(new List<Student> { student1, student2 });

            storageMock.Setup(x => x.GetStatisticsAsync())
                .ReturnsAsync(() =>
                {
                    var students = new List<Student> { student1, student2 };
                    var total = students.Count;
                    var passed = students.Count(s =>
                        s.MathScores + s.PointsInRussianLanguage + s.ComputerScienceScores >= 150);
                    return new StatisticsResult(total, passed);
                });

            var result = await studentsManager.GetStatisticsAsync();

            result.Should().NotBeNull();
            result.TotalCount.Should().Be(2);
            result.PassedCount.Should().Be(1);
            result.NotPassedCount.Should().Be(1);
            result.PassedPercentage.Should().Be(50);

            storageMock.Verify(x => x.GetStatisticsAsync(), Times.Once);
        }
    }
}