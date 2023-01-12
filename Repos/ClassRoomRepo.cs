using Microsoft.EntityFrameworkCore;
using quizapp.Data;
using quizapp.Interfaces;
using quizapp.Models;

namespace quizapp.Repos;

public class ClassRoomRepo : IClassRoomRepo
{
    
    private readonly AppDbContext _db;

    public ClassRoomRepo(AppDbContext db)
    {
        this._db=db;
    }
    
    
    
    public async Task<List<ClassRoom>> GetAllClassRoomsAsync()
    {
        var classRooms = await _db.ClassRooms.ToListAsync<ClassRoom>();

        if (classRooms == null)
            return new List<ClassRoom>();
        return classRooms;    }

    public async Task<ClassRoom?> GetClassRoomByIdAsync(int id)
    {
        var classRooms = await _db.ClassRooms.FindAsync(id);
        return classRooms;    }

    public async Task<bool> AddClassRoomAsync(ClassRoom newClassRoom)
    {
        _db.ClassRooms.Add(newClassRoom);
        return await _db.SaveChangesAsync() > 0;
        
    }

    public async Task<bool> DeleteClassRoomAsync(int id)
    {
        var ClassRoomToBeDeleted = await GetClassRoomByIdAsync(id);
        if (ClassRoomToBeDeleted == null) return false;

        _db.ClassRooms.Remove(ClassRoomToBeDeleted); // in memory operation
        var success = await _db.SaveChangesAsync() > 0; // this actualy writes it to the database
        return success;
    }

    public async Task<bool> UpdateClassRoomAsync(ClassRoom updatedClassRoom)
    {
        var ClassRoomToBeUpdated = await GetClassRoomByIdAsync(updatedClassRoom.ClassRoomId);
        if (ClassRoomToBeUpdated == null) return false;

        ClassRoomToBeUpdated.ClassRoomId = updatedClassRoom.ClassRoomId;
        ClassRoomToBeUpdated.Quizzes = updatedClassRoom.Quizzes;
        ClassRoomToBeUpdated.Teacher = updatedClassRoom.Teacher;
        ClassRoomToBeUpdated.TeacherId = updatedClassRoom.TeacherId;
        ClassRoomToBeUpdated.course_name = updatedClassRoom.course_name;
        ClassRoomToBeUpdated.teacher_name = updatedClassRoom.teacher_name;
        
        _db.ClassRooms.Update(ClassRoomToBeUpdated); // in memory operation
        var success = await _db.SaveChangesAsync() > 0; // this actualy writes it to the database
        return success;    }
}