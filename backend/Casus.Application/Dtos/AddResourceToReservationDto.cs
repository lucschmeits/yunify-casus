using Casus.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Casus.Application.Dtos
{
    public class AddResourceToReservationDto
    {
        public Guid OfficeId { get; set; }
        public int ResourceNumber { get; set; }
        public int RoomNumber { get; set; }
        public int ReservationNumber { get; set; }

        public AddResourceToReservationDto(Guid officeId, int resourceNumber, int roomNumber, int reservationNumber)
        {
            OfficeId = officeId;
            ResourceNumber = resourceNumber;
            RoomNumber = roomNumber;
            ReservationNumber = reservationNumber;
        }
    }
}
