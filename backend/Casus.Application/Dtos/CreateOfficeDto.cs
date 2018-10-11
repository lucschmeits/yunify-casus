using System;
using System.Collections.Generic;
using System.Text;

namespace Casus.Application.Dtos
{
    public class CreateOfficeDto
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public DateTime OpenHour { get; set; }
        public DateTime CloseHour { get; set; }

        public CreateOfficeDto(string name, string location, DateTime openHour, DateTime closeHour)
        {
            Name = name;
            Location = location;
            OpenHour = openHour;
            CloseHour = closeHour;
        }
    }
}
