using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinkedIn.Models
{
    public class Service
    {
        public Guid Id { get; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Cost { get; set; }

        static string _guidPart = "96bf";

        public Service(string name, string description, int cost)
        {
            Id = new Guid(AssignGuid());
            Name = name;
            Description = description;
            Cost = cost;
        }

        public string AssignGuid()
        {
            int guidPart = int.Parse(_guidPart, System.Globalization.NumberStyles.HexNumber) + 1;
            _guidPart = guidPart.ToString("X");
            return $"634a171f-731a-4ebd-{_guidPart}-8b7553d5dcdc";
        }
    }
}
