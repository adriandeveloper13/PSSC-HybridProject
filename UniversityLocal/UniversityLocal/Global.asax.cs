using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using University.BusinessLogic;
using University.DataLayer;
using University.Generic.Exceptions;
using University.Models.StudyYear;

namespace UniversityLocal
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            DataAdapterService.InitializeMapper();

            //try
            //{
            //    var dataLayerCourse = new Courses(Guid.NewGuid(), "VisualBasic", "www.vsB-upt.ro");
            //    var modelsCourse = new Course();
            //    modelsCourse = dataLayerCourse.CopyTo<Course>();

            //    modelsCourse.RegistrationNumber = new UniqueIdentifier(Guid.NewGuid());
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}


            
        }
    }
}
