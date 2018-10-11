using Casus.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Casus.Application.Dtos
{
    public class ReturnOfficeDetailDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public DateTime OpenHour { get; set; }
        public DateTime CloseHour { get; set; }
        public List<Room> Rooms { get; set; }
        public List<Employee> Employees { get; set; }

        public ReturnOfficeDetailDto(Guid id, string name, string location, DateTime openHour, DateTime closeHour, List<Room> rooms, List<Employee> employees)
        {
            Id = id;
            Name = name;
            Location = location;
            OpenHour = openHour;
            CloseHour = closeHour;
            Rooms = rooms;
            Employees = employees;
        }
    }
}
