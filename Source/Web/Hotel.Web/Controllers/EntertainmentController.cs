﻿namespace Hotel.Web.Controllers
{
    using Data.Common.Repository;
    using Data.Models;
    using System.Web.Mvc;
    using ViewModels.Entertainment;
    public class EntertainmentController : BaseController
    {
        private IRepository<Entertainment> entertainments;
        private IRepository<Picture> pictures;

        public EntertainmentController(IRepository<Entertainment> entertainments,
            IRepository<Picture> pictures)
        {
            this.entertainments = entertainments;
            this.pictures = pictures;
        }

        // GET: Entertainment
        public ActionResult Details(string entertainmentId)
        {
            if (string.IsNullOrEmpty(entertainmentId))
            {
                return this.RedirectToAction("Index", "Home"); 
            }
            Entertainment current = this.entertainments.GetById(int.Parse(entertainmentId));
            EntertainmentViewModel currentVM = this.Mapper.Map<EntertainmentViewModel>(current);
            return View(currentVM);
        }

        [HttpGet]
        public ActionResult GetImage(int id)
        {
            Picture picture = this.pictures.GetById(id);

            return new FileContentResult(picture.Image, "img/ file type");
        }

    }
}