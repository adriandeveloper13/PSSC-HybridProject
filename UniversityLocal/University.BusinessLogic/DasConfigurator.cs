using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Models.StudyYear;

namespace University.BusinessLogic
{
    public static class DasConfigurator
    {
        //internal static void ConfigureStudent(IMapperConfiguration config)
        //{
        //    config.CreateMap<Student, Student>()
        //        .BeforeMap((source, destination) =>
        //        {
        //            source.Students.Configure(aspNetUser => { aspNetUser.AspNetRoles = null; });
        //        });

        //    config.CreateMap<DataLayer.Student, Student>()
        //        .BeforeMap((source, destination) =>
        //        {
        //            source.AspNetUsers.Configure(aspNetUser => { aspNetUser.AspNetRoles = null; });
        //        });
        //}

     

        #region Item configuration extension methods

        private static void Configure<T>(this IEnumerable<T> items, Action<T> applyConfiguration)
        {
            if (items == null)
            {
                return;
            }

            foreach (var item in items)
            {
                applyConfiguration(item);
            }
        }

        private static void Configure<T>(this T item, Action<T> applyConfiguration)
        {
            if (item == null)
            {
                return;
            }

            applyConfiguration(item);
        }

        #endregion
    }
}
