namespace Entity;

public class Stuff: IEntity
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public float Count { get; set; }
    public Users User { get; set; }
}