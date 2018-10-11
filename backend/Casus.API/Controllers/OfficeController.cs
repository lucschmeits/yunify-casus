using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Casus.Application.Dtos;
using Casus.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Casus.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfficeController : Controller
    {
        private readonly IOfficeAppService officeAppService;

        public OfficeController(IOfficeAppService officeAppService)
        {
            this.officeAppService = officeAppService;
        }

        // GET: api/Office
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(officeAppService.GetAllOffices());
        }

        // GET: api/Office/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(Guid id)
        {
            return Ok(officeAppService.GetOfficeById(id));
        }

        // POST: api/Office
        [HttpPost]
        public IActionResult Post(CreateOfficeDto value)
        {
            Console.WriteLine(value);
            officeAppService.CreateOffice(value);
            return Ok();
        }

        [HttpPost]
        [Route("/api/[controller]/employee")]
        public IActionResult AddEmployee(AddEmployeeDto value)
        {
            officeAppService.AddEmployee(value);
            return Ok();
        }

        
        [HttpPost]
        [Route("/api/[controller]/room")]
        public IActionResult Post(AddRoomDto value)
        {
            officeAppService.AddRoom(value);
            return Ok();
        }

        [HttpPost]
        [Route("/api/[controller]/room/resource")]
        public IActionResult Post(AddResourceToRoomDto value)
        {
            officeAppService.AddResourceToRoom(value);
            return Ok();
        }

        [HttpPost]
        [Route("/api/[controller]/room/reservation")]
        public IActionResult Post(AddReservationToRoomDto value)
        {
            officeAppService.AddReservationToRoom(value);
            return Ok();
        }

        [HttpPost]
        [Route("/api/[controller]/room/reservation/resource")]
        public IActionResult Post(AddResourceToReservationDto value)
        {
            officeAppService.AddResourceToReservation(value);
            return Ok();
        }

        [HttpDelete]
        [Route("/api/[controller]/room/resource/")]
        public IActionResult Delete(DeleteResourceFromRoomDto value)
        {
            officeAppService.DeleteResourceFromRoom(value);
            return Ok();
        }
    }
}
