using System.Net;
using Domain.ApiResponse;
using Domain.DTOs;
using Domain.Entites;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class StudentService(DataContext context) : IStudentService
{
    public async Task<Response<string>> CreateStudentAsync(StudentDTO student)
    {
        var newSt = new Student
        {
            FirstName = student.FirstName,
            LastName = student.LastName,
            BirthDate = student.BirthDate,
            Status = student.Status
        };
        await context.Students.AddAsync(newSt);
        var res = await context.SaveChangesAsync();
        return res == 0
        ? new Response<string>("Some thing went wrong", HttpStatusCode.InternalServerError)
        : new Response<string>(null, "Success");
    }

    public async Task<Response<string>> DeleteStudentAsync(int id)
    {
        var student = await context.Students.FindAsync(id);
        if (student == null)
        {
            return new Response<string>("student not found", HttpStatusCode.NotFound);
        }

        context.Students.Remove(student);
        var res = await context.SaveChangesAsync();
        return res == 0
        ? new Response<string>("Some thing went wrong", HttpStatusCode.InternalServerError)
        : new Response<string>(null, "Success");
    }

    public async Task<Response<StudentDTO?>> GetStudentAsync(int id)
    {
        var student = await context.Students.FindAsync(id);
        if (student == null)
        {
            return new Response<StudentDTO?>("student not found", HttpStatusCode.NotFound);
        }

        var result = new StudentDTO
        {
            Id = student.Id,
            FirstName = student.FirstName,
            LastName = student.LastName,
            BirthDate = student.BirthDate,
            Status = student.Status
        };
        return result == null
        ? new Response<StudentDTO?>("Something went wrong", HttpStatusCode.InternalServerError)
        : new Response<StudentDTO?>(result, "success");
    }

    public async Task<Response<List<StudentDTO>>> GetStudentsAsync()
    {
        var students = await context.Students.ToListAsync();
        var result = students.Select(st => new StudentDTO
        {
            Id = st.Id,
            FirstName = st.FirstName,
            LastName = st.LastName,
            BirthDate = st.BirthDate,
            Status = st.Status
        }).ToList();
        return result == null
        ? new Response<List<StudentDTO>>("Something went wrong", HttpStatusCode.InternalServerError)
        : new Response<List<StudentDTO>>(result, "success");
    }

    public async Task<Response<string>> UpdateStudentAsync(StudentDTO student)
    {
        var st = await context.Students.FindAsync(student.Id);
        if (st == null)
        {
            return new Response<string>("student not found", HttpStatusCode.NotFound);
        }

        st.FirstName = student.FirstName;
        st.LastName = student.LastName;
        st.BirthDate = student.BirthDate;
        st.Status = student.Status;

        var res = await context.SaveChangesAsync();
        return res == null
        ? new Response<string>("Something went wrong", HttpStatusCode.InternalServerError)
        : new Response<string>(null, "success");
    }
}
