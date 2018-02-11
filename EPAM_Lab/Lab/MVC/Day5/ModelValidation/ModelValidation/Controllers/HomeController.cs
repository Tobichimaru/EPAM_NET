using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ModelValidation.Models;

namespace ModelValidation.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View(new Voucher());
        }

		[HttpPost]
	    public ActionResult Index(Voucher model)
	    {
		    return View("Submited", model);
	    }
    }
}