using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using Commands;
using Interfaces.Commands;
using Interfaces.Queries;
using University.Models.StudyYear;
using University.Services;

namespace UniversityLocal.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentService _service;
        private readonly IQueryDispatcher _queryDispatcher;
        private readonly ICommandDispatcher _commandDispatcher;

        public StudentController( ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
        {
            _commandDispatcher = commandDispatcher;
            _queryDispatcher = queryDispatcher;          
        }

        // GET: Student
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> AddStudent()
        {
            var student = StudyYearFactory.Instance.CreateStudent(new Guid(), "John", 60);
            var createStudentCommand = new CreateStudentCommand(student);
            await _commandDispatcher.Dispatch(createStudentCommand);
           
           //_service.AddStudent(student);

            //return student;
            return null;
        }

        public virtual async Task<SchoolSubject> ListSchoolSubjectGrades()
        {
            return null;
        }
        // GET: Student/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Student/Create
        public ActionResult CreateStudent()
        {
            return View();
        }

        // POST: Student/Create
        [HttpPost]
        public ActionResult CreateStudent(Student student)
        {
            return View();
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Student/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Student/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
