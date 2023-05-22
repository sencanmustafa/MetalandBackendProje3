namespace Entity;

public class ManagementDetails: IEntity
{
    public int Id { get; set; }
    public int ManagementId { get; set; }
    public int ManagementLevel { get; set; }
    public int ManagementCapacity { get; set; }
    public int ManagementWorkerCount { get; set; }
    public int ManagementFoodPrice { get; set; }
    public int ManagementStuffPrice { get; set; }
    public int ManagementCommission { get; set; }
    public int ManagementRentTime { get; set; }
    public DateTime ManagementSellDate { get; set; }
    public DateTime ManagementRentDate { get; set; }
    public Management Management { get; set; }
    
}