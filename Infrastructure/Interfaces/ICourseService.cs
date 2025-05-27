using Domain.ApiResponse;
using Domain.DTOs;
using Domain.Entites;

namespace Infrastructure.Interfaces;

public interface ICourseService
{
    Task<Response<List<CourseDTO>>> GetCoursesAsync();
    Task<Response<CourseDTO?>> GetCourseAsync(int id);
    Task<Response<string>> CreateCourseAsync(CourseDTO course);
    Task<Response<string>> UpdateCourseAsync(CourseDTO course);
    Task<Response<string>> DeleteCourseAsync(int id);
}
