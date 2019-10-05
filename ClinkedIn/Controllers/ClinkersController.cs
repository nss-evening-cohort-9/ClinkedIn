using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinkedIn.DataAccess;
using ClinkedIn.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinkedIn.Controllers
{
    [Route("api/[controller]")]
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
    }
}