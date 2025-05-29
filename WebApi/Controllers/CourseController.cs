using Domain.ApiResponse;
using Domain.DTOs;
using Domain.DTOs.CourseDTOs;
using Domain.Entites;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CourseController(ICourseService crServ) : ControllerBase
{
    [HttpGet]
    public async Task<Response<List<GetCourseDTO>>> GetAllCoursesAsync()
    {
        return await crServ.GetCoursesAsync();
    }

    [HttpGet("Get by id")]
    public async Task<Response<GetCourseDTO>> GetCourseByIdAsync(int id)
    {
        return await crServ.GetCourseAsync(id);
    }

    [HttpPost]
    public async Task<Response<string>> CreateCourseAsync(CreateCourseDTO course)
    {
        return await crServ.CreateCourseAsync(course);
    }

    [HttpPut]
    public async Task<Response<string>> UpdateCourseAsync(UpdateCourseDTO upCourse)
    {
        return await crServ.UpdateCourseAsync(upCourse);
    }

    [HttpDelete]
    public async Task<Response<string>> DeleteCourseAsync(int id)
    {
        return await crServ.DeleteCourseAsync(id);
    }
}
