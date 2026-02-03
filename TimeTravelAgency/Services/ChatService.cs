using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using TimeTravelAgency.Models;

namespace TimeTravelAgency.Services;

public class ChatService
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;
    private readonly string _systemPrompt;

    public ChatService(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _configuration = configuration;
        _systemPrompt = GetSystemPrompt();
    }

    private string GetSystemPrompt()
    {
        return """
            Tu es l'assistant virtuel de TimeTravel Agency, une agence de voyage temporel de luxe.
            Ton rôle : conseiller les clients sur les meilleures destinations temporelles.

            Ton ton :
            - Professionnel mais chaleureux
            - Passionné d'histoire
            - Toujours enthousiaste sans être trop familier
            - Expertise en voyage temporel (fictif mais crédible)

            Tu connais parfaitement nos 3 destinations :

            1. PARIS 1889 (Belle Époque)
            - Prix : 15 900 € pour 5 jours
            - Points forts : Tour Eiffel, Exposition Universelle, Moulin Rouge, cafés littéraires
            - Idéal pour : amateurs de culture, d'élégance, de gastronomie
            
            2. CRÉTACÉ -65 MILLIONS D'ANNÉES
            - Prix : 24 900 € pour 3 jours
            - Points forts : Dinosaures (T-Rex, Tricératops), nature préhistorique, safari sécurisé
            - Idéal pour : aventuriers, amoureux de la nature, passionnés de paléontologie
            
            3. FLORENCE 1504 (Renaissance)
            - Prix : 18 500 € pour 4 jours
            - Points forts : Michel-Ange, David, Léonard de Vinci, Médicis
            - Idéal pour : passionnés d'art, d'architecture, d'histoire de l'art

            Règles importantes :
            - Réponds toujours en français
            - Sois concis mais informatif (2-3 phrases max par réponse)
            - Si on te demande quelque chose hors sujet, ramène poliment la conversation sur les voyages temporels
            - Tu peux suggérer des destinations selon les intérêts exprimés
            - Pour les réservations, invite à utiliser le formulaire de réservation sur le site
            """;
    }

    public async Task<string> GetResponseAsync(List<ChatMessage> conversationHistory)
    {
        var apiKey = _configuration["ChatApi:ApiKey"];
        var apiProvider = _configuration["ChatApi:Provider"] ?? "mistral";
        
        if (string.IsNullOrEmpty(apiKey))
        {
            return GetFallbackResponse(conversationHistory.LastOrDefault()?.Content ?? "");
        }

        try
        {
            return apiProvider.ToLower() switch
            {
                "mistral" => await CallMistralApiAsync(conversationHistory, apiKey),
                "openai" => await CallOpenAIApiAsync(conversationHistory, apiKey),
                "groq" => await CallGroqApiAsync(conversationHistory, apiKey),
                _ => await CallMistralApiAsync(conversationHistory, apiKey)
            };
        }
        catch (Exception ex)
        {
            Console.WriteLine($"API Error: {ex.Message}");
            return GetFallbackResponse(conversationHistory.LastOrDefault()?.Content ?? "");
        }
    }

    private async Task<string> CallMistralApiAsync(List<ChatMessage> history, string apiKey)
    {
        _httpClient.DefaultRequestHeaders.Clear();
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

        var messages = new List<object>
        {
            new { role = "system", content = _systemPrompt }
        };
        
        messages.AddRange(history.Select(m => new { role = m.Role, content = m.Content }));

        var requestBody = new
        {
            model = "mistral-small-latest",
            messages = messages
        };

        var content = new StringContent(JsonSerializer.Serialize(requestBody), Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync("https://api.mistral.ai/v1/chat/completions", content);
        
        response.EnsureSuccessStatusCode();
        
        var responseJson = await response.Content.ReadAsStringAsync();
        using var doc = JsonDocument.Parse(responseJson);
        return doc.RootElement.GetProperty("choices")[0].GetProperty("message").GetProperty("content").GetString() ?? "Désolé, je n'ai pas pu générer de réponse.";
    }

    private async Task<string> CallOpenAIApiAsync(List<ChatMessage> history, string apiKey)
    {
        _httpClient.DefaultRequestHeaders.Clear();
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

        var messages = new List<object>
        {
            new { role = "system", content = _systemPrompt }
        };
        
        messages.AddRange(history.Select(m => new { role = m.Role, content = m.Content }));

        var requestBody = new
        {
            model = "gpt-3.5-turbo",
            messages = messages
        };

        var content = new StringContent(JsonSerializer.Serialize(requestBody), Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync("https://api.openai.com/v1/chat/completions", content);
        
        response.EnsureSuccessStatusCode();
        
        var responseJson = await response.Content.ReadAsStringAsync();
        using var doc = JsonDocument.Parse(responseJson);
        return doc.RootElement.GetProperty("choices")[0].GetProperty("message").GetProperty("content").GetString() ?? "Désolé, je n'ai pas pu générer de réponse.";
    }

    private async Task<string> CallGroqApiAsync(List<ChatMessage> history, string apiKey)
    {
        _httpClient.DefaultRequestHeaders.Clear();
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

        var messages = new List<object>
        {
            new { role = "system", content = _systemPrompt }
        };
        
        messages.AddRange(history.Select(m => new { role = m.Role, content = m.Content }));

        var requestBody = new
        {
            model = "mixtral-8x7b-32768",
            messages = messages
        };

        var content = new StringContent(JsonSerializer.Serialize(requestBody), Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync("https://api.groq.com/openai/v1/chat/completions", content);
        
        response.EnsureSuccessStatusCode();
        
        var responseJson = await response.Content.ReadAsStringAsync();
        using var doc = JsonDocument.Parse(responseJson);
        return doc.RootElement.GetProperty("choices")[0].GetProperty("message").GetProperty("content").GetString() ?? "Désolé, je n'ai pas pu générer de réponse.";
    }

    private string GetFallbackResponse(string userMessage)
    {
        var message = userMessage.ToLower();
        
        if (message.Contains("bonjour") || message.Contains("salut") || message.Contains("hello"))
            return "Bonjour et bienvenue chez TimeTravel Agency ! Je suis votre assistant virtuel. Comment puis-je vous aider à planifier votre voyage temporel ?";
        
        if (message.Contains("paris") || message.Contains("1889") || message.Contains("tour eiffel"))
            return "Paris 1889 est une destination exceptionnelle ! Vivez la Belle Époque, admirez la Tour Eiffel fraîchement construite et plongez dans l'Exposition Universelle. 5 jours à partir de 15 900 €.";
        
        if (message.Contains("dinosaure") || message.Contains("crétacé") || message.Contains("préhistoire") || message.Contains("t-rex"))
            return "Le Crétacé est notre aventure la plus spectaculaire ! Observez les dinosaures dans leur habitat naturel depuis notre base sécurisée. 3 jours d'aventure à 24 900 €.";
        
        if (message.Contains("florence") || message.Contains("renaissance") || message.Contains("michel-ange") || message.Contains("1504"))
            return "Florence 1504, le cœur de la Renaissance ! Rencontrez Michel-Ange, admirez le David original et découvrez les secrets des Médicis. 4 jours à 18 500 €.";
        
        if (message.Contains("prix") || message.Contains("coût") || message.Contains("tarif") || message.Contains("combien"))
            return "Nos tarifs : Paris 1889 (15 900 €/5j), Crétacé (24 900 €/3j), Florence 1504 (18 500 €/4j). Tous nos voyages incluent le transport temporel, l'hébergement de luxe et un guide expert.";
        
        if (message.Contains("réserv") || message.Contains("book"))
            return "Pour réserver, utilisez notre formulaire de réservation en ligne. Vous pouvez aussi me poser des questions sur les destinations pour faire votre choix !";
        
        if (message.Contains("sécur") || message.Contains("danger") || message.Contains("risque"))
            return "La sécurité est notre priorité absolue. Nos voyages sont encadrés par des experts et nous utilisons une technologie de pointe. Chaque destination dispose de protocoles de sécurité adaptés.";
        
        return "Je suis là pour vous conseiller sur nos destinations temporelles : Paris 1889, le Crétacé ou Florence 1504. Quelle époque vous attire le plus ?";
    }
}
