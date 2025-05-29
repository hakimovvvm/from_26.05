namespace Domain.DTOs.GroupDTOs;

public class GetGroupDTO : CreateGroupDTO
{
    public int Id { get; set; }
    public DateTime EndAt { get; set; }
}
