namespace Hotel.Web.Controllers
{
    using System.Web.Mvc;

    [RoutePrefix("images")]
    public class ImagesController : Controller
    {
        [HttpGet]
        [Route]
        public ActionResult CategoriesImages()
        {
            return View();
        }

        [HttpGet]
        [Route("rooms")]
        public ActionResult Rooms()
        {
            return View();
        }

        [HttpGet]
        [Route("restaurants")]
        public ActionResult Restaurants()
        {
            return View();
        }

        [HttpGet]
        [Route("meetingHalls")]
        public ActionResult MeetingHalls()
        {
            return View();
        }

        [HttpGet]
        [Route("bars")]
        public ActionResult Bars()
        {
            return View();
        }
    }
}