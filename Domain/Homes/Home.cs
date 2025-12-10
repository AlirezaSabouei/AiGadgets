namespace Domain.Homes;

public class Home : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public Guid UserId { get; set; }
    public List<Guid> Users { get; set; }
    public List<Room> Rooms { get; set; }

    public Home()
    {
        Users = [];
        Rooms = [];
    }
}
