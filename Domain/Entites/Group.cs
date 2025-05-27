namespace Domain.Entites;

public class Group
{
    public int Id { get; set; }
    public string GroupName { get; set; }
    public int RequiredStudents { get; set; }
    public DateTime StatrtAt { get; set; }
    public DateTime EndAt { get; set; }
    public int CourseId { get; set; }

    public Course Course { get; set; }
    public List<StudentGroup> MyProperty { get; set; }

}
