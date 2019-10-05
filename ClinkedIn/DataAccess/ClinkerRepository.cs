using ClinkedIn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore.Design;

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
                Services = new ServiceRepository().GetTwoRandomServiceIdList(),
                Interests = new InterestRepository().GetRandomInterests(),
            },
            new Clinker()
            {
                Id = Guid.NewGuid(),
                Name = "Bubba",
                InmateNum = 937463,
                FriendsList = new List<Guid>(),
                EnemiesList =  new List<Guid>(),
                Services = new ServiceRepository().GetTwoRandomServiceIdList(),
                Interests = new InterestRepository().GetRandomInterests(),
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

        public Clinker AddInterest(Guid clinkerId, Guid interestId)
        {
            var clinkerToUpdate = _clinkers.First(clinker => clinker.Id == clinkerId);
            var interests = new InterestRepository().GetAll();
            var interestCheck = clinkerToUpdate.Interests.Contains(interestId);

            if (!interestCheck)
            {
                foreach (var interest in interests)
                {
                    if (interest.Id == interestId)
                    {
                        clinkerToUpdate.Interests.Add(interestId);
                    }
                }
            }
            return clinkerToUpdate;
        }

        public Clinker AddService(Guid clinkerId, Guid serviceId)
        {
            var clinkerToUpdate = _clinkers.First(clinker => clinker.Id == clinkerId);
            var services = new ServiceRepository().GetAll();
            var serviceCheck = clinkerToUpdate.Services.Contains(serviceId);

            if (!serviceCheck)
            {
                foreach (var service in services)
                {
                    if (service.Id == serviceId)
                    {
                        clinkerToUpdate.Services.Add(serviceId);
                    }
                }
            }
            return clinkerToUpdate;
        }

        public Clinker AddFriend(Guid clinkerId, Guid friendId)
        {
            var clinkerToUpdate = _clinkers.First(clinker => clinker.Id == clinkerId);
            var enemyCheck = clinkerToUpdate.EnemiesList.Contains(friendId);
            var friendCheck = clinkerToUpdate.FriendsList.Contains(friendId);

            if (!enemyCheck && !friendCheck)
            {
                foreach (var clinker in _clinkers)
                {
                    if (clinker.Id == friendId)
                    {
                        clinkerToUpdate.FriendsList.Add(friendId);
                    }
                }
            }
            return clinkerToUpdate;
        }

        public Clinker AddEnemy(Guid clinkerId, Guid enemyId)
        {
            var clinkerToUpdate = _clinkers.First(clinker => clinker.Id == clinkerId);
            var enemyCheck = clinkerToUpdate.EnemiesList.Contains(enemyId);
            var friendCheck = clinkerToUpdate.FriendsList.Contains(enemyId);

            if (!enemyCheck && !friendCheck)
            {
                foreach (var clinker in _clinkers)
                {
                    if (clinker.Id == enemyId)
                    {
                        clinkerToUpdate.EnemiesList.Add(enemyId);
                    }
                }
            }
            return clinkerToUpdate;
        }

        public void DeleteClinker(Guid clinkerId)
        {
            var clinkerToDelete = _clinkers.First(clinker => clinker.Id == clinkerId);

            _clinkers.Remove(clinkerToDelete);
        }

        public void RemoveServiceFromServiceList(Guid clinkerId, Guid serviceId)
        {
            var clinkerToUpdate = _clinkers.First(clinker => clinker.Id == clinkerId);

            DeleteThis(clinkerToUpdate.Services, serviceId);
        }

        public void RemoveInterestFromInterestList(Guid clinkerId, Guid interestId)
        {
            var clinkerToUpdate = _clinkers.First(clinker => clinker.Id == clinkerId);

            DeleteThis(clinkerToUpdate.Interests, interestId);
        }

        public void RemoveFriendFromFriendList(Guid clinkerId, Guid friendId)
        {
            var clinkerToUpdate = _clinkers.First(clinker => clinker.Id == clinkerId);

            DeleteThis(clinkerToUpdate.FriendsList, friendId);
        }

        public void RemoveEnemyFromEnemyList(Guid clinkerId, Guid enemyId)
        {
            var clinkerToUpdate = _clinkers.First(clinker => clinker.Id == clinkerId);

            DeleteThis(clinkerToUpdate.EnemiesList, enemyId);
        }

        private void DeleteThis(List<Guid> typeOfList, Guid itemToDelete)
        {
            typeOfList.Remove(itemToDelete);
        }
    }
}
