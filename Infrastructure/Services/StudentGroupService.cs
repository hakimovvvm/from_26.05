using System.Net;
using Domain.ApiResponse;
using Domain.DTOs;
using Domain.Entites;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class StudentGroupService(DataContext context) : IStudentGroupService
{
    public async Task<Response<string>> CreateStudentGroupAsync(StudentGroupDTO studentGroup)
    {
        var newSt = new StudentGroup
        {
            StudentId = studentGroup.StudentId,
            GroupId = studentGroup.GroupId
            
        };
        await context.StudentGroups.AddAsync(newSt);
        var res = await context.SaveChangesAsync();
        return res == 0
        ? new Response<string>("Some thing went wrong", HttpStatusCode.InternalServerError)
        : new Response<string>(null, "Success");
    }

    public async Task<Response<string>> DeleteStudentGroupAsync(int studentId, int groupId)
    {
        var studentGroup = await context.StudentGroups.FindAsync(studentId, groupId);
        if (studentGroup == null)
        {
            return new Response<string>("studentGroup not found", HttpStatusCode.NotFound);
        }

        context.StudentGroups.Remove(studentGroup);
        var res = await context.SaveChangesAsync();
        return res == 0
        ? new Response<string>("Some thing went wrong", HttpStatusCode.InternalServerError)
        : new Response<string>(null, "Success");
    }

    public async Task<Response<StudentGroupDTO?>> GetStudentGroupAsync(int studentId, int groupId)
    {
        var studentGroup = await context.StudentGroups.FindAsync(studentId, groupId);
        if (studentGroup == null)
        {
            return new Response<StudentGroupDTO?>("studentGroup not found", HttpStatusCode.NotFound);
        }

        var result = new StudentGroupDTO
        {
            StudentId = studentGroup.StudentId,
            GroupId = studentGroup.GroupId
        };
        return result == null
        ? new Response<StudentGroupDTO?>("Something went wrong", HttpStatusCode.InternalServerError)
        : new Response<StudentGroupDTO?>(result, "success");
    }

    public async Task<Response<List<StudentGroupDTO>>> GetStudentGroupsAsync()
    {
        var studentGroups = await context.StudentGroups.ToListAsync();
        var result = studentGroups.Select(stGr => new StudentGroupDTO
        {
            StudentId = stGr.StudentId,
            GroupId = stGr.GroupId
        }).ToList();
        return result == null
        ? new Response<List<StudentGroupDTO>>("Something went wrong", HttpStatusCode.InternalServerError)
        : new Response<List<StudentGroupDTO>>(result, "success");
    }

    public async Task<Response<string>> UpdateStudentGroupAsync(StudentGroupDTO studentGroup)
    {
        var stGr = await context.StudentGroups.FindAsync(studentGroup.StudentId, studentGroup.GroupId);
        if (stGr == null)
        {
            return new Response<string>("studentGroup not found", HttpStatusCode.NotFound);
        }

        stGr.StudentId = studentGroup.StudentId;
        stGr.GroupId = studentGroup.GroupId;

        var res = await context.SaveChangesAsync();
        return res == null
        ? new Response<string>("Something went wrong", HttpStatusCode.InternalServerError)
        : new Response<string>(null, "success");
    }
}
