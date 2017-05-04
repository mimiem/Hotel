namespace Hotel.Web.Controllers
{
    using Data.Common.Repository;
    using Data.Models;
    using System.Linq;
    using System.Web.Mvc;
    using Infrastructure.Mapping;
    using AutoMapper.QueryableExtensions;
    using ViewModels.Entertainment;
    public class EntertainmentController : BaseController
    {
        private IRepository<Entertainment> entertainments;
        public EntertainmentController(IRepository<Entertainment> entertainments)
        {
            this.entertainments = entertainments;
        }

        // GET: Entertainment
        public ActionResult Details(string entertainmentId)
        {
            Entertainment current = this.entertainments.GetById(int.Parse(entertainmentId));
            EntertainmentViewModel currentVM = this.Mapper.Map<EntertainmentViewModel>(current);
            return View(currentVM);
        }
        
    }
}