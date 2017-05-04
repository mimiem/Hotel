namespace Hotel.Web.Controllers
{
    using Data.Common.Repository;
    using Data.Models;
    using Infrastructure.Mapping;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using ViewModels.Images;

    public class HomeController : BaseController
    {
        private IRepository<CategoryPictures> categories;

        public HomeController(IRepository<CategoryPictures> categories)
        {
            this.categories = categories;
        }

        public ActionResult Index()
        {
            IEnumerable<CategoryPictureViewModel> categoriesVM = this.categories
                                                                    .All()
                                                                    .To<CategoryPictureViewModel>()
                                                                    .Take(3)
                                                                    .ToList();

            return View(categoriesVM);
        }

    }
}