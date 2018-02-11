using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using University.Classes;

namespace UniversityUnitTests
{
    [TestClass]
    public class UniversityTest
    {

        [TestMethod]
        public void SendOneHomeWork()
        {
            Student student = new Student("Bob");
            Professor prof = new Professor("Mr.Black");
            Course course = new Course("Algebra", prof);
            HomeTask task = new HomeTask("first task", "wow", course);
            course.AddObserver(student);
            course.NotifyObservers(task);
            Debug.WriteLine(Archive.Instance.GetMark(student, course, task));
        }

        [TestMethod]
        public void CreateSomeInstances()
        {
            Student student1 = new Student("Bob");
            Student student2 = new Student("Alex");
            Student student3 = new Student("Steve");

            Professor prof1 = new Professor("Mr.Black");
            Professor prof2 = new Professor("Mr.White");

            Course course1 = new Course("Algebra", prof1);
            Course course2 = new Course("Geometry", prof2);

            HomeTask task1 = new HomeTask("first task", "wow", course1);
            HomeTask task2 = new HomeTask("second task", "wow", course1);
            HomeTask task3 = new HomeTask("first task", "wow", course2);
            HomeTask task4 = new HomeTask("second task", "wow", course2);

            course1.AddObserver(student1);
            course1.AddObserver(student2);
            course2.AddObserver(student2);
            course2.AddObserver(student3);

            course1.NotifyObservers(task1);
            course1.NotifyObservers(task2);

            course2.NotifyObservers(task3);
            course2.NotifyObservers(task4);

            Debug.WriteLine(Archive.Instance.GetMark(student2, course1, task2));
            Debug.WriteLine(Archive.Instance.GetMark(student2, course2, task3));
        }

    }
}
