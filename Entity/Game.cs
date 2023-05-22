namespace Entity;

public class Game: IEntity
{
    public int Id { get; set; }
    public DateTime StartDate { get; set; }
    public string GameSize { get; set; }

}