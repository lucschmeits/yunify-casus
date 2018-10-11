using Casus.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Casus.Core.Models
{
    public class Resource
    {
        public int ResourceNumber { get; set; }
        public string Name { get; set; }
        public bool CanMove { get; set; }
        public ResourceType ResourceType { get; set; }

        public Resource(string name, bool canMove, ResourceType resourceType)
        {
            Name = name;
            CanMove = canMove;
            ResourceType = resourceType;
        }
    }
}
