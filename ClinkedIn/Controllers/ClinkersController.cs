using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinkedIn.Command;
using ClinkedIn.DataAccess;
using ClinkedIn.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinkedIn.Controllers
{
    [Route("api/clinkers")]
    [ApiController]
    public class ClinkersController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<Clinker>> GetAllClinkers()
        {
            var repo = new ClinkerRepository();
            return repo.GetAll();
        }

        [HttpGet("interests")]
        public ActionResult<IEnumerable<Interest>> GetAllServices()
        {
            var repo = new InterestRepository();
            return repo.GetAll();
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


        [HttpPut("{clinkerId}/interests/{interestId}")]
        public IActionResult UpdateClinkerInterest(Guid clinkerId, Guid interestId)
        {
            var repo = new ClinkerRepository();

            var clinkerThatGotUpdated = repo.UpdateInterest(clinkerId, interestId);

            return Ok(clinkerThatGotUpdated);
        }


        [HttpPut("{clinkerId}/services/{serviceId}")]
        public IActionResult UpdateClinkerService(Guid clinkerId, Guid serviceId)
        {
            var repo = new ClinkerRepository();

            var clinkerThatGotUpdated = repo.UpdateService(clinkerId, serviceId);

            return Ok(clinkerThatGotUpdated);
        }
    }
}