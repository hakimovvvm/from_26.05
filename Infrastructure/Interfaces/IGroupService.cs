using System.Text.RegularExpressions;
using Domain.ApiResponse;
using Domain.DTOs;
using Domain.DTOs.GroupDTOs;

namespace Infrastructure.Interfaces;

public interface IGroupService
{
    Task<Response<List<GetGroupDTO>>> GetGroupsAsync();
    Task<Response<GetGroupDTO>> GetGroupAsync(int id);
    Task<Response<string>> CreateGroupAsync(CreateGroupDTO group);
    Task<Response<string>> UpdateGroupAsync(UpdateGroupDTO group);
    Task<Response<string>> DeleteGroupAsync(int id);
}
