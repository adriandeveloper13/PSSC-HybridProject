using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DbQueryExecutors.Queries.SchoolSubjectsQueries;
using Interfaces.Queries;
using University.DataLayer;
using University.DataLayer.Implementation.Repositories;
using University.Generic;
using University.Generic.Exceptions;
using University.Models.StudyYear;

namespace DbQueryExecutors.Handlers.SchoolSubjectHandlers
{
    public class UpdateSchoolSubjectQueryHandler : IQueryHandler<UpdateSchoolSubjectQuery, UpdateSchoolSubjectQueryResult>
    {
        public async Task<UpdateSchoolSubjectQueryResult> Retrieve(UpdateSchoolSubjectQuery query)
        {
            try
            {
                var updateSchoolSubjectQueryResult = new UpdateSchoolSubjectQueryResult();
                updateSchoolSubjectQueryResult.IsSuccess = false;

                var schoolSubjects = new StudyYearRepository<SchoolSubjects>();
                var databaseQuerySchoolSubject = await schoolSubjects.GetAsync(query.SchoolSubjectId).ConfigureAwait(false);


                Mapper.Initialize(cfg =>
                {
                    cfg.CreateMap<SchoolSubjects, SchoolSubject>()
                                             .ForMember(vm => vm.Id, dbUsr => dbUsr.MapFrom(db => new UniqueIdentifier { UniqueId = db.Id }))
                     .ForMember(vm => vm.Name, dbUsr => dbUsr.MapFrom(db => new PlainText { Name = db.Name }))
                     .ForMember(vm => vm.ExamProportion, dbUsr => dbUsr.MapFrom(db => new Proportion { FinalProportion = db.ExamProportion }))
                     .ForMember(vm => vm.Credits, dbUsr => dbUsr.MapFrom(db => new Credits { _credits = db.Credits }));
                });


                if (databaseQuerySchoolSubject == null)
                {
                    return null;

                }

                updateSchoolSubjectQueryResult.IsSuccess = true;
                updateSchoolSubjectQueryResult.UpdatedSchoolSubject = StudyYearFactory.Instance.CreateSchoolSubject();

                var modelSchoolSubjectQuery = Mapper.Map<SchoolSubjects, SchoolSubject>(databaseQuerySchoolSubject);
                updateSchoolSubjectQueryResult.UpdatedSchoolSubject = modelSchoolSubjectQuery;

                return updateSchoolSubjectQueryResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
