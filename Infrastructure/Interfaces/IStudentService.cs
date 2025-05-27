using Domain.ApiResponse;
using Domain.DTOs;
using Domain.Entites;

namespace Infrastructure.Interfaces;

public interface IStudentService
{
    Task<Response<List<StudentDTO>>> GetStudentsAsync();
    Task<Response<StudentDTO?>> GetStudentAsync(int id);
    Task<Response<string>> CreateStudentAsync(StudentDTO student);
    Task<Response<string>> UpdateStudentAsync(StudentDTO student);
    Task<Response<string>> DeleteStudentAsync(int id);
}
