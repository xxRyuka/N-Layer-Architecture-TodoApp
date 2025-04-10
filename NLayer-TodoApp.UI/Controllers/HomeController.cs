using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NLayer_TodoApp.Business.Interfaces;
using NLayer_TodoApp.Common.ResponseObjects;
using NLayer_TodoApp.DataAccess.UnitOfWork;
using NLayer_TodoApp.Dtos.WorkDtos;
using NLayer_TodoApp.UI.Extensions;

namespace NLayer_TodoApp.UI.Controllers;

public class HomeController : Controller
{
    private readonly IWorkService _workService;
    private readonly IMapper _mapper;

    public HomeController(IWorkService workService, IMapper mapper)
    {
        _workService = workService;
        _mapper = mapper;
    }

    public async Task<IActionResult> Index()
    {
        var worklist = await _workService.GetWorkListsAsync();
        return View(worklist);
    }


    [HttpGet]
    public async Task<IActionResult> Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(WorkCreateDto dto)
    {
        var cevap = await _workService.Create(dto);

       
        return this.ResponsedRedirectToAction("Index",cevap);
        // return RedirectToAction("Index");
    }

    public async Task<IActionResult> Edit(int id)
    {
        // Mapperi kaldirip WorkService refactor edelim  
        var listdto = await _workService.GetByIdAsync<WorkUpdateDto>(id);
        return View(listdto);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(WorkUpdateDto updateDto, int id)
    {
        if (updateDto.Id == id)
        {
            ;
            await _workService.Update(updateDto);
            return RedirectToAction("Index");
        }

        Console.WriteLine("----- Updated Entity ------");

        return View(updateDto);
    }

    public async Task<IActionResult> Remove(int id)
    {
        await _workService.DeleteAsync(id);
        return RedirectToAction("Index");
    }
}