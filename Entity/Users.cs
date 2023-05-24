namespace Entity;

public class Users: IEntity
{
    public int UserId { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Password { get; set; }
    public int Role { get; set; }  
    public virtual ICollection<Area> Areas { get; set; }
    public virtual ICollection<Food> Foods { get; set; }
    public virtual ICollection<Money> Money { get; set; }
    public virtual ICollection<Stuff> Stuff { get; set; }
    
}