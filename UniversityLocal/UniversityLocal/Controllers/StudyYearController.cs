using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Commands;
using Commands.Handlers;
using DbQueryExecutors;
using DbQueryExecutors.Queries.SchoolSubjectsQueries;
using Interfaces.Commands;
using Interfaces.Queries;
using University.Common.Enums.SchoolSubjectEnums;
using University.Generic;
using University.Generic.Exceptions;
using University.Models.Deanship;
using University.Models.StudyYear;

namespace UniversityLocal.Controllers
{
    public class StudyYearController : BaseController
    {
        private readonly IQueryDispatcher _queryDispatcher;
        private readonly ICommandDispatcher _commandDispatcher;
        //private readonly StudentService _service;

        public StudyYearController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
        {
            _commandDispatcher = commandDispatcher;
            _queryDispatcher = queryDispatcher;
        }

        public async Task<ActionResult> GetAllCourses(GetCoursesQuery courseQuery)
        {
            if (courseQuery == null)
            {
                courseQuery = new GetCoursesQuery();
            }

            var courses  = await _queryDispatcher.Dispatch<GetCoursesQuery, GetCoursesQueryResult>(courseQuery);
            if (!courses.IsSuccess)
            {
                courses.CoursesList = StudyYearFactory.Instance.CreateCoursesList();
            }

            return View("ListCourses", courses.CoursesList);
        }

        public ActionResult AddCourse()
        {
            return View("CreateCourse");
        }

        [HttpPost]
        public async Task<JsonResult> AddCourse(CreateCourseCommand createCourseCommand)
        {
            var course = StudyYearFactory.Instance.CreateCourse(Guid.NewGuid(),createCourseCommand.Name,createCourseCommand.ContentLink);

            try
            {
                _commandDispatcher.Dispatch(new CreateCourseCommand(course));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Json("");
        }

        public async Task<ActionResult> GetAllLaboratories(GetLaboratoriesQuery laboratoryQuery)
        {
            if (laboratoryQuery == null)
            {
                laboratoryQuery = new GetLaboratoriesQuery();
            }

            var laboratory = await _queryDispatcher.Dispatch<GetLaboratoriesQuery, GetLaboratoriesQueryResult>(laboratoryQuery);
            if (!laboratory.IsSuccess)
            {
                laboratory.LaboratoriesList = StudyYearFactory.Instance.CreateLaboratoriesList();
            }

            return View("ListLaboratories", laboratory.LaboratoriesList);
        }

        public ActionResult AddLaboratory()
        {
            return View("CreateLaboratory");
        }

        [HttpPost]
        public async Task<JsonResult> AddLaboratory(CreateLaboratoryCommand createLaboratoryCommand)
        {
            var laboratory = StudyYearFactory.Instance.CreateLaboratory(Guid.NewGuid(), createLaboratoryCommand.Name, createLaboratoryCommand.ContentLink);

            try
            {
                await _commandDispatcher.Dispatch(new CreateLaboratoryCommand(laboratory));

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Json("");
        }
        [HttpPost]
        public async Task<JsonResult> AddSchoolSubject(CreateOrUpdateSchoolSubjectCommand schoolSubjectCommand)
        {
            //here I must to have an parameter like CreateSchoolSubject command without complex properties like PlainText
            var schoolSubject = StudyYearFactory.Instance.CreateSchoolSubject(Guid.NewGuid(), schoolSubjectCommand.Name,
                schoolSubjectCommand.ExamProportion, schoolSubjectCommand.Credits, schoolSubjectCommand.EvaluationType,
                new List<Laboratory>(), new List<Course>());
            try
            {
                await _commandDispatcher.Dispatch(new CreateOrUpdateSchoolSubjectCommand(schoolSubject, SchoolSubjectCommandType.CreateCommand));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Json("");
        }


        public async Task<ActionResult> GetAllSchoolSubjects(GetSchoolSubjectQuery schoolSubjectQuery = null)
        {
            if (schoolSubjectQuery == null)
            {
                schoolSubjectQuery = new GetSchoolSubjectQuery();
            }
            var schoolSubjects =
                await _queryDispatcher.Dispatch<GetSchoolSubjectQuery, GetSchoolSubjectQueryResult>(schoolSubjectQuery);
            if (!schoolSubjects.IsSuccess)
            {
                return View("ListSchoolSubjects", new List<SchoolSubject>());
            }

            return View("ListSchoolSubjects", schoolSubjects.SchoolSubjectsList);
        }

        public ActionResult AddSchoolSubject()
        {
            return View("CreateSchoolSubject");
        }

        // GET: Student/Edit/5
        public async Task<ActionResult> UpdateSchoolSubject(Guid schoolSubjectId)
        {
            var updateSchoolSubjectQuery = new UpdateSchoolSubjectQuery(schoolSubjectId);
            var schoolSubject =
                await _queryDispatcher.Dispatch<UpdateSchoolSubjectQuery, UpdateSchoolSubjectQueryResult>(updateSchoolSubjectQuery);

            ViewBag.SchoolSubjectId = schoolSubjectId;
            ViewBag.SchoolSubjectName = schoolSubject.UpdatedSchoolSubject.Name.Name;
            ViewBag.SchoolSubjectCredits = schoolSubject.UpdatedSchoolSubject.Credits._credits;

            return View("EditSchoolSubject", schoolSubject.UpdatedSchoolSubject);
        }

        [HttpPost]
        public async Task<JsonResult> UpdateSchoolSubject(CreateOrUpdateSchoolSubjectCommand updateSchoolSubjectCommand)
        {
            try
            {
                updateSchoolSubjectCommand.CommandType = SchoolSubjectCommandType.UpdateCommand;
                await _commandDispatcher.Dispatch(updateSchoolSubjectCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Json("return");
        }
        public virtual async Task<SchoolSubject> GetSchoolSubjectsById()
        {
            return null;
        }

        public virtual async Task<SchoolSubject> SetExamGradeForSchoolSubject()
        {
            return null;
        }

        public virtual async Task<SchoolSubject> UpdateExameGradeForSchoolSubject()
        {
            return null;
        }

        public virtual async Task<Deanship> SetGradeForStudentActivity()
        {
            return null;
        }

        public virtual async Task<Deanship> SetLaboratoryPresenceLevel(List<Student> students)
        {
            return null;
        }

        public virtual async Task<Deanship> SetPercentOfStudentActivityForFinalAverageGrades(List<Student> students)
        {
            return null;
        }
    }
}