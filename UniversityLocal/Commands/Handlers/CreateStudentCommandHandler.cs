using System;
using System.Threading.Tasks;
using AutoMapper;
using Interfaces.Commands;
using University.DataLayer;
using University.DataLayer.Implementation.Repositories;
using University.Models.StudyYear;

namespace Commands.Handlers
{
    public class CreateStudentCommandHandler : ICommandHandler<CreateStudentCommand>
    {
        //The dispatcher takes a command and relies on dependency injection to find a handler for this command, 
        //in this case, it will match the CreateStudentCommand with CreateStudentCommandHandler


        public async Task<CommandResult> Execute(CreateStudentCommand command)
        {


            //here we should have
            //var student = factory.createStudent(command)//where command is the student
            //commandDispatcher.dispatch()
            if (command != null)
            {
                try
                {
                    Mapper.Initialize(cfg =>
                            {
                                cfg.CreateMap<CreateStudentCommand, Students>()
                                //.DisableCtorValidation()
                                .ForMember(dbUsr => dbUsr.Id, vmUsr => vmUsr.MapFrom(vm => vm.RegistrationNumber))
                                .ForMember(dbUsr => dbUsr.Name, vmUsr => vmUsr.MapFrom(vm => vm.Name.Text))
                                .ForMember(dbUsr => dbUsr.Credits, vmUsr => vmUsr.MapFrom(vm => vm.Credits._credits));
                            });

                    Mapper.Configuration.AssertConfigurationIsValid();

                    var studentRepository = new StudentRepository();
                    var modelCommand = Mapper.Map<CreateStudentCommand, Students>(command);

                    var student = await studentRepository.CreateAsync(modelCommand);
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
