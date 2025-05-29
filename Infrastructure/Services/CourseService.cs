using System.Net;
using Domain.ApiResponse;
using Domain.DTOs;
using Domain.DTOs.CourseDTOs;
using Domain.Entites;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class CourseService(DataContext context) : ICourseService
{
    public async Task<Response<string>> CreateCourseAsync(CreateCourseDTO course)
    {
        var newSt = new Course
        {
            Title = course.Title,
            Description = course.Description,
            Price = course.Price
        };
        await context.Courses.AddAsync(newSt);
        var res = await context.SaveChangesAsync();
        return res == 0
        ? new Response<string>("Some thing went wrong", HttpStatusCode.InternalServerError)
        : new Response<string>(null!, "Success");
    }

    public async Task<Response<string>> DeleteCourseAsync(int id)
    {
        var course = await context.Courses.FindAsync(id);
        if (course == null)
        {
            return new Response<string>("course not found", HttpStatusCode.NotFound);
        }

        context.Courses.Remove(course);
        var res = await context.SaveChangesAsync();
        return res == 0
        ? new Response<string>("Some thing went wrong", HttpStatusCode.InternalServerError)
        : new Response<string>(null!, "Success");
    }

    public async Task<Response<GetCourseDTO>> GetCourseAsync(int id)
    {
        var course = await context.Courses.FindAsync(id);
        if (course == null)
        {
            return new Response<GetCourseDTO>("course not found", HttpStatusCode.NotFound);
        }

        var result = new GetCourseDTO
        {
            Id = course.Id,
            Title = course.Title,
            Description = course.Description,
            Price = course.Price
        };
        return result == null
        ? new Response<GetCourseDTO>("Something went wrong", HttpStatusCode.InternalServerError)
        : new Response<GetCourseDTO>(result, "success");
    }

    public async Task<Response<List<GetCourseDTO>>> GetCoursesAsync()
    {
        var courses = await context.Courses.ToListAsync();
        var result = courses.Select(cr => new GetCourseDTO
        {
            Id = cr.Id,
            Title = cr.Title,
            Description = cr.Description,
            Price = cr.Price
        }).ToList();
        return result == null
        ? new Response<List<GetCourseDTO>>("Something went wrong", HttpStatusCode.InternalServerError)
        : new Response<List<GetCourseDTO>>(result, "success");
    }

    public async Task<Response<string>> UpdateCourseAsync(UpdateCourseDTO course)
    {
        var cr = await context.Courses.FindAsync(course.Id);
        if (cr == null)
        {
            return new Response<string>("course not found", HttpStatusCode.NotFound);
        }

        cr.Title = course.Title;
        cr.Description = course.Description;
        cr.Price = course.Price;

        var res = await context.SaveChangesAsync();
        return res == null
        ? new Response<string>("Something went wrong", HttpStatusCode.InternalServerError)
        : new Response<string>(null!, "success");
    }
}
