using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Interfaces.Commands;
using University.Common.Enums.SchoolSubjectEnums;
using University.DataLayer;
using University.DataLayer.Implementation.Repositories;

namespace Commands.Handlers.SchoolSubjectHandlers
{
    public class CreateOrUpdateSchoolSubjectCommandHandler:ICommandHandler<CreateOrUpdateSchoolSubjectCommand>
    {
        public async Task<CommandResult> Execute(CreateOrUpdateSchoolSubjectCommand command)
        {
            if (command != null)
            {
                try
                {
                    Mapper.Initialize(cfg =>
                    {
                        cfg.CreateMap<CreateOrUpdateSchoolSubjectCommand, SchoolSubjects>()
                        .ForMember(dbUsr => dbUsr.Id, vmUsr => vmUsr.MapFrom(vm => vm.Id))
                        .ForMember(dbUsr => dbUsr.Name, vmUsr => vmUsr.MapFrom(vm => vm.Name))
                        .ForMember(dbUsr => dbUsr.Credits, vmUsr => vmUsr.MapFrom(vm => vm.Credits));
                    });

                    var schoolSubjectRepository = new StudyYearRepository<SchoolSubjects>();
                    var modelCommand = Mapper.Map<CreateOrUpdateSchoolSubjectCommand, SchoolSubjects>(command);

                    if (command.CommandType == SchoolSubjectCommandType.CreateCommand)
                    {
                        await schoolSubjectRepository.CreateAsync(modelCommand).ConfigureAwait(false);
                    }
                    else
                    {
                        await schoolSubjectRepository.UpdateAsync(modelCommand).ConfigureAwait(false);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return null;
        }
    }
}
