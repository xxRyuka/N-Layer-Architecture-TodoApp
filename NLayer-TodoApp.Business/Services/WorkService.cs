using AutoMapper;
using FluentValidation;
using NLayer_TodoApp.Business.Interfaces;
using NLayer_TodoApp.Business.Validations;
using NLayer_TodoApp.DataAccess.UnitOfWork;
using NLayer_TodoApp.Dtos.Interfaces;
using NLayer_TodoApp.Dtos.WorkDtos;
using NLayer_TodoApp.Entities.Domains;
using NLayer_TodoApp.Business.Validations;
using NLayer_TodoApp.Common.ResponseObjects;

namespace NLayer_TodoApp.Business.Services;

public class WorkService : IWorkService
{
    private readonly IUow _uow;
    private readonly IMapper _mapper;
    private readonly IValidator<WorkCreateDto> _createDtoValidator;
    private readonly IValidator<WorkUpdateDto> _updateDtoValidator;

    public WorkService(IUow uow, IMapper mapper, IValidator<WorkCreateDto> createDtoValidator,
        IValidator<WorkUpdateDto> updateDtoValidator)
    {
        _uow = uow;
        _mapper = mapper;
        _createDtoValidator = createDtoValidator;
        _updateDtoValidator = updateDtoValidator;
    }

    public async Task<List<WorkListDto>> GetWorkListsAsync()
    {
        var list = await _uow.GetRepository<Work>().GetAllAsync();


        return _mapper.Map<List<WorkListDto>>(list);
    } // Mapped

    public async Task<Response<WorkCreateDto>> Create(WorkCreateDto workCreateDto)
    {
        if (workCreateDto is null)
        {
            return Response<WorkCreateDto>.NotFound("WorkCreateDto is null");
        }

        var ValidationResult = await _createDtoValidator.ValidateAsync(workCreateDto);

        if (!ValidationResult.IsValid)
        {
            var ResponseError = new List<ResponseValidateErrors>();
            foreach (var item in ValidationResult.Errors)
            {
                ResponseError.Add(new ResponseValidateErrors()
                {
                    PropertyName = item.PropertyName,
                    ErrorMessage = item.ErrorMessage
                });
            }

            return Response<WorkCreateDto>.ValidateError(workCreateDto, "Valid degil", ResponseType.ValidateError,
                ResponseError);
        }

        await _uow.GetRepository<Work>().AddAsync(_mapper.Map<Work>(workCreateDto));
        await _uow.SaveAsync();
        
        return Response<WorkCreateDto>.Success(workCreateDto);
        
        
        // if (workCreateDto is not null)
        // {
        //     // Work work = new Work()
        //     // {
        //     //     Definition = workCreateDto.Definition,
        //     //     isCompleted = workCreateDto.isCompleted
        //     // };
        //
        //
        //     var v1 = _createDtoValidator.Validate(workCreateDto);
        //     if (!v1.IsValid)
        //     {
        //         foreach (var err in v1.Errors)
        //         {
        //             Console.WriteLine("\n \n \n \n @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@ : " + err.ErrorMessage);
        //         }
        //     }
        //     else
        //     {
        //         await _uow.GetRepository<Work>().AddAsync(_mapper.Map<Work>(workCreateDto));
        //         await _uow.SaveAsync();
        //     }
        // }
    } // Mapped

    public async Task<IDto> GetByIdAsync<IDto>(int id)
    {
        // Burda muazzam birşey yaptik artık getbyId<T> generic hale getirdik 
        // ornek kullanık GetById<WorkUpdateDto>(id?)  muazzam birşey oldu ya 
        var entity = await _uow.GetRepository<Work>().GetByFilter(x => x.Id == id);

        var dto = _mapper.Map<IDto>(entity);
        return (dto);


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
        var original = await _uow.GetRepository<Work>().GetByIdAsync(workUpdateDto.Id);

        _uow.GetRepository<Work>().Update(_mapper.Map<Work>(workUpdateDto), original);
        await _uow.SaveAsync();
    } // Mapped 
}