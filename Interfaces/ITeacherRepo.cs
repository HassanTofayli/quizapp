namespace quizapp.Interfaces;
using quizapp.Models;

public interface ITeacherRepo
{
    Task<List<Teacher>> GetAllTeachersAsync();
    Task<Teacher?> GetTeacherByIdAsync(int id);
    Task<bool> AddTeacherAsync(Teacher newTeacher);
    Task<bool> DeleteTeacherAsync(int id);
    Task<bool> UpdateTeacherAsync(Teacher updatedTeacher);
}