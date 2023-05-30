namespace Entity;

public class Management: IEntity
{
    public int Id { get; set; }
    public int Type { get; set; }
    public double AdminCost { get; set; }
    public double UserCost { get; set; }
    public DateTime UserStartDate { get; set; }
    public DateTime UserEndDate { get; set; }
    public int UserWorkedDayCount { get; set; }
    public int UserCasualWorkTime { get; set; }
    public virtual ICollection<ManagementDetails> ManagementDetails { get; set; }
}