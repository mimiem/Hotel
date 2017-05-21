namespace Hotel.Web.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Data.Models;
    using ViewModels.Reservation;
    using Infrastructure.Mapping;
    using Data.Common.Repository;
    using Data;
    using global::Hotel.Hotel.Data;

    public class ReservationService
    {
        private readonly IApplicationDbContext db;

        public ReservationService(IApplicationDbContext db)
        {
            this.db = db;
        }

        public ReservationService()
            : this(new ApplicationDbContext())
        {
        }

        public IEnumerable<RoomViewModel> CheckIfIsAvailable(CheckReservationViewModel modelVM, IRepository<Room> rooms)
        {
            IEnumerable<RoomViewModel> allRooms = rooms
                .All()
                .To<RoomViewModel>()
                .ToList();

            IEnumerable<RoomViewModel> roomsOfThisType = allRooms
                .Where(r => r.RoomType == modelVM.RoomType);

            
            List<RoomViewModel> roomsAvailable = new List<RoomViewModel>();
            int roomsCount = roomsOfThisType.Count();
            bool[] reservationChecks;

            bool isFree = false;

            for (int i = 0; i < roomsCount; i++)
            {
                Room current = rooms.GetById(roomsOfThisType.ElementAt(i).RoomId);
                int currentRoomReservations = current.Reservations.Count();

                if (currentRoomReservations == 0)
                {
                    roomsAvailable.Add(roomsOfThisType.ElementAt(i));
                }
                else
                {
                    reservationChecks = new bool[currentRoomReservations];

                    for (int j = 0; j < currentRoomReservations; j++)
                    {
                        DateTime startDateReservation = (DateTime)current.Reservations.ElementAt(j).StartDate;
                        DateTime endDateReservation = (DateTime)current.Reservations.ElementAt(j).EndDate;

                        if ((startDateReservation < modelVM.StartDate && endDateReservation <modelVM.StartDate)||
                            (startDateReservation > modelVM.EndDate && endDateReservation > modelVM.EndDate) )
                        {
                            isFree = true;
                        }

                        if (isFree == true)
                        {
                            reservationChecks[j] = true;
                            isFree = false;
                        }
                        else
                        {
                            reservationChecks[j] = false;
                        }

                    }

                    if (!reservationChecks.Contains(false))
                    {
                        roomsAvailable.Add(roomsOfThisType.ElementAt(i));
                    }


                }

            }

            return roomsAvailable;
        }

    }
}
