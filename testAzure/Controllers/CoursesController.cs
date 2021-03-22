using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace testAzure.Controllers
{
    public class CoursesController : ApiController
    {
        // GET api/Courses
        public IEnumerable<Courses> Get()
        {
            using (ahmetDatabaseEntities studentSystemEntities = new ahmetDatabaseEntities())
            {
                Console.WriteLine("get");
                return studentSystemEntities.Courses.ToList();
            }
        }

        // GET api/GetCourseByID/5
        public Courses Get(int id)
        {
            using (ahmetDatabaseEntities studentSystemEntities = new ahmetDatabaseEntities())
            {
                Console.WriteLine("get");
                return studentSystemEntities.Courses.FirstOrDefault(x => x.ID == id);
            }
        }


        // POST api/Courses
        public void Post([FromBody] Courses sub)
        {
            using (ahmetDatabaseEntities studentSystemEntities = new ahmetDatabaseEntities())
            {
                Console.WriteLine("get");
                studentSystemEntities.Courses.Add(sub);
                studentSystemEntities.SaveChanges();
            }
        }

        // PUT api/Courses/5
        public void PutEnrollment(int courseID, int studentID)
        {
            using (ahmetDatabaseEntities studentSystemEntities = new ahmetDatabaseEntities())
            { 
                Courses course = studentSystemEntities.Courses.FirstOrDefault(x => x.ID == courseID);
                Students student = studentSystemEntities.Students.FirstOrDefault(x => x.ID == studentID);
                course.NumberOfEnrollments = course.NumberOfEnrollments + 1;
                course.EnrolledStudents = course.EnrolledStudents + "," + student.StudentName + " " + student.StudentSurname;
                student.EnrolledCourses = student.EnrolledCourses + "," + course.CourseName;
                studentSystemEntities.SaveChanges();

                
            }
        }

        public void PutDisEnrollment(int courseID, int studentID)
        {
            using (ahmetDatabaseEntities studentSystemEntities = new ahmetDatabaseEntities())
                
            {
                Courses course = studentSystemEntities.Courses.FirstOrDefault(x => x.ID == courseID);
                Students student = studentSystemEntities.Students.FirstOrDefault(x => x.ID == studentID);

                course.NumberOfEnrollments = course.NumberOfEnrollments - 1;

                List<string> words = course.EnrolledStudents.Split(',').ToList();
                words.Remove(student.StudentName + " " + student.StudentSurname);
                course.EnrolledStudents = String.Join(",", words.ToArray());

                List<string> words2 = student.EnrolledCourses.Split(',').ToList();
                words2.Remove(course.CourseName);
                student.EnrolledCourses = String.Join(",", words2.ToArray());

                studentSystemEntities.SaveChanges();
            }
        }
        public void PutCourseByID(int courseID, string startTime, string endTime, string context)
        {
            using (ahmetDatabaseEntities studentSystemEntities = new ahmetDatabaseEntities())
            {
                Courses course = studentSystemEntities.Courses.FirstOrDefault(x => x.ID == courseID);
                course.CourseStartTime = startTime;
                course.CourseEndTime = endTime;
                course.Context = context;
                studentSystemEntities.SaveChanges();
            }
        }

        // DELETE api/Courses/id
        public void Delete(int courseID)
        {
            using (ahmetDatabaseEntities studentSystemEntities = new ahmetDatabaseEntities())
            {
                Courses course = studentSystemEntities.Courses.FirstOrDefault(x => x.ID == courseID);
                studentSystemEntities.Courses.Remove(course);
                studentSystemEntities.SaveChanges();
            }
        }
        

        public string GetEnrollment(string courseID, string studentID)
        {
            using (ahmetDatabaseEntities studentSystemEntities = new ahmetDatabaseEntities())
            {
                int courseIDx = Int16.Parse(courseID);
                int studentIDx = Int16.Parse(studentID);

                Courses course = studentSystemEntities.Courses.FirstOrDefault(x => x.ID == courseIDx);
                Students student = studentSystemEntities.Students.FirstOrDefault(x => x.ID == studentIDx);
                course.NumberOfEnrollments = course.NumberOfEnrollments + 1;
                course.EnrolledStudents = course.EnrolledStudents + "," + student.StudentName + " " + student.StudentSurname;
                student.EnrolledCourses = student.EnrolledCourses + "," + course.CourseName;
                studentSystemEntities.SaveChanges();
                return "ok";
            }
        }

        public string GetDisEnrollment(string courseID, string studentID)
        {
            using (ahmetDatabaseEntities studentSystemEntities = new ahmetDatabaseEntities())
            {
                int courseIDx = Int16.Parse(courseID);
                int studentIDx = Int16.Parse(studentID);
                Courses course = studentSystemEntities.Courses.FirstOrDefault(x => x.ID == courseIDx);
                Students student = studentSystemEntities.Students.FirstOrDefault(x => x.ID == studentIDx);

                course.NumberOfEnrollments = course.NumberOfEnrollments - 1;

                List<string> words = course.EnrolledStudents.Split(',').ToList();
                words.Remove(student.StudentName + " " + student.StudentSurname);
                course.EnrolledStudents = String.Join(",", words.ToArray());

                List<string> words2 = student.EnrolledCourses.Split(',').ToList();
                words2.Remove(course.CourseName);
                student.EnrolledCourses = String.Join(",", words2.ToArray());

                studentSystemEntities.SaveChanges();
                return "ok";
            }
        }

        public void GetEditCourseByID(string courseID, string startTime, string endTime, string context)
        {
            using (ahmetDatabaseEntities studentSystemEntities = new ahmetDatabaseEntities())
            {
                int courseIDx = Int16.Parse(courseID);
                Courses course = studentSystemEntities.Courses.FirstOrDefault(x => x.ID == courseIDx);
                course.CourseStartTime = startTime;
                course.CourseEndTime = endTime;
                course.Context = context;
                studentSystemEntities.SaveChanges();
            }
        }
    }
}
