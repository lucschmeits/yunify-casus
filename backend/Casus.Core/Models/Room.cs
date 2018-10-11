using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Casus.Core.Models
{
    public class Room
    {
        public int RoomNumber { get; set; }
        public int MaxCapacity { get; set; }
        public int Capacity { get; set; }
        public int Chairs { get; set; }
        public List<Resource> Resources { get; set; }
        public List<Reservation> Reservations { get; set; }

        public Room(int maxCapacity, int chairs)
        {
            MaxCapacity = maxCapacity;
            Chairs = chairs;
            Resources = new List<Resource>();
            Reservations = new List<Reservation>();
        }

        public void AddResource(Resource resource)
        {
            if (Resources.Count > 0)
            {
                var query = (from resourceInQuery in Resources
                             select resourceInQuery.ResourceNumber).Max() + 1;
                resource.ResourceNumber = query;
            }
            else
            {
                resource.ResourceNumber = 0;
            }

            Resources.Add(resource);
        }

        public void RemoveResource(Resource resource)
        {
            Resources.Remove(resource);
        }

        public void AddReservation(Reservation reservation)
        {
            if (Resources.Count > 0)
            {
                var query = (from reservationInQuery in Resources
                             select reservationInQuery.ResourceNumber).Max() + 1;
                reservation.ReservationNumber = query;
            }
            else
            {
                reservation.ReservationNumber = 0;
            }
            Reservations.Add(reservation);
        }

        public Resource GetResourceByNumber(int resourceNumber)
        {
            var resourceQuery =
                 from resource in Resources
                 where resource.ResourceNumber == resourceNumber
                 select resource;
            return resourceQuery.First();
        }

        public Reservation GetReservationByNumber(int reservationNumber)
        {
            var reservationQuery =
                 from reservation in Reservations
                 where reservation.ReservationNumber == reservationNumber
                 select reservation;
            return reservationQuery.First();
        }


    }
}
