using System.Web.Mvc;
using ModelBinding.Models;

namespace ModelBinding.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        [ActionName("CreatePerson")]
        public ActionResult CreatePersonGet()
        {
            return View("CreatePerson");
        }

        [HttpPost]
        [ActionName("CreatePerson")]
        public ActionResult CreatePersonPost()
        {
            var person = new Person();
            if (TryUpdateModel(person, new FormValueProvider(ControllerContext)))
                return View("DisplayPerson", person);
            return View("CreatePerson");
        }

        [HttpGet]
        public ActionResult CreatePersonFromQuery()
        {
            var person = new Person();
            if (TryUpdateModel(person, new QueryStringValueProvider(ControllerContext)))
                return View("DisplayPerson", person);
            return View("CreatePerson");
        }
    }
}