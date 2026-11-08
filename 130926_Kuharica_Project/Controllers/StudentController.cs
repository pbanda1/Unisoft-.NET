

using BusinessLayerLogic.DTOs;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using BusinessLayerLogic.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.ConstrainedExecution;

namespace _130926_Kuharica_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;


        public StudentController(IStudentService studentService)
        {

            _studentService = studentService;
        }
        [HttpGet]
        public ActionResult<List<StudentDto>> GetAll()
        => Ok(_studentService.GetAll());

        [HttpGet("{id}")]
        public ActionResult<StudentDto> GetById([FromRoute] int id)
        {
            var student = _studentService.GetById(id);
            if (student == null) { return NotFound(); }
            return Ok(student);
        }

        [HttpGet("{id}/predmeti")]
        public ActionResult<StudentWithPredmetiDto> GetWithPredmeti(int id)
        {
            var student = _studentService.GetWithPredmeti(id);
            if (student == null) { return NotFound(); }
            return Ok(student); 
            
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult<StudentDto> Create([FromBody] StudentCreateDto studentCreateDto)
        {

          var created = _studentService.Create(studentCreateDto);
          return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }


        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Update(int id, [FromBody] StudentUpdateDto studentUpdateDto)
        {


            var updated = _studentService.Update(id, studentUpdateDto); 
            if (updated == null) { return NotFound();};
            return NoContent();


        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {


            var deletedStudent = _studentService.Delete(id);
            if (deletedStudent == null) { return NotFound(); }
            return NoContent();

        }

    }
}
