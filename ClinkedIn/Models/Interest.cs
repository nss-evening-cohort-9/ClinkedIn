using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinkedIn.Models
{
    public class Interest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        static string _guidPart = "af1b";

        public Interest(string name)
        {
            Id = new Guid(AssignGuid());
            Name = name;
        }

        public string AssignGuid()
        {
            int guidPart = int.Parse(_guidPart, System.Globalization.NumberStyles.HexNumber) + 1;
            _guidPart = guidPart.ToString("X");
            return $"34ea676c-94af-415a-{_guidPart}-fca894fa9c1e";
        }
    }
}
