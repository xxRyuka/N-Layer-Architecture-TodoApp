using NLayer_TodoApp.Common.ResponseObjects;
using NLayer_TodoApp.Dtos.Interfaces;
using NLayer_TodoApp.Dtos.WorkDtos;
using NLayer_TodoApp.Entities.Domains;

namespace NLayer_TodoApp.Business.Interfaces;

public interface IWorkService
{
    Task<List<WorkListDto>> GetWorkListsAsync();
    Task<Response<WorkCreateDto>> Create(WorkCreateDto workCreateDto);
    Task<IDto> GetByIdAsync<IDto>(int id);
    Task DeleteAsync(int id);
    
    Task Update(WorkUpdateDto workUpdateDto);
}

