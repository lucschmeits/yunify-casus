using Casus.Application.Dtos;
using Casus.Application.Interfaces;
using Casus.Core.Interfaces;
using Casus.Core.Models;
using Casus.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Casus.Application.Services
{
    public class OfficeAppService : IOfficeAppService
    {

        private readonly IOfficeRepository officeRepository;
        private readonly ReservationManager reservationManager;

        public OfficeAppService(IOfficeRepository officeRepository, ReservationManager reservationManager)
        {
            this.officeRepository = officeRepository;
            this.reservationManager = reservationManager;
        }

        public void AddEmployee(AddEmployeeDto addEmployeeDto)
        {
            var employee = new Employee(addEmployeeDto.Name, addEmployeeDto.LastName, addEmployeeDto.Email);
            officeRepository.AddEmployee(addEmployeeDto.OfficeId, employee);
        }

        public void AddReservationToRoom(AddReservationToRoomDto addReservationToRoomDto)
        {
            var office = officeRepository.GetOfficeById(addReservationToRoomDto.OfficeId);
            var room = office.GetRoomByNumber(addReservationToRoomDto.RoomNumber);
            var reservation = new Reservation(addReservationToRoomDto.StartTime, addReservationToRoomDto.EndTime);
            if (reservationManager.CheckReservations(room, reservation))
            {
                room.AddReservation(reservation);
                officeRepository.AddReservationToRoom(addReservationToRoomDto.OfficeId, office.Rooms);
            }
        }

        public void AddResourceToReservation(AddResourceToReservationDto addResourceToReservationDto)
        {
            var office = officeRepository.GetOfficeById(addResourceToReservationDto.OfficeId);
            var room = office.GetRoomByNumber(addResourceToReservationDto.RoomNumber);
            var resource = room.GetResourceByNumber(addResourceToReservationDto.ResourceNumber);
            var reservation = room.GetReservationByNumber(addResourceToReservationDto.ReservationNumber);
            reservation.AddResource(resource);
            officeRepository.AddResourceToReservation(addResourceToReservationDto.OfficeId, office.Rooms);
        }

        public void AddResourceToRoom(AddResourceToRoomDto addResourceToRoomDto)
        {
            var office = officeRepository.GetOfficeById(addResourceToRoomDto.OfficeId);
            var room = office.GetRoomByNumber(addResourceToRoomDto.RoomNumber);
            var resource = new Resource(addResourceToRoomDto.Name, addResourceToRoomDto.CanMove, addResourceToRoomDto.ResourceType);
            room.AddResource(resource);
            officeRepository.AddResourceToRoom(addResourceToRoomDto.OfficeId, office.Rooms);
        }

        public void AddRoom(AddRoomDto addRoomDto)
        {
            var office = officeRepository.GetOfficeById(addRoomDto.OfficeId);
            var room = new Room(addRoomDto.MaxCapacity, addRoomDto.Chairs);
            office.AddRoom(room);
            officeRepository.AddRoom(office.Id, room);
        }

        public ReturnOfficeDetailDto CreateOffice(CreateOfficeDto createOfficeDto)
        {
            var office = officeRepository.CreateOffice(new Office(createOfficeDto.Name, createOfficeDto.Location, createOfficeDto.OpenHour, createOfficeDto.CloseHour));
            var returnOffice = new ReturnOfficeDetailDto(office.Id, office.Name, office.Location, office.OpenHour, office.CloseHour, office.Rooms, office.Employees);
            return returnOffice;
        }

        public void DeleteResourceFromRoom(DeleteResourceFromRoomDto deleteResourceFromRoomDto)
        {
            var office = officeRepository.GetOfficeById(deleteResourceFromRoomDto.OfficeId);
            var room = office.GetRoomByNumber(deleteResourceFromRoomDto.RoomNumber);
            var resource = room.GetResourceByNumber(deleteResourceFromRoomDto.ResourceNumber);
            room.RemoveResource(resource);
            officeRepository.RemoveResourceFromRoom(deleteResourceFromRoomDto.OfficeId, office.Rooms);
        }

        public List<ReturnOfficeDetailDto> GetAllOffices()
        {
            var returnOffices = new List<ReturnOfficeDetailDto>();
            var offices = officeRepository.GetAllOffices();
            foreach (var office in offices)
            {
                returnOffices.Add(new ReturnOfficeDetailDto(office.Id, office.Name, office.Location, office.OpenHour, office.CloseHour, office.Rooms, office.Employees));
            }

            return returnOffices;
        }

        public ReturnOfficeDetailDto GetOfficeById(Guid id)
        {
            var office = officeRepository.GetOfficeById(id);
            return new ReturnOfficeDetailDto(office.Id, office.Name, office.Location, office.OpenHour, office.CloseHour, office.Rooms, office.Employees);
        }
    }
}
