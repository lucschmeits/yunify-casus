using Casus.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Casus.Application.Interfaces
{
    public interface IOfficeAppService
    {
        List<ReturnOfficeDetailDto> GetAllOffices();
        ReturnOfficeDetailDto GetOfficeById(Guid id);
        ReturnOfficeDetailDto CreateOffice(CreateOfficeDto createOfficeDto);
        void AddEmployee(AddEmployeeDto addEmployeeDto);
        void AddRoom(AddRoomDto addRoomDto);
        void AddReservationToRoom(AddReservationToRoomDto addReservationToRoomDto);
        void AddResourceToRoom(AddResourceToRoomDto addResourceToRoomDto);
        void DeleteResourceFromRoom(DeleteResourceFromRoomDto deleteResourceFromRoomDto);
        void AddResourceToReservation(AddResourceToReservationDto addResourceToReservationDto);
    }
}
