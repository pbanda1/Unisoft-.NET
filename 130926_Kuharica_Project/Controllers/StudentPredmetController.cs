using Microsoft.AspNetCore.Authorization;
using BusinessLayerLogic.DTOs;
using BusinessLayerLogic.Services;
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
    public class StudentPredmetController : ControllerBase
    {
        private readonly IStudentPredmetService _studentPredmetService;

        public StudentPredmetController(IStudentPredmetService studentPredmetService)
        {
            _studentPredmetService = studentPredmetService;

        }

        [HttpGet]
        public ActionResult<List<StudentPredmetDto>> GetAll()
        => Ok(_studentPredmetService.GetAll());

        [HttpGet("{studentId}/{predmetId}")]
        public ActionResult<StudentPredmetDto> GetByID(int studentId, int predmetId)
        {

            var studentPredmet = _studentPredmetService.GetByID(studentId, predmetId);

            if (studentPredmet == null) { return NotFound(); }

            return Ok(studentPredmet);

        }



        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult<StudentPredmetDto> Create([FromBody] StudentPredmetCreateDto studentPredmetCreateDto)
        {

            var created = _studentPredmetService.Create(studentPredmetCreateDto);
            return CreatedAtAction(nameof(GetByID), new { studentId = created.StudentID, predmetId = created.PredmetID }, created);

        }

        [HttpDelete("{studentId}/{predmetId}")]
        [Authorize(Roles = "Admin")]

        public IActionResult Delete(int studentId, int predmetId)
        {



            var deleted = _studentPredmetService.Delete(studentId, predmetId);
            if (deleted == null) { return NotFound(); }
            return NoContent();



        }
    }
}
