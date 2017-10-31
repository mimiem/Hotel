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
    [Authorize(Roles = "User,Admin")]
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

        [HttpGet]
        [Route("check")]
        public ActionResult Check()
        {
            CheckReservationViewModel modelVM = new CheckReservationViewModel();
            modelVM.RoomTypes = this.GetSelectListItems();

            return View(modelVM);
        }

        [HttpPost]
        [Route("check")]
        [ValidateAntiForgeryToken]
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

                    return this.RedirectToAction("All");

                }
            }

            return this.RedirectToAction("Check");
        }

        [HttpGet]
        public ActionResult NotAvailable(CheckReservationViewModel model)
        {

            return View(model);
        }

        [HttpGet]
        [Route("all")]
        public ActionResult All()
        {
            var userId = User.Identity.GetUserId();
            var allReservations = this.service.GetAllUserReservations(this.reservations, userId);
            return View(allReservations);
        }

        [HttpGet]
        [Route("edit/{id:int}")]
        public ActionResult Edit(int id)
        {
            Reservation reservation = this.reservations.GetById(id);
            CheckReservationViewModel model = Mapper.Map<CheckReservationViewModel>(reservation);
            model.RoomTypes = this.GetSelectListItems();

            return View(model);
        }

        [HttpPost]
        [Route("edit/{id:int}")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CheckReservationViewModel model)
        {
            if (ModelState.IsValid)
            {
                Reservation current = this.reservations.GetById(model.Id);
                this.reservations.Detach(current);
                Reservation edited = Mapper.Map<Reservation>(model);
                this.reservations.Update(edited);
                this.reservations.SaveChanges();

                return View("All");
            }

            return View(model);
        }

        [HttpGet]
        [Route("delete/{id:int}")]
        public ActionResult Delete(int id)
        {
            Reservation reservation = this.reservations.GetById(id);
            this.reservations.Delete(reservation);
            this.reservations.SaveChanges();
            return this.RedirectToAction("All");
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