using System;
using System.Collections.Generic;
using System.Text;

namespace Casus.Application.Dtos
{
    public class AddEmployeeDto
    {
        public Guid OfficeId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public AddEmployeeDto(Guid officeId, string name, string lastName, string email)
        {
            OfficeId = officeId;
            Name = name;
            LastName = lastName;
            Email = email;
        }
    }
}
