using Domain.ApiResponse;
using Domain.DTOs;
using Domain.Entites;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GroupController(IGroupService grServ) : ControllerBase
{
    [HttpGet]
    public async Task<Response<List<GroupDTO>>> GetAllGroupsAsync()
    {
        return await grServ.GetGroupsAsync();
    }

    [HttpGet("Get by id")]
    public async Task<Response<GroupDTO?>> GetGroupByIdAsync(int id)
    {
        return await grServ.GetGroupAsync(id);
    }

    [HttpPost]
    public async Task<Response<string>> CreateGroupAsync(GroupDTO group)
    {
        return await grServ.CreateGroupAsync(group);
    }

    [HttpPut]
    public async Task<Response<string>> UpdateGroupAsync(GroupDTO group)
    {
        return await grServ.UpdateGroupAsync(group);
    }

    [HttpDelete]
    public async Task<Response<string>> DeleteGroupAsync(int id)
    {
        return await grServ.DeleteGroupAsync(id);
    }
}
