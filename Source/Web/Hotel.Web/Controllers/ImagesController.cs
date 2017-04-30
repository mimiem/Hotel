﻿namespace Hotel.Web.Controllers
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
    using System.Collections.Generic;
    using ViewModels.Images;
    [RoutePrefix("images")]
    public class ImagesController : BaseController
    {
        private IRepository<Picture> pictures;
        private IRepository<Category> categories;

        private ImagesService service;

        public ImagesController(IRepository<Picture> pictures, IRepository<Category> categories)
        {
            this.pictures = pictures;
            this.categories = categories;
            this.service = new ImagesService();
        }

        [HttpGet]
        [Route]
        public ActionResult CategoriesImages()
        {
            IEnumerable<CategoryPictureViewModel> categoriesVM = this.categories
                                                                    .All()
                                                                    .To<CategoryPictureViewModel>()
                                                                    .ToList();

            return View(categoriesVM);
        }

        [HttpGet]
        [Route("{category}")]
        public ActionResult GalleryImages(string category)
        {
            IEnumerable<PictureViewModel> hotelPicturesVM = this.service.GetPictures(this.pictures, category);

            return View(hotelPicturesVM);
        }

    }
}