﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using University.Models;

namespace UniversityLocal.Controllers
{
    public class ProfessorController : Controller
    {
        // GET: Professor
        public ActionResult Index()
        {
            return View();
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

        public virtual async Task<T> SetGradeForStudentActivity()
        {
            return null;
        }

        public virtual async Task<T> SetLaboratoryPresenceLevel(List<Student> students )
        {
            return null;
        }

        public virtual async Task<T> SetPercentOfStudentActivityForFinalAverageGrades(List<Student> students)
        {
            return null;
        }



        // GET: Professor/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Professor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Professor/Create
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

        // GET: Professor/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Professor/Edit/5
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

        // GET: Professor/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Professor/Delete/5
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
