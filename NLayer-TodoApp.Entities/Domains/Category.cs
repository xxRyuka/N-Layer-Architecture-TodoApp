using Microsoft.VisualBasic;

namespace NLayer_TodoApp.Entities.Domains;

public class Category
{
    public int Id { get; set; }
    public string? CategoryName { get; set; } = String.Empty;

    public List<CategoryWork> Works { get; set; } = new List<CategoryWork>(); // Navigation Property
}