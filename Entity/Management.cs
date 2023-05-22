namespace Entity;

public class Management: IEntity
{
    public int Id { get; set; }
    public int Type { get; set; }
    public float AdminCost { get; set; }
    public float UserCost { get; set; }
    public DateTime UserStartDate { get; set; }
    public DateTime UserEndDate { get; set; }
    public int UserWorkedDayCount { get; set; }
    public int UserCasualWorkTime { get; set; }
    public ICollection<ManagementDetails> ManagementDetails { get; set; }
}