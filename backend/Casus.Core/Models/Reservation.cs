using System;
using System.Collections.Generic;
using System.Text;

namespace Casus.Core.Models
{
    public class Reservation
    {
        public int ReservationNumber { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public List<Resource> Resources { get; set; }

        public Reservation(DateTime startTime, DateTime endTime)
        {
            StartTime = startTime;
            EndTime = endTime;
            Resources = new List<Resource>();
        }

        public void AddResource(Resource resource)
        {
            Resources.Add(resource);
        }

        
    }
}
