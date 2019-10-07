using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinkedIn.Command;
using ClinkedIn.DataAccess;
using ClinkedIn.Command;
using ClinkedIn.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinkedIn.Controllers
{
    [Route("api/clinkers")]
    [ApiController]
    public class ClinkersController : ControllerBase
    {
        // GET api/clinkers
        [HttpGet]
        public ActionResult<IEnumerable<Clinker>> GetAllClinkers()
        {
            return new ClinkerRepository().GetAll();
        }

        // GET api/clinkers/services
        [HttpGet("services")]
        public ActionResult<IEnumerable<Service>> GetAvailableServices()
        {
            return new ServiceRepository().GetAllAvailableServices();
        }

        // GET api/clinkers/clinkerId/services
        [HttpGet("{clinkerId}/services")]
        public ActionResult<IEnumerable<Service>> GetServicesByClinkerId(Guid clinkerId)
        {
            return new ClinkerRepository().GetServicesByClinker(clinkerId);
        }

        [HttpGet("interests/all")]
        public ActionResult<IEnumerable<Interest>> GetAllInterests()
        {
            var repo = new InterestRepository();
            return repo.GetAll();
        }

        // GET api/clinkers/interests
        [HttpGet("interests")]
        public ActionResult<IEnumerable<Interest>> GetRepresentedInterests()
        {
            return new InterestRepository().GetAllRepresentedInterests();
        }

        // GET api/clinkers/interests/interestId
        [HttpGet("interests/{interestId}")]
        public ActionResult<IEnumerable<Clinker>> GetClinkersByInterest(Guid interestId)
        {
            return new ClinkerRepository().GetClinkersByInterest(interestId);
        }

        // POST api/clinkers
        [HttpPost]
        public IActionResult CreateClinker(NewClinkerCommand newClinkerCommand)
        {
            Clinker newClinker = new Clinker(newClinkerCommand.Name, newClinkerCommand.InmateNum);

            ClinkerRepository repo = new ClinkerRepository();
            var clinkerThatGotCreated = repo.Add(newClinker);

            return Created($"api/clinkers/{clinkerThatGotCreated.Id}", clinkerThatGotCreated);
        }

        // GET api/clinkers/clinkerId
        [HttpGet("{clinkerId}")]

        public ActionResult<Clinker> GetClinkerById(Guid clinkerId)
        {
            return new ClinkerRepository().GetById(clinkerId);
        }

        // api/clinkers/clinkerid/interests/interestid
        [HttpPut("{clinkerId}/interests/{interestId}")]
        public IActionResult UpdateClinkerInterest(Guid clinkerId, Guid interestId)
        {
            var repo = new ClinkerRepository();

            var clinkerThatGotUpdated = repo.AddInterest(clinkerId, interestId);

            return Ok(clinkerThatGotUpdated);
        }


        // api/clinkers/{clinkerGUID}/services/{serviceGUID}
        [HttpPut("{clinkerId}/services/{serviceId}")]
        public IActionResult UpdateClinkerService(Guid clinkerId, Guid serviceId)
        {
            var repo = new ClinkerRepository();

            var clinkerThatGotUpdated = repo.AddService(clinkerId, serviceId);

            return Ok(clinkerThatGotUpdated);
        }


        // api/clinkers/{clinkerGUID}/friends/{friendGUID}
        [HttpPut("{clinkerId}/friends/{friendId}")]
        public IActionResult UpdateClinkerFriend(Guid clinkerId, Guid friendId)
        {
            var repo = new ClinkerRepository();

            var clinkerThatGotUpdated = repo.AddFriend(clinkerId, friendId);

            return Ok(clinkerThatGotUpdated);
        }


        // api/clinkers/{clinkerGUID}/enemy/{enemyGUID}
        [HttpPut("{clinkerId}/enemies/{enemyId}")]
        public IActionResult UpdateClinkerEnemy(Guid clinkerId, Guid enemyId)
        {
            var repo = new ClinkerRepository();

            var clinkerThatGotUpdated = repo.AddEnemy(clinkerId, enemyId);

            return Ok(clinkerThatGotUpdated);
        }


        [HttpDelete("{clinkerId}")]
        public IActionResult DeleteClinker(Guid clinkerId)
        {
            var repo = new ClinkerRepository();
            repo.DeleteClinker(clinkerId);

            return Ok();
        }


        [HttpDelete("{clinkerId}/services/{serviceId}")]
        public IActionResult RemoveServiceFromServiceList(Guid clinkerId, Guid serviceId)
        {
            var repo = new ClinkerRepository();
            repo.RemoveServiceFromServiceList(clinkerId, serviceId);

            return Ok();
        }

        [HttpDelete("{clinkerId}/interests/{interestId}")]
        public IActionResult RemoveInterestFromInterestList(Guid clinkerId, Guid interestId)
        {
            var repo = new ClinkerRepository();
            repo.RemoveInterestFromInterestList(clinkerId, interestId);

            return Ok();
        }


        [HttpDelete("{clinkerId}/friends/{friendId}")]
        public IActionResult RemoveFriendFromFriendList(Guid clinkerId, Guid friendId)
        {
            var repo = new ClinkerRepository();
            repo.RemoveFriendFromFriendList(clinkerId, friendId);

            return Ok();
        }

        [HttpDelete("{clinkerId}/enemies/{enemyId}")]
        public IActionResult RemoveEnemyFromEnemyList(Guid clinkerId, Guid enemyId)
        {
            var repo = new ClinkerRepository();
            repo.RemoveEnemyFromEnemyList(clinkerId, enemyId);

            return Ok();
        }
    }
}