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
    }
}
