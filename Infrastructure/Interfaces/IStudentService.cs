using Domain.ApiResponse;
using Domain.DTOs;
using Domain.DTOs.StudentDTOs;
using Domain.Entites;

namespace Infrastructure.Interfaces;

public interface IStudentService
{
    Task<Response<List<GetStudentDTO>>> GetStudentsAsync();
    Task<Response<GetStudentDTO>> GetStudentAsync(int id);
    Task<Response<string>> CreateStudentAsync(CreateStudentDTO student);
    Task<Response<string>> UpdateStudentAsync(UpdateStudentDTO student);
    Task<Response<string>> DeleteStudentAsync(int id);
}
