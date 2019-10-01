using ClinkedIn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinkedIn.DataAccess
{
    public class ServiceRepository
    {
        static List<Service> _services = new List<Service>();
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
    }
}
