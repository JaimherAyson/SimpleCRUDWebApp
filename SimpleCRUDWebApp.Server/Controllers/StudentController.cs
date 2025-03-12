using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleCRUDWebApp.Server.Data;
using SimpleCRUDWebApp.Server.Entities;
using SimpleCRUDWebApp.Server.Services.Contracts;

namespace SimpleCRUDWebApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController(IStudentService studentService) : ControllerBase
    {
        private readonly IStudentService _studentService = studentService;

        [HttpGet]
        public async Task<ActionResult<List<Student>>> GetStudents()
        {
            return Ok(await _studentService.GetStudentsAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudentById(int id)
        {
            var student = await _studentService.GetStudentByIdAsync(id);
            if (student is null)
                return NotFound();
            return Ok(student);
        }

        [HttpPost]
        public async Task<ActionResult<Student>> AddStudent(Student newStudent)
        {
            if (newStudent is null)
                return BadRequest();

            var student = await _studentService.AddStudentAsync(newStudent);
            return CreatedAtAction(nameof(GetStudentById), new { id = student.Id }, student);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(int id, Student updatedStudent)
        {
            var success = await _studentService.UpdateStudentAsync(id, updatedStudent);
            if (!success)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var success = await _studentService.DeleteStudentAsync(id);
            if (!success)
                return NotFound();

            return NoContent();
        }
    }
}