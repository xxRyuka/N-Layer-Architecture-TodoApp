using Microsoft.AspNetCore.Mvc;
using NLayer_TodoApp.Business.Interfaces;
using NLayer_TodoApp.DataAccess.UnitOfWork;
using NLayer_TodoApp.Dtos.WorkDtos;

namespace NLayer_TodoApp.UI.Controllers;

public class HomeController : Controller
{

    private readonly IWorkService _workService;

    public HomeController(IWorkService workService)
    {
        _workService = workService;
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
        await _workService.Create(dto);

        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Edit(int id)
    {
        var listdto = await _workService.GetWorkListByIdAsync(id);
        return View(new WorkUpdateDto(){
            Definition=listdto.Definition,
            Id=listdto.Id,
            isCompleted=listdto.isCompleted
        });
    }

    [HttpPost]
    public async Task<IActionResult> Edit(WorkUpdateDto updateDto, int id)
    {
        if (updateDto.Id == id)
        {
            var entity = await _workService.GetWorkListByIdAsync(id);
            await _workService.Update(updateDto);
            return RedirectToAction("Index");
        }
        return View(updateDto);
    }

    public async Task<IActionResult> Remove(int id)
    {
        await _workService.DeleteAsync(id);
        return RedirectToAction("Index");
    }
}