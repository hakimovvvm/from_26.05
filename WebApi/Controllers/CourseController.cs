using Domain.ApiResponse;
using Domain.DTOs;
using Domain.Entites;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CourseController(ICourseService crServ) : ControllerBase
{
    [HttpGet]
    public async Task<Response<List<CourseDTO>>> GetAllCoursesAsync()
    {
        return await crServ.GetCoursesAsync();
    }

    [HttpGet("Get by id")]
    public async Task<Response<CourseDTO?>> GetCourseByIdAsync(int id)
    {
        return await crServ.GetCourseAsync(id);
    }

    [HttpPost]
    public async Task<Response<string>> CreateCourseAsync(CourseDTO course)
    {
        return await crServ.CreateCourseAsync(course);
    }

    [HttpPut]
    public async Task<Response<string>> UpdateCourseAsync(CourseDTO course)
    {
        return await crServ.UpdateCourseAsync(course);
    }

    [HttpDelete]
    public async Task<Response<string>> DeleteCourseAsync(int id)
    {
        return await crServ.DeleteCourseAsync(id);
    }
}
