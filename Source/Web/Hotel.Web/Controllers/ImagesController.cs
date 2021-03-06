﻿namespace Hotel.Web.Controllers
{
    using Data.Common.Repository;
    using Data.Models;
    using Hotel.Web.ViewModels.Images;
    using System.Web.Mvc;
    using System.Collections.Generic;
    using global::Hotel.Services;

    [RoutePrefix("images")]
    public class ImagesController : BaseController
    {
        private IRepository<Picture> pictures;
        private IRepository<CategoryPictures> categories;

        private ImagesService service;

        public ImagesController(IRepository<Picture> pictures, IRepository<CategoryPictures> categories)
        {
            this.pictures = pictures;
            this.categories = categories;
            this.service = new ImagesService();
        }

        [HttpGet]
        [Route("{category}")]
        public ActionResult GalleryImages(string category)
        {
            if (string.IsNullOrEmpty(category))
            {
                return this.RedirectToAction("Index", "Home");
            }

            IEnumerable<PictureViewModel> hotelPicturesVM = this.service.GetPictures(this.pictures, category);

            return View(hotelPicturesVM);
        }

        [HttpGet]
        public ActionResult GetImage(int id)
        {
            Picture picture = this.pictures.GetById(id);

            return new FileContentResult(picture.Image, "img/ file type");
        }

    }
}