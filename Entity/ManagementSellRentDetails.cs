namespace Entity;

public class ManagementSellRentDetails : IEntity
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int ManagementId { get; set; }
}