namespace quizapp.Repos;

using System.Collections.Generic;
using System.Threading.Tasks;
using quizapp.Interfaces;
using quizapp.Models;
using quizapp.Data;
using Microsoft.EntityFrameworkCore;

public class TeacherRepo : ITeacherRepo
{

    private readonly AppDbContext _db;

    public TeacherRepo(AppDbContext db)
    {
        this._db=db;
    }

    public async Task<List<Teacher>> GetAllTeachersAsync()
    {
        var Teachers = await _db.Teachers.ToListAsync<Teacher>();

        if (Teachers == null)
            return new List<Teacher>();
        return Teachers;
    }

    public async Task<Teacher?> GetTeacherByIdAsync(int id)
    {
        var Teacher = await _db.Teachers.FindAsync(id);
        return Teacher;
    }

    public async Task<bool> AddTeacherAsync(Teacher newTeacher)
    {
        _db.Teachers.Add(newTeacher);
        return await _db.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteTeacherAsync(int id)
    {
        var TeacherToBeDeleted = await GetTeacherByIdAsync(id);
        if (TeacherToBeDeleted == null) return false;

        _db.Teachers.Remove(TeacherToBeDeleted); // in memory operation
        var success = await _db.SaveChangesAsync() > 0; // this actualy writes it to the database
        return success;
    }

    public async Task<bool> UpdateTeacherAsync(Teacher updatedTeacher)
    {
        var TeacherToBeUpdated = await GetTeacherByIdAsync(updatedTeacher.TeacherId);
        if (TeacherToBeUpdated == null) return false;

        TeacherToBeUpdated.teacher_name = updatedTeacher.teacher_name;
        TeacherToBeUpdated.teacher_email = updatedTeacher.teacher_email;
        TeacherToBeUpdated.ClassRooms = updatedTeacher.ClassRooms;

        _db.Teachers.Update(TeacherToBeUpdated); // in memory operation
        var success = await _db.SaveChangesAsync() > 0; // this actualy writes it to the database
        return success;
    }
}