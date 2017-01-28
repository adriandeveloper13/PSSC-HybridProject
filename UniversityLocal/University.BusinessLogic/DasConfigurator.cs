using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using University.DataLayer;
using University.Generic;
using University.Generic.Exceptions;
using University.Models.StudyYear;

namespace University.BusinessLogic
{
    public class DASConfigurator
    {
        public static void ConfigureCourses(IMapperConfiguration config)
        {
            config.CreateMap<Courses, Course>()
                 //.DisableCtorValidation()
                 //.ReverseMap()
                 //.ForMember(dbUsr => dbUsr.RegistrationNumber, vmUsr => vmUsr.MapFrom(vm => vm.RegistrationNumber))
                 //             .ForMember(dbUsr => dbUsr.Name, vmUsr => vmUsr.MapFrom(vm => vm.Name.Text))
                 //             .ForMember(dbUsr => dbUsr.Credits, vmUsr => vmUsr.MapFrom(vm => vm.Credits._credits));
                 //.ForMember(vm => vm.RegistrationNumber, dbUsr => dbUsr.MapFrom(db => new UniqueIdentifier { UniqueId = db.Id }))
                .ForMember(vm => vm.RegistrationNumber, dbCourse => dbCourse.MapFrom(db => new UniqueIdentifier { UniqueId = db.Id }))
                .ForMember(vm => vm.Name, dbUsr => dbUsr.MapFrom(db => new PlainText {Name = db.Name}));
            //.ForMember(vm => vm.ContentLink, dbUsr => dbUsr.MapFrom(db => db.ContentLink));
            //cfg.CreateMap<Course, Courses>()
            //    .ForMember(m => m.RegistrationNumber, opt => opt.MapFrom(db => db.RegistrationNumber.UniqueId));


            config.CreateMap<Course, Courses>()
              .ForMember(vm => vm.Id, dbCourse => dbCourse.MapFrom(db => db.RegistrationNumber.UniqueId))
                .ForMember(vm => vm.Name, dbUsr => dbUsr.MapFrom(db => db.Name.Name));
        }

        public static void ConfigureLaboratories(IMapperConfiguration config)
        {
            config.CreateMap<Laboratories, Laboratory>()
                //.DisableCtorValidation()
                //.ReverseMap()
                //.ForMember(dbUsr => dbUsr.Id, vmUsr => vmUsr.MapFrom(vm => vm.Id))
                //             .ForMember(dbUsr => dbUsr.Name, vmUsr => vmUsr.MapFrom(vm => vm.Name))
                //             .ForMember(dbUsr => dbUsr.ContentLink, vmUsr => vmUsr.MapFrom(vm => vm.ContentLink));
                .ForMember(vm => vm.RegistrationNumber, dbLab => dbLab.MapFrom(db => new UniqueIdentifier { UniqueId = db.Id }))
                .ForMember(vm => vm.Name, dbUsr => dbUsr.MapFrom(db => new PlainText { Name = db.Name }))
                .ForMember(vm => vm.ContentLink, dbUsr => dbUsr.MapFrom(db => db.ContentLink));

            config.CreateMap<Laboratory, Laboratories>()
              .ForMember(vm => vm.Id, dbCourse => dbCourse.MapFrom(db => db.RegistrationNumber.UniqueId))
                .ForMember(vm => vm.Name, dbUsr => dbUsr.MapFrom(db => db.Name.Name));
        }
    }
}
