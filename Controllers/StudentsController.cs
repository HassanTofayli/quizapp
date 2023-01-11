using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using quizapp.Models;
using quizapp.Interfaces;

namespace quizapp.Controllers;

public class StudentsController : Controller
{

    private readonly IStudentRepo _repo;


    public StudentsController(IStudentRepo _repo)
    {
        this._repo = _repo;
    }


    [HttpGet]
    public IActionResult AddStudent()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> AddStudent(Student student)
    {
        await _repo.AddStudentAsync(student);
        return View();
    }


    public async Task<IActionResult> Index()
    {
        List<Student> students = await _repo.GetAllStudentAsync();
        return View(students);
    }


    public async Task<IActionResult> ViewStudent(int id)
    {
        var student = await _repo.GetStudentByIdAsync(id);
        if (student!=null)
            return View(student);
        return BadRequest("No Such Student");
    }


    [HttpPost]
    public async Task<IActionResult> RemoveStudent(int id)
    {
        if (await _repo.DeleteStudentAsync(id))
        {
            return Ok();
        }
        return BadRequest("Student Not Deleted");
    }



    public IActionResult aboutUs()
    {
        return View();
    }
}
