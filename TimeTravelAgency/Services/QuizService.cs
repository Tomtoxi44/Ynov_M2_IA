using TimeTravelAgency.Models;

namespace TimeTravelAgency.Services;

public class QuizService
{
    private readonly List<QuizQuestion> _questions = new()
    {
        new QuizQuestion
        {
            Id = 1,
            Question = "Quel type d'expérience recherchez-vous ?",
            Options = new List<QuizOption>
            {
                new() { Text = "Culturelle et artistique", Value = "Florence" },
                new() { Text = "Aventure et nature", Value = "Cretace" },
                new() { Text = "Élégance et raffinement", Value = "Paris" }
            }
        },
        new QuizQuestion
        {
            Id = 2,
            Question = "Quelle période historique vous fascine le plus ?",
            Options = new List<QuizOption>
            {
                new() { Text = "Histoire moderne (XIXe-XXe siècle)", Value = "Paris" },
                new() { Text = "Temps anciens et origines", Value = "Cretace" },
                new() { Text = "Renaissance et classicisme", Value = "Florence" }
            }
        },
        new QuizQuestion
        {
            Id = 3,
            Question = "Vous préférez :",
            Options = new List<QuizOption>
            {
                new() { Text = "L'effervescence urbaine", Value = "Paris" },
                new() { Text = "La nature sauvage", Value = "Cretace" },
                new() { Text = "L'art et l'architecture", Value = "Florence" }
            }
        },
        new QuizQuestion
        {
            Id = 4,
            Question = "Votre activité idéale en voyage :",
            Options = new List<QuizOption>
            {
                new() { Text = "Visiter des monuments emblématiques", Value = "Paris" },
                new() { Text = "Observer la faune exceptionnelle", Value = "Cretace" },
                new() { Text = "Explorer des musées et ateliers", Value = "Florence" }
            }
        }
    };

    public List<QuizQuestion> GetQuestions() => _questions;

    public string GetRecommendation(Dictionary<int, string> answers)
    {
        var scores = new Dictionary<string, int>
        {
            { "Paris", 0 },
            { "Cretace", 0 },
            { "Florence", 0 }
        };

        foreach (var answer in answers.Values)
        {
            if (scores.ContainsKey(answer))
            {
                scores[answer]++;
            }
        }

        return scores.OrderByDescending(x => x.Value).First().Key;
    }

    public string GetRecommendationText(string destination)
    {
        return destination switch
        {
            "Paris" => "Vous êtes un amateur de culture et d'élégance ! Paris 1889 est fait pour vous. Vivez la Belle Époque, admirez la Tour Eiffel fraîchement construite et plongez dans l'effervescence de l'Exposition Universelle.",
            "Cretace" => "L'aventure coule dans vos veines ! Le Crétacé vous attend pour une expérience unique. Observez les dinosaures dans leur habitat naturel et découvrez un monde préservé de toute influence humaine.",
            "Florence" => "Vous êtes un passionné d'art et de beauté ! Florence 1504 est votre destination idéale. Rencontrez Michel-Ange, Léonard de Vinci et vivez la Renaissance italienne de l'intérieur.",
            _ => "Nous avons la destination parfaite pour vous !"
        };
    }
}
