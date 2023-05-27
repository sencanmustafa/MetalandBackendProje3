namespace Entity;

public class ManagementSaleRentDetails : IEntity
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int ManagementId { get; set; }
    public Users User { get; set; }
    public Management Management { get; set; }
    
}