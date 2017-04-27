namespace Hotel.Web.Controllers
{
    using CameraBazaar.Data.Common.Repository;
    using Data.Models;
    using Hotel.Web.ViewModels.Images;
    using Services;
    using System.Web.Mvc;
    using Infrastructure.Mapping;
    using System.Linq;
    using Data.Models.Enumerations;
    using System;
    [RoutePrefix("images")]
    public class ImagesController : BaseController
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
        [Route("{category}")]
        public ActionResult GalleryImages(string category)
        {
            ImageCategory enumCategory = (ImageCategory)0;

            if (Enum.IsDefined(typeof(ImageCategory), category))
            {
                enumCategory = (ImageCategory)Enum.Parse(typeof(ImageCategory), category);
            }
            var roomPictures = this.pictures
                                    .All()
                                    .Where(p => p.Category == enumCategory)
                                    .To<PictureViewModel>()
                                    .ToList();

            return View(roomPictures);
        }

    }
}