using TimeTravelAgency.Models;

namespace TimeTravelAgency.Services;

public class DestinationService
{
    private readonly List<Destination> _destinations = new()
    {
        new Destination
        {
            Id = 1,
            Name = "Paris 1889",
            Period = "Belle Époque",
            ShortDescription = "Vivez l'effervescence de l'Exposition Universelle et assistez à l'inauguration de la Tour Eiffel.",
            FullDescription = "Plongez au cœur de Paris en 1889, année emblématique de la Belle Époque. Assistez à l'Exposition Universelle qui attira 32 millions de visiteurs et contemplez la Tour Eiffel fraîchement érigée, chef-d'œuvre d'ingénierie de Gustave Eiffel. Déambulez sur les Champs-Élysées illuminés par les premiers lampadaires électriques, goûtez à la gastronomie parisienne dans les cafés littéraires où se croisent artistes et intellectuels.",
            ImageUrl = "/images/paris-1889.jpg",
            Price = 15900,
            Duration = 5,
            Highlights = new List<string>
            {
                "Inauguration de la Tour Eiffel",
                "Exposition Universelle de 1889",
                "Cafés littéraires du Quartier Latin",
                "Montmartre et ses artistes",
                "Bal du Moulin Rouge"
            },
            Includes = new List<string>
            {
                "Transport temporel aller-retour",
                "Hébergement 5 étoiles d'époque",
                "Guide historien personnel",
                "Costumes d'époque fournis",
                "Repas gastronomiques inclus"
            },
            Category = "Culture",
            Rating = 4.9
        },
        new Destination
        {
            Id = 2,
            Name = "Crétacé -65M",
            Period = "Ère Mésozoïque",
            ShortDescription = "Observez les dinosaures dans leur habitat naturel, une aventure préhistorique unique.",
            FullDescription = "Remontez 65 millions d'années dans le passé pour découvrir la Terre à l'ère des dinosaures. Depuis notre base sécurisée, observez les majestueux T-Rex, les paisibles Tricératops et les impressionnants Ptéranodons. Explorez des forêts luxuriantes où la nature règne en maître, sous un ciel d'un bleu pur, avant l'arrivée de l'astéroïde qui changera tout.",
            ImageUrl = "/images/cretace.jpg",
            Price = 24900,
            Duration = 3,
            Highlights = new List<string>
            {
                "Observation de T-Rex en liberté",
                "Safari préhistorique sécurisé",
                "Forêts tropicales primitives",
                "Océans peuplés de créatures marines géantes",
                "Coucher de soleil sur monde vierge"
            },
            Includes = new List<string>
            {
                "Transport temporel haute sécurité",
                "Base camp technologique",
                "Combinaison de protection",
                "Guide paléontologue expert",
                "Équipement d'observation"
            },
            Category = "Adventure",
            Rating = 4.8
        },
        new Destination
        {
            Id = 3,
            Name = "Florence 1504",
            Period = "Renaissance Italienne",
            ShortDescription = "Rencontrez Michel-Ange et découvrez la création du David dans son atelier.",
            FullDescription = "Voyagez au cœur de la Renaissance italienne, à Florence en 1504. Assistez au dévoilement du David de Michel-Ange, chef-d'œuvre absolu de la sculpture. Rencontrez les plus grands artistes de l'histoire : Léonard de Vinci, Raphaël, Botticelli. Déambulez dans les palais des Médicis, mécènes éclairés qui ont fait de Florence le berceau de la Renaissance.",
            ImageUrl = "/images/florence-1504.jpg",
            Price = 18500,
            Duration = 4,
            Highlights = new List<string>
            {
                "Dévoilement du David de Michel-Ange",
                "Atelier de Léonard de Vinci",
                "Palais des Médicis",
                "Galerie des Offices originelle",
                "Cuisine toscane authentique"
            },
            Includes = new List<string>
            {
                "Transport temporel aller-retour",
                "Villa Renaissance privée",
                "Guide historien de l'art",
                "Costumes Renaissance sur mesure",
                "Accès VIP aux ateliers d'artistes"
            },
            Category = "Art",
            Rating = 4.95
        }
    };

    public List<Destination> GetAllDestinations() => _destinations;

    public Destination? GetDestinationById(int id) => _destinations.FirstOrDefault(d => d.Id == id);

    public Destination? GetDestinationByName(string name) => 
        _destinations.FirstOrDefault(d => d.Name.Contains(name, StringComparison.OrdinalIgnoreCase));
}
