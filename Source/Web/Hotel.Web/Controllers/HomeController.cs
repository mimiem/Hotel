namespace Hotel.Web.Controllers
{
    using CameraBazaar.Data.Common.Repository;
    using Data.Models;
    using Infrastructure.Mapping;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using ViewModels.Images;

    public class HomeController : BaseController
    {
        private IRepository<Category> categories;

        public HomeController(IRepository<Category> categories)
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