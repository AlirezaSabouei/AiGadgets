namespace Domain;

public class BaseEntity
{
    public Guid Id { get; set; }

    public Guid CreatorId { get; set; }
    public DateTime CreationDate { get; set; }
    public Guid UpdatorId { get; set; }
    public DateTime ModifyDate { get; set; }
}
