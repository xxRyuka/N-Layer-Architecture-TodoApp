namespace NLayer_TodoApp.Entities.Domains;

public class BaseEntity
{
    public int Id { get; set; }
    public DateTime CreatedTime { get; set; }
    public DateTime ModifiedTime { get; set; } = DateTime.UtcNow;

}