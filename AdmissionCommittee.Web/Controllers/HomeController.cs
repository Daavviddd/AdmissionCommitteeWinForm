using System.Diagnostics;
using AdmissionCommittee.Manager.Contracts;
using AdmissionCommittee.Models;
using AdmissionCommittee.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace AdmissionCommittee.Web.Controllers
{
    /// <summary>
    /// Контроллер для управления студентами 
    /// </summary>
    public class HomeController : Controller
    {
        private readonly IStudentsManager studentsManager;

        /// <summary>
        /// Инициализирует новый экземпляр контроллера HomeController
        /// </summary>
        public HomeController(IStudentsManager studentsManager)
        {
            this.studentsManager = studentsManager;
        }

        /// <summary>
        /// Отображает главную страницу со списком всех студентов
        /// </summary>
        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            var student = await studentsManager.GetAllStudentsAsync(cancellationToken);
            var statistics = await studentsManager.GetStatisticsAsync(cancellationToken);

            var studentModel = new StudentIndexViewModel
            {
                Students = student.ToList(),
                Statistics = statistics
            };

            return View(studentModel);
        }

        /// <summary>
        /// Отображает форму для добавления нового студента
        /// </summary>
        [HttpGet]
        public IActionResult Create() => View(new Student());

        /// <summary>
        /// Обрабатывает отправку формы для добавления нового студента
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Student studentModel, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return View(studentModel);
            }

            await studentsManager.AddStudentAsync(studentModel, cancellationToken);
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// Отображает форму для редактирования существующего студента
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id, CancellationToken cancellationToken)
        {
            var student = await studentsManager.GetStudentByIdAsync(id, cancellationToken);

            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        /// <summary>
        /// Обрабатывает отправку формы для редактирования студента
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, Student studentModel, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return View(studentModel);
            }

            studentModel.Id = id;

            await studentsManager.UpdateStudentAsync(studentModel, cancellationToken);
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// Отображает страницу подтверждения удаления студента
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            var student = await studentsManager.GetStudentByIdAsync(id, cancellationToken);

            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        /// <summary>
        /// Выполняет удаление студента после подтверждения
        /// </summary>
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(Guid id, CancellationToken cancellationToken)
        {
            await studentsManager.DeleteStudentAsync(id, cancellationToken);
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// Отображает страницу с политикой конфиденциальности
        /// </summary>
        public IActionResult Privacy()
        {
            return View();
        }

        /// <summary>
        /// Отображает страницу ошибки с информацией о запросе
        /// </summary>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
