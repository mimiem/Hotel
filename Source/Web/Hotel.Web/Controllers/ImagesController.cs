namespace Hotel.Web.Controllers
{
    using CameraBazaar.Data.Common.Repository;
    using Data.Hotel.Data.Repositories;
    using Data.Models;
    using global::Hotel.Hotel.Data;
    using Services;
    using System.Collections.Generic;
    using System.Web.Mvc;

    [RoutePrefix("images")]
    public class ImagesController : Controller
    {
        private IRepository<Picture> pictures;
        private ImagesService service;

        public ImagesController(IRepository<Picture> pictures)
        {
            this.pictures = pictures;
            this.service = new ImagesService();
        }

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
            IEnumerable<Picture> roomPictures = pictures.All();
            return View(roomPictures);
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