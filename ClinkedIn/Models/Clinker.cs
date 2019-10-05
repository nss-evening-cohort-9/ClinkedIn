using ClinkedIn.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinkedIn.Models
{
    public class Clinker
    {
        public Guid Id { get; }
        public string Name { get; set; }
        public int InmateNum { get; set; }
        public List<Guid> FriendsList { get; set; }
        public List<Guid> EnemiesList { get; set; }
        public List<Guid> Services { get; set; } = new ServiceRepository().GetRandomServices();
        public List<Guid> Interests { get; set; } = new InterestRepository().GetRandomInterests();

        static string _guidPart = "b63f";

        public Clinker(string name, int inmateNum)
        {
            Id = new Guid(AssignGuid());
            Name = name;
            InmateNum = inmateNum;
        }

        public string AssignGuid()
        {
            int guidPart = int.Parse(_guidPart, System.Globalization.NumberStyles.HexNumber) + 1;
            _guidPart = guidPart.ToString("X");
            return $"80000017-0000-fb00-{_guidPart}-84710c7967bb";
        }

    }
}
