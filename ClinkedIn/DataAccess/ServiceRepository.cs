using ClinkedIn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinkedIn.DataAccess
{
    public class ServiceRepository
    {
        static List<Service> _services = new List<Service>()
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
            },
            new Service
            {
                Id = Guid.NewGuid(),
                Name = "service 1",
                Description = "service 1 is dope",
                Cost = 10
            },
            new Service
            {
                Id = Guid.NewGuid(),
                Name = "service 2",
                Description = "service 2 is dope",
                Cost = 20
            },
            new Service
            {
                Id = Guid.NewGuid(),
                Name = "service 3",
                Description = "service 3 is dope",
                Cost = 30
            },
            new Service
            {
                Id = Guid.NewGuid(),
                Name = "service 4",
                Description = "service 4 is dope",
                Cost = 40
            },
            new Service
            {
                Id = Guid.NewGuid(),
                Name = "service 5",
                Description = "service 5 is dope",
                Cost = 50
            },
            new Service
            {
                Id = Guid.NewGuid(),
                Name = "service 6",
                Description = "service 6 is dope",
                Cost = 60
            }
        };

        public Service GetById(Guid serviceId)
        {
            return _services.First(service => service.Id == serviceId);
        }

        public List<Service> GetAllAvailableServices()
        {
            var clinkerServiceIds = new ClinkerRepository().GetClinkerServiceIds();
            var availableServices = new List<Service>();
            foreach (var serviceId in clinkerServiceIds)
            {
                availableServices.Add(_services.First(service => service.Id == serviceId));
            }
            return availableServices;
        }

        public Service GetRandom()
        {
            Random random = new Random();
            int randomIndex = random.Next(0, _services.Count);
            Service randomService = _services[randomIndex];
            return randomService;
        }

        public List<Guid> GetTwoRandomServiceIdList()
        {
            return new List<Guid> { GetRandom().Id, GetRandom().Id };
        }

        public List<Service> GetAll()
        {
            return _services;
        }
    }
}
