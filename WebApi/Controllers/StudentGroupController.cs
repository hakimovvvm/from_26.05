using Domain.ApiResponse;
using Domain.DTOs;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentGroupGroupController(IStudentGroupService stGrServ) : ControllerBase
{
    [HttpGet]
    public async Task<Response<List<StudentGroupDTO>>> GetAllStudentGroupsAsync()
    {
        return await stGrServ.GetStudentGroupsAsync();
    }

    [HttpGet("Get by id")]
    public async Task<Response<StudentGroupDTO?>> GetStudentGroupByIdAsync(int studentId, int groupId)
    {
        return await stGrServ.GetStudentGroupAsync(studentId, groupId);
    }

    [HttpPost]
    public async Task<Response<string>> CreateStudentGroupAsync(StudentGroupDTO studentGroup)
    {
        return await stGrServ.CreateStudentGroupAsync(studentGroup);
    }

    [HttpPut]
    public async Task<Response<string>> UpdateStudentGroupAsync(StudentGroupDTO studentGroup)
    {
        return await stGrServ.UpdateStudentGroupAsync(studentGroup);
    }

    [HttpDelete]
    public async Task<Response<string>> DeleteStudentGroupAsync(int studentId, int groupId)
    {
        return await stGrServ.DeleteStudentGroupAsync(studentId, groupId);
    }
}
