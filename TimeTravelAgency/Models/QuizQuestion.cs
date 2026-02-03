namespace TimeTravelAgency.Models;

public class QuizQuestion
{
    public int Id { get; set; }
    public string Question { get; set; } = string.Empty;
    public List<QuizOption> Options { get; set; } = new();
}

public class QuizOption
{
    public string Text { get; set; } = string.Empty;
    public string Value { get; set; } = string.Empty; // Paris, Cretace, Florence
}

public class QuizResult
{
    public Dictionary<string, int> Scores { get; set; } = new()
    {
        { "Paris", 0 },
        { "Cretace", 0 },
        { "Florence", 0 }
    };
    
    public string GetRecommendedDestination()
    {
        return Scores.OrderByDescending(x => x.Value).First().Key;
    }
}
