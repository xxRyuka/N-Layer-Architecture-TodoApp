using System.ComponentModel.DataAnnotations.Schema;

namespace NLayer_TodoApp.Entities.Domains;

public class CategoryWork
{
    public int CategoryId { get; set; }
    public Category? Category { get; set; }
    
    public int WorkId { get; set; }
    public Work? Work { get; set; }
}