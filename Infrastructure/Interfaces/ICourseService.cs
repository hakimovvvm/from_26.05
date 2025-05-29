using Domain.ApiResponse;
using Domain.DTOs;
using Domain.DTOs.CourseDTOs;
using Domain.Entites;

namespace Infrastructure.Interfaces;

public interface ICourseService
{
    Task<Response<List<GetCourseDTO>>> GetCoursesAsync();
    Task<Response<GetCourseDTO>> GetCourseAsync(int id);
    Task<Response<string>> CreateCourseAsync(CreateCourseDTO course);
    Task<Response<string>> UpdateCourseAsync(UpdateCourseDTO upCourse);
    Task<Response<string>> DeleteCourseAsync(int id);
}
