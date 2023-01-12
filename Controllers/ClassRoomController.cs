using quizapp.Interfaces;
using quizapp.Models;

namespace quizapp.Controllers;

using Microsoft.AspNetCore.Mvc;
using quizapp.Interfaces;
using quizapp.Models;


public class ClassRoomController : Controller
{
    private readonly IClassRoomRepo _repo;

    public ClassRoomController(IClassRoomRepo repo){
        this._repo = repo;
    }

    public async Task<IActionResult> GetClassRooms(){
        List<ClassRoom> quizzes = await _repo.GetAllClassRoomsAsync();
        return View(quizzes);
    }

    [HttpPost]
    public async Task<IActionResult> AddClassRoom(ClassRoom classRoom)
    {
        if(await _repo.AddClassRoomAsync(classRoom)){
            return RedirectToAction("GetClassRooms");
        }
        return BadRequest("ERROR");
    }

    [HttpGet]
    public IActionResult AddClassRoom()
    {
        return View();
    }

    
    [HttpPost]
    public async Task<IActionResult> DeleteClassRoom(int id)
    {
        if (await _repo.DeleteClassRoomAsync(id)){
            return RedirectToAction("GetClassRooms");
        }
        return BadRequest("Error");
    }

    [HttpGet]
    public IActionResult CreateQuiz()
    {
        return View();
    }

    public IActionResult AttendQuiz()
    {
        return View();
    }

    
}