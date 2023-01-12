using System.ComponentModel.DataAnnotations;

namespace quizapp.Models;

public class Question
{
    [Key]
    public int QuestionId { get; set; }
    public string? Mcq { get; set; }
    public string? OpenQuestion { get; set; }
}