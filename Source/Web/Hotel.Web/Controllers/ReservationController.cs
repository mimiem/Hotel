namespace Hotel.Web.Controllers
{
    using Data.Common.Repository;
    using Data.Models;
    using Services;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using ViewModels.Reservation;
    using Microsoft.AspNet.Identity;

    [RoutePrefix("reservation")]
    public class ReservationController : BaseController
    {
        private ReservationService service;
        private readonly IRepository<RoomType> roomTypes;
        private readonly IRepository<Reservation> reservations;
        private readonly IRepository<Room> rooms;


        public ReservationController(IRepository<RoomType> roomTypes,
            IRepository<Reservation> reservations,
            IRepository<Room> rooms)
        {
            this.roomTypes = roomTypes;
            this.rooms = rooms;
            this.reservations = reservations;
            this.service = new ReservationService();
        }

        [Authorize]
        [HttpGet]
        public ActionResult Check()
        {
            CheckReservationViewModel modelVM = new CheckReservationViewModel();
            modelVM.RoomTypes = this.GetSelectListItems();

            return View(modelVM);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Check(CheckReservationViewModel modelVM)
        {
            modelVM.RoomTypes = this.GetSelectListItems();

            if (ModelState.IsValid)
            {
                Session["CheckReservationViewModel"] = modelVM;
                IEnumerable<RoomViewModel> roomsAvailable = this.service.CheckIfIsAvailable(modelVM, this.rooms);

                if (roomsAvailable.Count() <= 0)
                {
                    return this.RedirectToAction("NotAvailable", modelVM);
                }
                else
                {
                    Reservation currentReservation = Mapper.Map<Reservation>(modelVM);

                    currentReservation.RoomId = roomsAvailable.ElementAt(0).RoomId;
                    currentReservation.UserId = this.User.Identity.GetUserId();

                    this.reservations.Add(currentReservation);
                    this.reservations.SaveChanges();

                    return this.RedirectToAction("Reserved", modelVM);

                }
            }

            return this.RedirectToAction("Check");
        }

        [Authorize]
        [HttpGet]
        public ActionResult NotAvailable(CheckReservationViewModel model)
        {

            return View(model);
        }

        [Authorize]
        [HttpGet]
        public ActionResult Reserved(CheckReservationViewModel model) 
        {
            UserReservationViewModel modelRes = Mapper.Map<UserReservationViewModel>(model);

            return View(modelRes);
        }

        private IEnumerable<SelectListItem> GetSelectListItems()
        {
            IEnumerable<string> allRoomTypes = this.roomTypes.All().Select(rt => rt.Type);

            var selectList = new List<SelectListItem>();

            foreach (var element in allRoomTypes)
            {
                selectList.Add(new SelectListItem
                {
                    Value = element,
                    Text = element
                });
            }

            return selectList;
        }
    }
}