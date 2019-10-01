using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinkedIn.Models;

namespace ClinkedIn.DataAccess
{
    public class ClinkerRepository
    {
        private static List<Clinker> _clinkers = new List<Clinker>
        {
            new Clinker()
            {
                Id = Guid.NewGuid(),
                Name = "Scuba Steve",
                InmateNum = 137264,
                FriendsList = new List<Guid>(),
                EnemiesList =  new List<Guid>(),
                Services = new List<Guid>(),
                Interests = new List<Guid>(),
            },
            new Clinker()
            {
                Id = Guid.NewGuid(),
                Name = "Bubba",
                InmateNum = 937463,
                FriendsList = new List<Guid>(),
                EnemiesList =  new List<Guid>(),
                Services = new List<Guid>(),
                Interests = new List<Guid>(),
            },
            new Clinker()
            {
                Id = Guid.NewGuid(),
                Name = "Mad Cow",
                InmateNum = 947635,
                FriendsList = new List<Guid>(),
                EnemiesList =  new List<Guid>(),
                Services = new List<Guid>(),
                Interests = new List<Guid>(),
            },
            new Clinker()
            {
                Id = Guid.NewGuid(),
                Name = "Capone",
                InmateNum = 229574,
                FriendsList = new List<Guid>(),
                EnemiesList =  new List<Guid>(),
                Services = new List<Guid>(),
                Interests = new List<Guid>(),
            },
            new Clinker()
            {
                Id = Guid.NewGuid(),
                Name = "Stitch The Snitch",
                InmateNum = 756994,
                FriendsList = new List<Guid>(),
                EnemiesList =  new List<Guid>(),
                Services = new List<Guid>(),
                Interests = new List<Guid>(),
            },
            new Clinker()
            {
                Id = Guid.NewGuid(),
                Name = "Nasty Nate",
                InmateNum = 666666,
                FriendsList = new List<Guid>(),
                EnemiesList =  new List<Guid>(),
                Services = new List<Guid>(),
                Interests = new List<Guid>(),
            },
        };

        public List<Clinker> GetAll()
        {
            return _clinkers;
        }

        public Clinker GetById(Guid id)
        {
            var clinker = _clinkers.First(x => x.Id == id);
            return clinker;
        }

    }
}
