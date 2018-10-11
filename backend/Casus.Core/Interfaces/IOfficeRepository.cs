using Casus.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Casus.Core.Interfaces
{
    public interface IOfficeRepository
    {
        Office CreateOffice(Office office);
        Office GetOfficeById(Guid id);
        List<Office> GetAllOffices();
        void AddEmployee(Guid officeId, Employee employee);
        void AddRoom(Guid officeId, Room room);
        void AddReservationToRoom(Guid officeId, List<Room> rooms);
        void AddResourceToRoom(Guid officeId, List<Room> rooms);
        void RemoveResourceFromRoom(Guid officeId, List<Room> rooms);
        void AddResourceToReservation(Guid officeId, List<Room> rooms);
    }
}
