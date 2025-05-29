using Domain.Enums;

namespace Domain.DTOs.StudentDTOs;

public class CreateStudentDTO
{
    public string FirstName { get; set; }
    public string? LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public Status Status { get; set; }
}
