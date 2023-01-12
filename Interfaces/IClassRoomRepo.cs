using quizapp.Models;

namespace quizapp.Interfaces;

public interface IClassRoomRepo
{
    Task<List<ClassRoom>> GetAllClassRoomsAsync();
    Task<ClassRoom?> GetClassRoomByIdAsync(int id);
    Task<bool> AddClassRoomAsync(ClassRoom newClassRoom);
    Task<bool> DeleteClassRoomAsync(int id);
    Task<bool> UpdateClassRoomAsync(ClassRoom updatedClassRoom);
}