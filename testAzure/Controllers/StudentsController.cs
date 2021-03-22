using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace testAzure.Controllers
{
    public class StudentsController : ApiController
    {
        // GET api/Students
        public IEnumerable<Students> Get()
        {
            using (ahmetDatabaseEntities studentSystemEntities = new ahmetDatabaseEntities())
            {
                Console.WriteLine("get");
                return studentSystemEntities.Students.ToList();
            }
        }

        // GET api/Students/5
        public Students GetStudent(string UserName, string Password)
        {
            using (ahmetDatabaseEntities studentSystemEntities = new ahmetDatabaseEntities())
            {
                return studentSystemEntities.Students.FirstOrDefault(x => x.UserName == UserName && x.Password == Password);
            }
        }
        public Students Get(int id)
        {
            using (ahmetDatabaseEntities studentSystemEntities = new ahmetDatabaseEntities())
            {
                Console.WriteLine("get");
                return studentSystemEntities.Students.FirstOrDefault(x => x.ID == id);
            }
        }

        // POST api/Students
        public void Post([FromBody] Students sub)
        {
            using (ahmetDatabaseEntities studentSystemEntities = new ahmetDatabaseEntities())
            {
                Console.WriteLine("get");
                studentSystemEntities.Students.Add(sub);
                studentSystemEntities.SaveChanges();
            }
        }

        // DELETE api/Students/id
        public void Delete(int studentID)
        {
            using (ahmetDatabaseEntities studentSystemEntities = new ahmetDatabaseEntities())
            {
                Students student = studentSystemEntities.Students.FirstOrDefault(x => x.ID == studentID);
                studentSystemEntities.Students.Remove(student);
                studentSystemEntities.SaveChanges();
            }
        }
    }
}
