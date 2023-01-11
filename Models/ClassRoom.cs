using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace quizapp.Models;

public class ClassRoom {
    [Key]
    public int ClassRoomId { get; set; }
    public string teacher_name { get; set; } = null!;
    public string course_name { get; set; } = null!;
    public int TeacherId { get; set; }
    public Teacher Teacher { get; set; } = null!;
    public ICollection<StudentClassroom> Classrooms { get; set; } = new List<StudentClassroom>();

}