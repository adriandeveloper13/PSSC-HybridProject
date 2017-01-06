using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using University.Models;
using University.Models.Deanship;
using University.Models.StudyYear;

namespace UniversityLocal.Controllers
{
    public class ProfessorController : Controller
    {
        // GET: Teacher
        public ActionResult Index()
        {
            return View();
        }

        public virtual async Task<SchoolSubject> GetSchoolSubjectsById()
        {
            //createStudentCommand
            //pt fiecare actiune o comanda
            //o lista de comenzi
            //bag comanda in lista 
            //odata ce handlerul a luat o comanda o scot din lista 
            //din handler
            //event pe lista (cand scot sau bag comenzi)
            //conceptul de bus  
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

        public virtual async Task<Deanship> SetLaboratoryPresenceLevel(List<Student> students )
        {
            return null;
        }

        public virtual async Task<Deanship> SetPercentOfStudentActivityForFinalAverageGrades(List<Student> students)
        {
            return null;
        }



        // GET: Teacher/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Teacher/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Teacher/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Teacher/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Teacher/Edit/5
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

        // GET: Teacher/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Teacher/Delete/5
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
