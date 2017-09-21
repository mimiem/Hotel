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
    using Hotel.Web.ViewModels.Reservation;

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

        [Authorize(Roles = "User,Admin")]
        [HttpGet]
        public ActionResult Check()
        {
            CheckReservationViewModel modelVM = new CheckReservationViewModel();
            modelVM.RoomTypes = this.GetSelectListItems();

            return View(modelVM);
        }

        [Authorize(Roles = "User,Admin")]
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

        [Authorize(Roles = "User,Admin")]
        [HttpGet]
        public ActionResult NotAvailable(CheckReservationViewModel model)
        {

            return View(model);
        }

        [Authorize(Roles = "User,Admin")]
        [HttpGet]
        public ActionResult Reserved(CheckReservationViewModel model) 
        {
            UserReservationViewModel modelRes = Mapper.Map<UserReservationViewModel>(model);
            RoomType type = this.roomTypes.All().FirstOrDefault(t => t.Type == model.RoomType);
            modelRes.PricePerNight = type.Price;
            return View(modelRes);
        }

        [Authorize(Roles = "User,Admin")]
        [HttpGet]
        public ActionResult All()
        {
            //TODO
            var userId = User.Identity.GetUserId();
            var allReservations = this.service.GetAllUserReservations(this.reservations, userId);
            return View(allReservations);
        }

        [Authorize(Roles = "User,Admin")]
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Reservation reservation = this.reservations.GetById(id);
            CheckReservationViewModel model = Mapper.Map<CheckReservationViewModel>(reservation);
            return View(model);
        }

        [Authorize(Roles = "User,Admin")]
        [HttpGet]
        public ActionResult Edit(CheckReservationViewModel model)
        {

            //TODO
            return View();
        }

        [Authorize(Roles = "User,Admin")]
        [HttpGet]
        public ActionResult Delete(int id)
        {
            Reservation reservation = this.reservations.GetById(id);
            this.reservations.Delete(reservation);
            this.reservations.SaveChanges();
            return this.RedirectToAction("Index", "Home");
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