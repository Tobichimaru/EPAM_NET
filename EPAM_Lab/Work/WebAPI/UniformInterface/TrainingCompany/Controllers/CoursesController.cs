using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TrainingCompany.Controllers
{
    public class CoursesController : ApiController
    {
        static List<Course> courses = InitCourses();

        private static List<Course> InitCourses()
        {
            var ret = new List<Course>();
            ret.Add(new Course
            {
                Id = 1,
                Title = "HTML"
            });
            ret.Add(new Course
            {
                Id = 2,
                Title = "CSS"
            });
            return ret;
        }

        [HttpGet]
        public IEnumerable<Course> AllCourses()
        {
            return courses;
        }

        public Course Get(int id)
        {
            var ret = courses.Where(c => c.Id == id).FirstOrDefault();
            // if null = 404
            return ret;
        }

        public void Post(int id, [FromBody]Course course)
        {
            var ret = courses.Where(c => c.Id == id).FirstOrDefault();
            ret.Title = course.Title;
        }

        public void Post([FromBody]Course course)
        {
            course.Id = courses.Count();
            courses.Add(course);
        }
    }

    public class Course
    {
        public int Id;
        public string Title;
    }
}
