using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace quizapp.Models;

public class Quiz
{
    [Key]
    public int QuizId { get; set; }

    public string Title { get; set; } = null!;
    
    public int ClassRoomId { get; set; }
    public ClassRoom ClassRoom { get; set; } = null!;

    public List<Question> Questions { get; set; } = null!;
}