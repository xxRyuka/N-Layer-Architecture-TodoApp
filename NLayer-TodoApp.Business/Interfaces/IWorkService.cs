using NLayer_TodoApp.Dtos.WorkDtos;
using NLayer_TodoApp.Entities.Domains;

namespace NLayer_TodoApp.Business.Interfaces;

public interface IWorkService
{
    Task<List<WorkListDto>> GetWorkListsAsync();
    Task Create(WorkCreateDto workCreateDto);
    Task<WorkListDto> GetWorkListByIdAsync(int id);
    Task DeleteAsync(int id);
    
    Task Update(WorkUpdateDto workUpdateDto);
}