using System.Web.Mvc;

namespace TeamX.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AnotherLink()
        {
            return View("Index");
        }

        [HttpPost]
        public string CallVisionApi(string imgsrc)
        {
            return ComputerVisionIntegration.MakeAnalysisRequest(imgsrc).Result;
        }

    }
}
