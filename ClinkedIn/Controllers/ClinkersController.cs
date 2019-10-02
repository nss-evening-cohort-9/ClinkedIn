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

        [HttpPut("{clinkerId}/addInterest/{interestId}")]
        public IActionResult UpdateClinkerInterest(Guid clinkerId, Guid interestId)
        {
            var repo = new ClinkerRepository();

            var clinkerThatGotUpdated = repo.UpdateInterest(clinkerId, interestId);

           // var outputist = new List<MyNewTpeOfClinkerDTO>();
            foreach (var i in clinkerThatGotUpdated.Interests)
            {

            }

            var interestRepo = new InterestRepository();

            var addedInterest = interestRepo.GetById(interestId);

            addedInterest.Name;

            return Ok(clinkerThatGotUpdated);
        }

    }
}