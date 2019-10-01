using ClinkedIn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinkedIn.DataAccess
{
    public class ServiceRepository
    {
        static List<Service> _service = new List<Service>
        {
            new Service
            {
                Id = Guid.NewGuid(),
                Name = "Religion",
                Description = "A service for inmates to practice their religion.",
                Cost = 30
            },
            new Service
            {
                Id = Guid.NewGuid(),
                Name = "Drug and Alcohol Prevention",
                Description = "A service to help prevent inmates from drug and alcohol abuse.",
                Cost = 10
            },
            new Service
            {
                Id = Guid.NewGuid(),
                Name = "Education",
                Description = "A service to help educate inmates.",
                Cost = 20
            }
        };

        public Service GetById(Guid id)
        {
            var service = _service.First(s => s.Id == id);
            return service;
        }
    }
}
