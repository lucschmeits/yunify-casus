using Casus.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Casus.Core.Services
{
    public class ReservationManager
    {
        public ReservationManager()
        {

        }
        public bool CheckReservations(Room room, Reservation reservation)
        {
            if(room.Reservations.Count > 0)
            {
                foreach (var reservationInRoom in room.Reservations)
                {
                    if (reservationInRoom.StartTime == reservation.StartTime.AddHours(-2) || reservationInRoom.EndTime == reservation.EndTime.AddHours(-2))
                    {
                        return false;
                    }
                    else if (reservationInRoom.StartTime < reservation.StartTime && reservationInRoom.EndTime > reservation.StartTime)
                    {
                        return false;
                    }
                }
                return true;
            }
            return true;
           
        }
    }
}
