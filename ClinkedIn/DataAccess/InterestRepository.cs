using ClinkedIn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinkedIn.DataAccess
{
    public class InterestRepository
    {
        static List<Interest> _interest = new List<Interest>
        {
            new Interest
            {
                Id = Guid.NewGuid(),
                Name = "Cigarette Making"
            },
            new Interest
            {
                Id = Guid.NewGuid(),
                Name = "Polishing"
            },
            new Interest
            {
                Id = Guid.NewGuid(),
                Name = "Cooking"
            },
            new Interest
            {
                Id = Guid.NewGuid(),
                Name = "Workouts"
            },
            new Interest
            {
                Id = Guid.NewGuid(),
                Name = "Basketball"
            }
        };

        public Interest GetById(Guid id)
        {
            var interest = _interest.First(i => i.Id == id);
            return interest;
        }

        public Interest GetByName(string name)
        {
            Interest namedInterest = _interest.First(i => i.Name == name);
            return namedInterest;
        }

        public List<Guid> GetRandomInterests()
        {
            List<Guid> randomInterests = new List<Guid>();

            var random = new Random();
            var randInt01 = random.Next(0, _interest.Count());
            var randInt02 = random.Next(0, _interest.Count());

            randomInterests.Add(_interest.ElementAt(randInt01).Id);
            randomInterests.Add(_interest.ElementAt(randInt02).Id);

            return randomInterests;
        }
    }
}
