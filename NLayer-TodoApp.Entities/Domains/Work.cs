namespace NLayer_TodoApp.Entities.Domains;

public class Work : BaseEntity
{
    public string? Definition { get; set; } = String.Empty;
    public bool isCompleted { get; set; }
    public List<CategoryWork> Categories { get; set; } = new List<CategoryWork>();  
}

