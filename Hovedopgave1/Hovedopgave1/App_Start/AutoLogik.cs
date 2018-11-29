using Hovedopgave1.Concrete;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Hovedopgave1.App_Start
{
    public static class AutoLogik
    {
        public static void SletAutomatiskStudent()
        {
            //var dato = DateTime.Now.AddDays(-1);


            using (var dbcontext = new EFDbContext())
            {

               var students = dbcontext.Students.SqlQuery("Delete From Students Where DatoForOprettelse <= dateadd(day, -1, getdate())");
               // var findstudent = dbcontext.Students.SqlQuery("Select * from Students Where DatoForOprettelse <= @date", new SqlParameter("@date", dato));

                //if (findstudent != null)
                //{
               //var deletestudent = dbcontext.Students.SqlQuery("Delete from Students Where DatoForOprettelse <= @dato", new SqlParameter("@dato", dato));

                //}
            }


        }
    }
}