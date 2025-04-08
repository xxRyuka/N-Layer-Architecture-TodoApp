using NLayer_TodoApp.Dtos.Interfaces;

namespace NLayer_TodoApp.Dtos.WorkDtos;

public class WorkCreateDto : IDto
{
    public string Definition { get; set; }
    public bool isCompleted { get; set; }
}