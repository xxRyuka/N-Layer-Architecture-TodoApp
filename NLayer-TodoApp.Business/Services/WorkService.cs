using AutoMapper;
using NLayer_TodoApp.Business.Interfaces;
using NLayer_TodoApp.DataAccess.UnitOfWork;
using NLayer_TodoApp.Dtos.WorkDtos;
using NLayer_TodoApp.Entities.Domains;

namespace NLayer_TodoApp.Business.Services;

public class WorkService : IWorkService
{
    private readonly IUow _uow;
    private readonly IMapper _mapper;

    public WorkService(IUow uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }

    public async Task<List<WorkListDto>> GetWorkListsAsync()
    {
        var list = await _uow.GetRepository<Work>().GetAllAsync();

       

        return _mapper.Map<List<WorkListDto>>(list);
    } // Mapped

    public async Task Create(WorkCreateDto workCreateDto)
    {
        if (workCreateDto is not null)
        {
            // Work work = new Work()
            // {
            //     Definition = workCreateDto.Definition,
            //     isCompleted = workCreateDto.isCompleted
            // };

            await _uow.GetRepository<Work>().AddAsync(_mapper.Map<Work>(workCreateDto));
            await _uow.SaveAsync();
        }
    } // Mapped

    public async Task<WorkListDto> GetWorkListByIdAsync(int id)
    {
        var entity = await _uow.GetRepository<Work>().GetByFilter(x => x.Id == id);
        
        if (entity is null) return null!; // Eğer kayıt bulunamazsa null dön.
        
        
        return _mapper.Map<WorkListDto>(entity);
        
        
        // return new()
        // {
        //     Id = entity.Id,
        //     Definition = entity.Definition,
        //     isCompleted = entity.isCompleted,
        // };
    } // Mapped 

    public async Task DeleteAsync(int id) // No Need To Map
    {
        var entity = await _uow.GetRepository<Work>().GetByFilter(x => x.Id == id);
        if (entity is not null)
            _uow.GetRepository<Work>().Delete(entity: entity);
        await _uow.SaveAsync();
    }

    public async Task Update(WorkUpdateDto workUpdateDto)
    {
        // var work = await _uow.GetRepository<Work>().GetByIdAsync(workUpdateDto.Id);

        //
        //
        // work.Definition = workUpdateDto.Definition;
        // work.isCompleted = workUpdateDto.isCompleted;

        _uow.GetRepository<Work>().Update(_mapper.Map<Work>(workUpdateDto));
        await _uow.SaveAsync();
    } // Mapped 

 
}
