using Domain.ApiResponse;
using Domain.DTOs;
using Domain.DTOs.StudentDTOs;
using Domain.Entites;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentController(IStudentService stServ) : ControllerBase
{
    [HttpGet]
    public async Task<Response<List<GetStudentDTO>>> GetAllStudentsAsync()
    {
        return await stServ.GetStudentsAsync();
    }

    [HttpGet("Get by id")]
    public async Task<Response<GetStudentDTO>> GetStudentByIdAsync(int id)
    {
        return await stServ.GetStudentAsync(id);
    }

    [HttpPost]
    public async Task<Response<string>> CreateStudentAsync(CreateStudentDTO student)
    {
        return await stServ.CreateStudentAsync(student);
    }

    [HttpPut]
    public async Task<Response<string>> UpdateStudentAsync(UpdateStudentDTO student)
    {
        return await stServ.UpdateStudentAsync(student);
    }

    [HttpDelete]
    public async Task<Response<string>> DeleteStudentAsync(int id)
    {
        return await stServ.DeleteStudentAsync(id);
    }
}
