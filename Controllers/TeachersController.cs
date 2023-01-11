using Microsoft.AspNetCore.Mvc;
using quizapp.Interfaces;
using quizapp.Models;

namespace quizapp.Controllers;

public class TeachersController : Controller
{
    private readonly ITeacherRepo _repo;

    public TeachersController(ITeacherRepo repo){
        this._repo = repo;
    }

    public async Task<IActionResult> Index(){
        List<Teacher> teachers = await _repo.GetAllTeachersAsync();
        return View(teachers);
    }

    [HttpPost]
    public async Task<IActionResult> CreateTeacher(Teacher teacher)
    {
        if(await _repo.AddTeacherAsync(teacher)){
            return RedirectToAction("Index");
        }
        return BadRequest("ERROR");
    }

    [HttpGet]
    public IActionResult CreateTeacher()
    {
        return View();
    }

    
    [HttpPost]
    public async Task<IActionResult> DeleteTeacher(int id)
    {
        if (await _repo.DeleteTeacherAsync(id)){
            return RedirectToAction("Index");
        }
        return BadRequest("Error");
    }


    
}