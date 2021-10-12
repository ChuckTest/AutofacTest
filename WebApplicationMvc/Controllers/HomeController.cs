using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationMvc.Helper.Validation;
using WebApplicationMvc.Models;

namespace WebApplicationMvc.Controllers
{
    public class HomeController : Controller
    {
        public ValidationHelperBase<Student> StudentValidationHelper { get; set; }

        public List<Student> StudentList { get; set; }

        public ActionResult Index()
        {
            var instance = DependencyResolver.Current.GetService<ValidationHelperBase<Student>>();
            instance.CheckExist(1);

            Student student = new Student();
            var students = DependencyResolver.Current.GetService<List<Student>>();
            students.Add(student);
            Console.WriteLine(students.Count);

            StudentList.Add(student);

            StudentValidationHelper.CheckExist(1);
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}