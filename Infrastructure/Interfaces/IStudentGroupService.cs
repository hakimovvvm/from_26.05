using Domain.ApiResponse;
using Domain.DTOs;
using Domain.Entites;

namespace Infrastructure.Interfaces;

public interface IStudentGroupService
{
    Task<Response<List<StudentGroupDTO>>> GetStudentGroupsAsync();
    Task<Response<StudentGroupDTO?>> GetStudentGroupAsync(int studentId, int groupId);
    Task<Response<string>> CreateStudentGroupAsync(StudentGroupDTO StudentGroup);
    Task<Response<string>> UpdateStudentGroupAsync(StudentGroupDTO StudentGroup);
    Task<Response<string>> DeleteStudentGroupAsync(int studentId, int groupId);
}
