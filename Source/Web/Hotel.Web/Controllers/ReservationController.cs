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
    using Data.Hotel.Data.Models;
    using Infrastructure.Identity;
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
        public ActionResult Add()
        {
            CheckReservationViewModel modelVM = new CheckReservationViewModel();
            modelVM.RoomTypes = this.GetSelectListItems();

            return View(modelVM);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Add(CheckReservationViewModel modelVM)
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
                    //this.reservations.SaveChanges();

                    return this.RedirectToAction("Confirm", modelVM);

                }
            }

            return this.View("Add", modelVM);
        }

        [HttpGet]
        public ActionResult NotAvailable(CheckReservationViewModel model)
        {
            return View(model);
        }

        [HttpGet]
        public ActionResult Confirm()
        {

            return View();
        }

        

        [HttpGet]
        //[Route("confirm/reserved")]
        public ActionResult Reserved(bool isConfirmed) //TODO The resource cannot be found.
        {

            //var modelVM = Session["CheckReservationViewModel"] as CheckReservationViewModel;

            this.reservations.SaveChanges();

            //return this.RedirectToAction("Add", modelVM);
            return View();
        }

        private IEnumerable<SelectListItem> GetSelectListItems()
        {
            IEnumerable<string> allRoomTypes = this.roomTypes.All().Select(rt => rt.Type);

            var selectList = new List<SelectListItem>();

            // For each string in the 'elements' variable, create a new SelectListItem object
            // that has both its Value and Text properties set to a particular value.
            // This will result in MVC rendering each item as:
            //     <option value="State Name">State Name</option>
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