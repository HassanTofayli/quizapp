namespace quizapp.Repos;

using System.Collections.Generic;
using System.Threading.Tasks;
using quizapp.Interfaces;
using quizapp.Models;
using quizapp.Data;
using Microsoft.EntityFrameworkCore;

public class StudentRepo : IStudentRepo
{

    private readonly AppDbContext _db;

    public StudentRepo(AppDbContext db)
    {
        this._db=db;
    }

    public async Task<List<Student>> GetAllStudentAsync()
    {
        var students = await _db.Students.ToListAsync<Student>();

        if (students == null)
            return new List<Student>();
        return students;
    }

    public async Task<Student?> GetStudentByIdAsync(int id)
    {
        var student = await _db.Students.FindAsync(id);
        return student;
    }

    public async Task<bool> AddStudentAsync(Student newStudent)
    {
        _db.Students.Add(newStudent);
        return await _db.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteStudentAsync(int id)
    {
        var studentToBeDeleted = await GetStudentByIdAsync(id);
        if (studentToBeDeleted == null) return false;

        _db.Students.Remove(studentToBeDeleted); // in memory operation
        var success = await _db.SaveChangesAsync() > 0; // this actualy writes it to the database
        return success;
    }

    public async Task<bool> UpdatStudentAsync(Student updatedStudent)
    {
        var studentToBeUpdated = await GetStudentByIdAsync(updatedStudent.StudentId);
        if (studentToBeUpdated == null) return false;

        studentToBeUpdated.student_name = updatedStudent.student_name;
        studentToBeUpdated.student_email = updatedStudent.student_email;
        studentToBeUpdated.Classrooms = updatedStudent.Classrooms;

        _db.Students.Update(studentToBeUpdated); // in memory operation
        var success = await _db.SaveChangesAsync() > 0; // this actualy writes it to the database
        return success;
    }
}