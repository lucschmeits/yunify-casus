using System;
using System.Collections.Generic;
using System.Text;

namespace Casus.Application.Dtos
{
    public class DeleteResourceFromRoomDto
    {
        public Guid OfficeId { get; set; }
        public int RoomNumber { get; set; }
        public int ResourceNumber { get; set; }

        public DeleteResourceFromRoomDto(Guid officeId, int roomNumber, int resourceNumber)
        {
            OfficeId = officeId;
            RoomNumber = roomNumber;
            ResourceNumber = resourceNumber;
        }
    }
}
