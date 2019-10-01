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
                Name = "service 1"
            },
            new Service
            {
                Name = "service 2"
            },
            new Service
            {
                Name = "service 3"
            },
            new Service
            {
                Name = "service 4"
            },
            new Service
            {
                Name = "service 5"
            },
            new Service
            {
                Name = "service 6"
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
    }
}
