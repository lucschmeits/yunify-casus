using Casus.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Casus.Application.Dtos
{
    public class AddResourceToRoomDto
    {
        public Guid OfficeId { get; set; }
        public string Name { get; set; }
        public int RoomNumber { get; set; }
        public bool CanMove { get; set; }
        public ResourceType ResourceType { get; set; }

        public AddResourceToRoomDto(Guid officeId, string name, int roomNumber, bool canMove, ResourceType resourceType)
        {
            OfficeId = officeId;
            Name = name;
            RoomNumber = roomNumber;
            CanMove = canMove;
            ResourceType = resourceType;
        }
    }
}
