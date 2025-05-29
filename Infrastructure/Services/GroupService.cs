using System.Net;
using Domain.ApiResponse;
using Domain.DTOs;
using Domain.DTOs.GroupDTOs;
using Domain.Entites;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class GroupService(DataContext context) : IGroupService
{
    public async Task<Response<string>> CreateGroupAsync(CreateGroupDTO group)
    {
        var newSt = new Group
        {
            GroupName = group.GroupName,
            RequiredStudents = group.RequiredStudents,
            StatrtAt = group.StatrtAt,
            CourseId = group.CourseId
        };
        await context.Groups.AddAsync(newSt);
        var res = await context.SaveChangesAsync();
        return res == 0
        ? new Response<string>("Some thing went wrong", HttpStatusCode.InternalServerError)
        : new Response<string>(null!, "Success");
    }

    public async Task<Response<string>> DeleteGroupAsync(int id)
    {
        var group = await context.Groups.FindAsync(id);
        if (group == null)
        {
            return new Response<string>("group not found", HttpStatusCode.NotFound);
        }

        context.Groups.Remove(group);
        var res = await context.SaveChangesAsync();
        return res == 0
        ? new Response<string>("Some thing went wrong", HttpStatusCode.InternalServerError)
        : new Response<string>(null!, "Success");
    }

    public async Task<Response<GetGroupDTO>> GetGroupAsync(int id)
    {
        var group = await context.Groups.FindAsync(id);
        if (group == null)
        {
            return new Response<GetGroupDTO>("group not found", HttpStatusCode.NotFound);
        }
        var result = new GetGroupDTO
        {
            GroupName = group.GroupName,
            RequiredStudents = group.RequiredStudents,
            StatrtAt = group.StatrtAt,
            EndAt = group.EndAt,
            CourseId = group.CourseId
        };
        return result == null
        ? new Response<GetGroupDTO>("Something went wrong", HttpStatusCode.InternalServerError)
        : new Response<GetGroupDTO>(result, "success");
    }

    public async Task<Response<List<GetGroupDTO>>> GetGroupsAsync()
    {
        var groups = await context.Groups.ToListAsync();
        var result = groups.Select(gr => new GetGroupDTO
        {
            GroupName = gr.GroupName,
            RequiredStudents = gr.RequiredStudents,
            StatrtAt = gr.StatrtAt,
            EndAt = gr.EndAt,
            CourseId = gr.CourseId
        }).ToList();
        return result == null
        ? new Response<List<GetGroupDTO>>("Something went wrong", HttpStatusCode.InternalServerError)
        : new Response<List<GetGroupDTO>>(result, "success");
    }

    public async Task<Response<string>> UpdateGroupAsync(UpdateGroupDTO group)
    {
        var gr = await context.Groups.FindAsync(group.Id);
        if (gr == null)
        {
            return new Response<string>("group not found", HttpStatusCode.NotFound);
        }

        gr.GroupName = group.GroupName;
        gr.RequiredStudents = group.RequiredStudents;
        gr.StatrtAt = group.StatrtAt;
        gr.CourseId = group.CourseId;

        var res = await context.SaveChangesAsync();
        return res == null
        ? new Response<string>("Something went wrong", HttpStatusCode.InternalServerError)
        : new Response<string>(null!, "success");
    }
}
