using Microsoft.AspNetCore.Authorization;

using BusinessLayerLogic.DTOs;
using AutoMapper;
using BusinessLayerLogic.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace _130926_Kuharica_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PredmetController : ControllerBase
    {
        //INJECTION 

        private readonly IPredmetService _predmetService;
     

        public PredmetController(IPredmetService predmetService)
        {
            _predmetService = predmetService;
       
        }

        [HttpGet]
        public ActionResult<List<PredmetDto>> GetAll()
        => Ok(_predmetService.GetAll());

        [HttpGet("{id}")]
        public ActionResult<PredmetDto> GetById([FromRoute] int id)
        {
            var predmet = _predmetService.GetByID(id);
            if (predmet == null) { return NotFound(); }
            return Ok(predmet);
        }

        [HttpGet("{id}/studenti")]
        public ActionResult<PredmetWithStudentiDto> GetWithStudenti(int id)
        {
                var predmet = _predmetService.GetWithStudenti(id);
                if (predmet == null) { return NotFound(); }
                return Ok(predmet);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult<PredmetDto> Create([FromBody] PredmetCreateDto predmetUpdateDto)
        {

            var predmet = _predmetService.Create(predmetUpdateDto);
            return CreatedAtAction(nameof(GetById), new { id = predmet.Id }, predmet);
        }




        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Update(int id, PredmetUpdateDto predmetUpdateDto)
        {
            var updated = _predmetService.Update(id, predmetUpdateDto);
            if (updated == null) { return NotFound(); }
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            var deletedSubject = _predmetService.Delete(id);
            if (deletedSubject == null) { return NotFound(); }
            return NoContent();
        }
    }
}
