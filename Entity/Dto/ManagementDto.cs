namespace Entity.Dto;

public class ManagementDto
{
    public int Type { get; set; }
    public float AdminCost { get; set; }
    public float UserCost { get; set; }
    public DateTime UserStartDate { get; set; }
    public DateTime UserEndDate { get; set; }
    public int UserWorkedDayCount { get; set; }
    public int UserCasualWorkTime { get; set; }
    public virtual ICollection<ManagementDetails> ManagementDetails { get; set; }
}