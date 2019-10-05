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
            new Service("Religion", "A service for inmates to practice their religion.", 30),
            new Service("Drug and Alcohol Prevention", "A service to help prevent inmates from drug and alcohol abuse.", 20),
            new Service("Education", "A service to help educate inmates.", 20)
        };

        public Service GetById(Guid serviceId)
        {
            return _services.First(service => service.Id == serviceId);
        }

        public List<Service> GetAllAvailableServices()
        {
            var clinkerRepo = new ClinkerRepository();
            var clinkerServiceIds = clinkerRepo.GetClinkerServiceIds();
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

        public List<Guid> GetRandomServices()
        {
            return new List<Guid> { GetRandom().Id, GetRandom().Id };
        }
    }
}
