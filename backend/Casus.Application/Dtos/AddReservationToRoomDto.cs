using System;
using System.Collections.Generic;
using System.Text;

namespace Casus.Application.Dtos
{
    public class AddReservationToRoomDto
    {
        public Guid OfficeId { get; set; }
        public int RoomNumber { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public AddReservationToRoomDto(Guid officeId, int roomNumber, DateTime startTime, DateTime endTime)
        {
            OfficeId = officeId;
            RoomNumber = roomNumber;
            StartTime = startTime;
            EndTime = endTime;
        }
    }
}
