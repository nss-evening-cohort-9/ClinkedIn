using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinkedIn.Models;

namespace ClinkedIn.DataAccess
{
    public class ClinkerRepository
    {
        static List<Clinker> _clinkers = new List<Clinker>
        {
            new Clinker("Scuba Steve", 137264),
            new Clinker("Bubba", 937463),
            new Clinker("Mad Cow", 947635),
            new Clinker("Capone", 229574),
            new Clinker("Stitch The Snitch", 756994),
            new Clinker("Nasty Nate", 666666),
            new Clinker("Dirty Dan", 77777)
        };

        public List<Clinker> GetAll()
        {
            return _clinkers;
        }

        public Clinker GetById(Guid id)
        {
            var clinker = _clinkers.FirstOrDefault(x => x.Id == id);

            if (clinker == null) return null;
            return clinker;
        }

        public List<Guid> GetClinkerServiceIds()
        {
            List<Guid> clinkerServiceIds = new List<Guid>();
            foreach (var clinker in _clinkers)
            {
                var serviceIds = clinker.Services;
                foreach (var serviceId in serviceIds)
                {
                    if (!clinkerServiceIds.Contains(serviceId))
                    {
                        clinkerServiceIds.Add(serviceId);
                    }
                }
            }
            return clinkerServiceIds;
        }

        public List<Guid> GetClinkerInterestIds()
        {
            List<Guid> clinkerInterestIds = new List<Guid>();
            foreach (Clinker clinker in _clinkers)
            {
                List<Guid> interestIds = clinker.Interests;
                foreach (Guid interestId in interestIds)
                {
                    if (!clinkerInterestIds.Contains(interestId))
                    {
                        clinkerInterestIds.Add(interestId);
                    }
                }
            }
            return clinkerInterestIds;
        }

        public List<Clinker> GetClinkersByInterest(Guid interestId)
        {
            List<Clinker> filteredClinkers = new List<Clinker>();

            foreach (Clinker clinker in _clinkers)
            {
                if (clinker.Interests.Contains(interestId))
                {
                    filteredClinkers.Add(clinker);
                }
            }

            return filteredClinkers;
        }

        public List<Service> GetServicesByClinker(Guid clinkerId)
        {
            var requestedClinker = _clinkers.FirstOrDefault(clinker => clinker.Id == clinkerId);

            if (requestedClinker == null) return null;

            var clinkerServiceIds = requestedClinker.Services;
            var clinkerServices = new List<Service>();

            foreach (var serviceId in clinkerServiceIds)
            {
                var clinkerService = new ServiceRepository().GetById(serviceId);
                clinkerServices.Add(clinkerService);
            }

            return clinkerServices;
        }

        public Clinker GetRandom()
        {
            Random random = new Random();
            int randomIndex = random.Next(0, _clinkers.Count);
            Clinker randomService = _clinkers[randomIndex];
            return randomService;
        }

        public List<Guid> GetRandomClinkers()
        {
            return new List<Guid> { GetRandom().Id, GetRandom().Id };
        }
    }
}
