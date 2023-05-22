namespace Entity;

public class Food : IEntity
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int Count { get; set; }
    public Users User { get; set; }
}