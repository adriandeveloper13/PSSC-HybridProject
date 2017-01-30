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

namespace DbQueryExecutors.Handlers.LaboratoryHandlers
{
    public class GetLaboratoryQueryHandler : IQueryHandler<GetLaboratoriesQuery, GetLaboratoriesQueryResult>
    {
        public async Task<GetLaboratoriesQueryResult> Retrieve(GetLaboratoriesQuery query)
        {
            try
            {
                var getLaboratoriesQueryResult = new GetLaboratoriesQueryResult();
                getLaboratoriesQueryResult.IsSuccess = false;

                var laboratoriesRepository = new StudyYearRepository<Laboratories>();
                List<Laboratories> databaseQueryLaboratories = (List<Laboratories>)await laboratoriesRepository.GetAllAsync().ConfigureAwait(false);


                getLaboratoriesQueryResult.LaboratoriesList = StudyYearFactory.Instance.CreateLaboratoriesList();
                if (databaseQueryLaboratories == null)
                {

                    return getLaboratoriesQueryResult;

                }

                getLaboratoriesQueryResult.IsSuccess = true;
                foreach (var lab in databaseQueryLaboratories)
                {
                    var modelLaboratoryQuery = lab.CopyTo<Laboratory>();
                    getLaboratoriesQueryResult.LaboratoriesList.Add(modelLaboratoryQuery);
                }


                return getLaboratoriesQueryResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
 