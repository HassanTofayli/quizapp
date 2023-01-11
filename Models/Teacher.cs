using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace quizapp.Models;

public class Teacher
{
    [Key]
    public int TeacherId { get; set; }
    public string teacher_name { get; set; } = null!;
    public string teacher_email { get; set; } = null!;
    public ICollection<ClassRoom> ClassRooms { get; set; } = new List<ClassRoom>();

}