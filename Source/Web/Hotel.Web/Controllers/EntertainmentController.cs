namespace Hotel.Web.Controllers
{
    using Data.Common.Repository;
    using Data.Models;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using ViewModels.Entertainment;
    [RoutePrefix("entertainment")]
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

        [HttpGet]
        [Authorize(Roles = "Admin")]
        [Route("Index")]
        public ActionResult Index()
        {
            var all = entertainments.All().Where(e=>e.IsDeleted == false);
            return View(all);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        [Route("Create")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        [Route("Create")]
        public ActionResult Create(EntertainmentViewModel model)
        {
            if (ModelState.IsValid)
            {
                Entertainment ent = Mapper.Map<Entertainment>(model);
                this.entertainments.Add(ent);
                this.entertainments.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(model);
            
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        [Route("edit/{id:int}")]
        public ActionResult Edit(int id)
        {
            Entertainment model = this.entertainments.GetById(id);

            if (model != null)
            {
                EntertainmentViewModel modelVM = Mapper.Map<EntertainmentViewModel>(model);
                return View(modelVM);
            }

            return this.RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        [Route("edit/{id:int}")]
        public ActionResult Edit(EntertainmentViewModel model)
        {
            if (ModelState.IsValid)
            {
                Entertainment current = this.entertainments.GetById(model.Id);
                this.entertainments.Detach(current);
                Entertainment edited = Mapper.Map<Entertainment>(model);
                this.entertainments.Update(edited);
                this.entertainments.SaveChanges();

                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        [Route("delete/{id:int}")]
        public ActionResult Delete(int id)
        {
            Entertainment ent = this.entertainments.GetById(id);
            this.entertainments.Delete(ent);
            this.entertainments.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Details(string entertainmentId)
        {
            Entertainment current = this.entertainments.GetById(int.Parse(entertainmentId));

            if (current != null)
            {
                EntertainmentViewModel currentVM = this.Mapper.Map<EntertainmentViewModel>(current);
                IEnumerable<string> facilities = current.Facilities.Split('|');
                ViewBag.Facilities = facilities;
                return View(currentVM);
            }

            return this.RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult GetImage(int id)
        {
            Picture picture = this.pictures.GetById(id);

            return new FileContentResult(picture.Image, "img/ file type");
        }

    }
}