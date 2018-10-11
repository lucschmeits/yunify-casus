using System;
using System.Collections.Generic;
using System.Text;

namespace Casus.Core.Models
{
    public class Employee
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public Employee(string name, string lastName, string email)
        {
            Id = Guid.NewGuid();
            Name = name;
            LastName = lastName;
            Email = email;
        }
    }
}
