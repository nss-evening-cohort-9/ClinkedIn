using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinkedIn.Command
{
    public class UpdateClinkerCommand
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int InmateNum { get; set; }
        public List<Guid> FriendsList { get; set; }
        public List<Guid> EnemiesList { get; set; }
        public List<Guid> Services { get; set; }
        public List<Guid> Interests { get; set; }
    }
}
