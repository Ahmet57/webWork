using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace testAzure.Controllers
{
    public class TeachersController : ApiController
    {
        // GET api/Students
        public IEnumerable<Teachers> Get()
        {
            using (ahmetDatabaseEntities studentSystemEntities = new ahmetDatabaseEntities())
            {
                Console.WriteLine("get");
                return studentSystemEntities.Teachers.ToList();
            }
        }

        // GET api/Students/5
        public Teachers Get(int id)
        {
            using (ahmetDatabaseEntities studentSystemEntities = new ahmetDatabaseEntities())
            {
                Console.WriteLine("get");
                return studentSystemEntities.Teachers.FirstOrDefault(x => x.ID == id);
            }
        }

        public Teachers GetTeacher(string UserName, string Password)
        {
            using (ahmetDatabaseEntities studentSystemEntities = new ahmetDatabaseEntities())
            {
                return studentSystemEntities.Teachers.FirstOrDefault(x => x.UserName == UserName && x.Password == Password);
            }
        }

        // POST api/Students
        public void Post([FromBody] Teachers sub)
        {
            using (ahmetDatabaseEntities studentSystemEntities = new ahmetDatabaseEntities())
            {
                Console.WriteLine("get");
                studentSystemEntities.Teachers.Add(sub);
                studentSystemEntities.SaveChanges();
            }
        }


        // DELETE api/Teachers/id
        public void Delete(int teacherID)
        {
            using (ahmetDatabaseEntities studentSystemEntities = new ahmetDatabaseEntities())
            {
                Teachers teacher = studentSystemEntities.Teachers.FirstOrDefault(x => x.ID == teacherID);
                studentSystemEntities.Teachers.Remove(teacher);
                studentSystemEntities.SaveChanges();
            }
        }
    }
}
