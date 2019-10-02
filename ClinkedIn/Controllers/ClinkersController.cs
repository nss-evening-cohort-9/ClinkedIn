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

        [HttpPut("{id}")]
        public IActionResult UpdateClinker(UpdateClinkerCommand updatedClinkerCommand, Guid id)
        {
            var repo = new ClinkerRepository();

            var updatedClinker = new Clinker
            {
                Name = updatedClinkerCommand.Name,
                Interests = updatedClinkerCommand.Interests,
            };
            var clinkerThatGotUpdated = repo.UpdateInterest(updatedClinker, id);

            return Ok(clinkerThatGotUpdated);
        }

    }
}