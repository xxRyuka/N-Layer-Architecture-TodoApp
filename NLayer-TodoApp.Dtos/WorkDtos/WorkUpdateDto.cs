using NLayer_TodoApp.Dtos.Interfaces;

namespace NLayer_TodoApp.Dtos.WorkDtos;

public class WorkUpdateDto : IDto
{
    public int Id { get; set; }
    public string Definition { get; set; }
    public bool isCompleted { get; set; }
}