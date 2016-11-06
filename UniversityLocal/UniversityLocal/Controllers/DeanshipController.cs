using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using University.Models;

namespace UniversityLocal.Controllers
{
    public class DeanshipController : Controller
    {
        // GET: Deanship
        public ActionResult Index()
        {
            return View();
        }

        // GET: Deanship/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Deanship/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Deanship/Create
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

        // GET: Deanship/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Deanship/Edit/5
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

        // GET: Deanship/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Deanship/Delete/5
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


        [HttpPost]
        public virtual async Task<SchoolSubject> DefineSchoolSubjects()
        {
            return null;
        }

        public virtual async Task<SchoolSubjectStudentAssignments> AssignSchoolSubjectToStudent()
        {
            return null;
        }

        public virtual async Task<SchoolSubjectStudentAssignments> CalculateAverageOfGradesForAStudentSchoolSubject()
        {
            return null;
        }

        public virtual async Task<T> GenerateGradeRaport()
        {

            return null;
        }

    }
}
