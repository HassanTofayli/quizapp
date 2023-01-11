using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace quizapp.Models;

public class Student {
    public int StudentId { get; set; }
    public string student_name { get; set; } = null!;
    public string student_email { get; set; } = null!;

    public ICollection<StudentClassroom> Classrooms { get; set; } = new List<StudentClassroom>();

}