using Domain.ApiResponse;
using Domain.DTOs;
using Domain.DTOs.StudentGroupDTOs;
using Domain.Entites;

namespace Infrastructure.Interfaces;

public interface IStudentGroupService
{
    Task<Response<List<GetStudentGroupDTO>>> GetStudentGroupsAsync();
    Task<Response<GetStudentGroupDTO>> GetStudentGroupAsync(int studentId, int groupId);
    Task<Response<string>> CreateStudentGroupAsync(CreateStudentGroupDTO studentGroup);
    Task<Response<string>> UpdateStudentGroupAsync(UpdateStudentGroupDTO studentGroup);
    Task<Response<string>> DeleteStudentGroupAsync(int studentId, int groupId);
}
