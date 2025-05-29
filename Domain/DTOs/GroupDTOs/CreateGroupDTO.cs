namespace Domain.DTOs.GroupDTOs;

public class CreateGroupDTO
{
    public string GroupName { get; set; }
    public int RequiredStudents { get; set; }
    public DateTime StatrtAt { get; set; } = DateTime.Now;
    public int CourseId { get; set; }
}
