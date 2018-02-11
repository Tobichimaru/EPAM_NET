using System.Web.Mvc;
using ControllersWithCustomFactory.Infrastructure;

namespace ControllersWithCustomFactory.Controllers
{
    public class RemoteDataController : Controller
    {
        // GET: RemoteData
        public ActionResult Index()
        {
            var service = new RemoteService();
            var data = service.GetRemoteData();
            return View((object) data);
        }
    }
}