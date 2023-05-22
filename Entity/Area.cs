namespace Entity;

public class Area
{
    public int AreaId { get; set; }
    public int AreaOwnerUserId { get; set; }
    public int AreaType { get; set; }
    public Users OwnerUser { get; set; }
    public Management Management { get; set; }
}
