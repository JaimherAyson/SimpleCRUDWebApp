using SimpleCRUDWebApp.Server.Entities;

namespace SimpleCRUDWebApp.Server.Services.Contracts
{
    public interface IStudentService
    {
        Task<List<Student>> GetStudentsAsync();
        Task<Student?> GetStudentByIdAsync(int id);
        Task<Student> AddStudentAsync(Student newStudent);
        Task<bool> UpdateStudentAsync(int id, Student updatedStudent);
        Task<bool> DeleteStudentAsync(int id);
    }
}
