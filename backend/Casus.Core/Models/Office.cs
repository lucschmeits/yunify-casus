using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Casus.Core.Models
{
    public class Office
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public DateTime OpenHour { get; set; }
        public DateTime CloseHour { get; set; }
        public List<Room> Rooms { get; set; }
        public List<Employee> Employees { get; set; }

        public Office(string name, string location, DateTime openHour, DateTime closeHour)
        {
            Id = Guid.NewGuid();
            Name = name;
            Location = location;
            OpenHour = openHour;
            CloseHour = closeHour;
            Rooms = new List<Room>();
            Employees = new List<Employee>();
        }

        public void AddRoom(Room room)
        {
            if (Rooms.Count > 0)
            {
                var query = (from x in Rooms
                             select x.RoomNumber).Max() + 1;
                room.RoomNumber = query;
            }
            else
            {
                room.RoomNumber = 0;
            }

            Rooms.Add(room);
        }

        public void AddEmployee(Employee employee)
        {
            Employees.Add(employee);
        }

        public Room GetRoomByNumber(int roomNumber)
        {
            var roomQuery =
                 from room in Rooms
                 where room.RoomNumber == roomNumber
                 select room;
            return roomQuery.First();
        }
    }
}
