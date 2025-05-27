using Domain.Enums;

namespace Domain.Entites;

public class Student
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string? LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public Status Status { get; set; }

    public Address Address { get; set; }
    public List<StudentGroup> MyProperty { get; set; }
}
