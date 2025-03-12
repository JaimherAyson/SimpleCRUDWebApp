using SimpleCRUDWebApp.Server.Data;
using SimpleCRUDWebApp.Server.Entities;
using SimpleCRUDWebApp.Server.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace SimpleCRUDWebApp.Server.Services
{
    public class StudentServices
    {

        public class StudentService(StudentDbContext context) : IStudentService
        {
            private readonly StudentDbContext _context = context;

            public async Task<List<Student>> GetStudentsAsync()
            {
                return await _context.Students.ToListAsync();
            }

            public async Task<Student?> GetStudentByIdAsync(int id)
            {
                return await _context.Students.FindAsync(id);
            }

            public async Task<Student> AddStudentAsync(Student newStudent)
            {
                _context.Students.Add(newStudent);
                await _context.SaveChangesAsync();
                return newStudent;
            }

            public async Task<bool> UpdateStudentAsync(int id, Student updatedStudent)
            {
                var student = await _context.Students.FindAsync(id);
                if (student is null) return false;

                student.Name = updatedStudent.Name;
                student.Email = updatedStudent.Email;

                await _context.SaveChangesAsync();
                return true;
            }

            public async Task<bool> DeleteStudentAsync(int id)
            {
                var student = await _context.Students.FindAsync(id);
                if (student is null) return false;

                _context.Students.Remove(student);
                await _context.SaveChangesAsync();
                return true;
            }
        }
    }
}
