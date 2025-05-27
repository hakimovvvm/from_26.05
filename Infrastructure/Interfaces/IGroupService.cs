using System.Text.RegularExpressions;
using Domain.ApiResponse;
using Domain.DTOs;

namespace Infrastructure.Interfaces;

public interface IGroupService
{
    Task<Response<List<GroupDTO>>> GetGroupsAsync();
    Task<Response<GroupDTO?>> GetGroupAsync(int id);
    Task<Response<string>> CreateGroupAsync(GroupDTO group);
    Task<Response<string>> UpdateGroupAsync(GroupDTO group);
    Task<Response<string>> DeleteGroupAsync(int id);
}
