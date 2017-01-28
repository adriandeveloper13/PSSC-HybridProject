using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DbQueryExecutors.Queries.SchoolSubjectsQueries;
using Interfaces.Queries;
using University.BusinessLogic;
using University.DataLayer;
using University.DataLayer.Implementation.Repositories;
using University.Generic;
using University.Generic.Exceptions;
using University.Models.StudyYear;
using University.Models.Teacher;

namespace DbQueryExecutors.Handlers.CourseHandlers
{
    public class GetCourseQueryHandler : IQueryHandler<GetCoursesQuery, GetCoursesQueryResult>
    {
        public async Task<GetCoursesQueryResult> Retrieve(GetCoursesQuery query)
        {
            try
            {
                var getCoursesQueryResult = new GetCoursesQueryResult();
                getCoursesQueryResult.IsSuccess = false;

                var coursesRepository = new StudyYearRepository<Courses>();
                List<Courses> databaseQueryCourses = (List<Courses>)await coursesRepository.GetAllAsync().ConfigureAwait(false);

                getCoursesQueryResult.CoursesList = StudyYearFactory.Instance.CreateCoursesList();
                if (databaseQueryCourses == null)
                {
                    return getCoursesQueryResult;

                }

                getCoursesQueryResult.IsSuccess = true;
                foreach (var cours in databaseQueryCourses)
                {
                    var modelCoursQuery = cours.CopyTo<Course>();
                    getCoursesQueryResult.CoursesList.Add(modelCoursQuery);
                }


                return getCoursesQueryResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
 