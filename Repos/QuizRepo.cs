using Microsoft.EntityFrameworkCore;
using quizapp.Data;
using quizapp.Interfaces;
using quizapp.Models;

namespace quizapp.Repos;

public class QuizRepo : IQuizRepo
{
    
    private readonly AppDbContext _db;

    public QuizRepo(AppDbContext db)
    {
        this._db=db;
    }
    public async Task<List<Quiz>> GetAllQuizzesAsync()
    {
        var Quizzes = await _db.Quizzes.ToListAsync<Quiz>();

        if (Quizzes == null)
            return new List<Quiz>();
        return Quizzes;
    }

    public async Task<Quiz?> GetQuizByIdAsync(int id)
    {
        var Quizzes = await _db.Quizzes.FindAsync(id);
                return Quizzes;
    }

    public async Task<bool> AddQuizAsync(Quiz newQuiz)
    {
        _db.Quizzes.Add(newQuiz);
        return await _db.SaveChangesAsync() > 0;
        
    }

    public async Task<bool> DeleteQuizAsync(int id)
    {
        var QuizToBeDeleted = await GetQuizByIdAsync(id);
        if (QuizToBeDeleted == null) return false;

        _db.Quizzes.Remove(QuizToBeDeleted); // in memory operation
        var success = await _db.SaveChangesAsync() > 0; // this actualy writes it to the database
        return success;
    }

    public async Task<bool> UpdateQuizAsync(Quiz updatedQuiz)
    {
        var QuizToBeUpdated = await GetQuizByIdAsync(updatedQuiz.QuizId);
        if (QuizToBeUpdated == null) return false;

        QuizToBeUpdated.QuizId = updatedQuiz.QuizId;
        QuizToBeUpdated.Questions = updatedQuiz.Questions;
        QuizToBeUpdated.Title = updatedQuiz.Title;

        _db.Quizzes.Update(QuizToBeUpdated); // in memory operation
        var success = await _db.SaveChangesAsync() > 0; // this actualy writes it to the database
        return success;
    }

}