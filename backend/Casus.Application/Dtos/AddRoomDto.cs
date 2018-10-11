using System;
using System.Collections.Generic;
using System.Text;

namespace Casus.Application.Dtos
{
    public class AddRoomDto
    {
        public Guid OfficeId { get; set; }
        public int MaxCapacity { get; set; }
        public int Chairs { get; set; }

        public AddRoomDto(Guid officeId, int maxCapacity, int chairs)
        {
            OfficeId = officeId;
            MaxCapacity = maxCapacity;
            Chairs = chairs;
        }
    }
}
