namespace TimeTravelAgency.Models;

public class Destination
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Period { get; set; } = string.Empty;
    public string ShortDescription { get; set; } = string.Empty;
    public string FullDescription { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int Duration { get; set; } // en jours
    public List<string> Highlights { get; set; } = new();
    public List<string> Includes { get; set; } = new();
    public string Category { get; set; } = string.Empty; // Culture, Adventure, Art
    public double Rating { get; set; }
}
