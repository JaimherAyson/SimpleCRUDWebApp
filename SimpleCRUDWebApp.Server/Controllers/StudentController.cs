using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleCRUDWebApp.Server.Data;
using SimpleCRUDWebApp.Server.Entities;

namespace SimpleCRUDWebApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController(StudentDbContext context) : ControllerBase
    {
        private readonly StudentDbContext _context = context;

        [HttpGet]
        public async Task<ActionResult<List<Student>>> GetStudent()
        {
            return Ok(await _context.Students.ToListAsync());
        }

        [HttpGet("{id}")]
         public async Task<ActionResult<Student>> GetStudentById(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student is null)
                return NotFound();
            return Ok(student);
        }

        [HttpPost]
        public async Task<ActionResult<Student>> AddStudent(Student newStudent)
        {
            if (newStudent is null)
                return BadRequest();

            _context.Students.Add(newStudent);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetStudentById), new {id = newStudent.Id}, newStudent);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(int id, Student updatedStudent)
        {
            var student = await _context.Students.FindAsync(id);
            if (student is null)
                return NotFound();

            student.Name = updatedStudent.Name;
            student.Email = updatedStudent.Email;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student is null)
                return NotFound();

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    } 
}