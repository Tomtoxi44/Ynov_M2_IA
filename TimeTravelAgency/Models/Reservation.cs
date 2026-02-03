using System.ComponentModel.DataAnnotations;

namespace TimeTravelAgency.Models;

public class Reservation
{
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Le nom est requis")]
    [StringLength(100, ErrorMessage = "Le nom ne peut pas dépasser 100 caractères")]
    public string FullName { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "L'email est requis")]
    [EmailAddress(ErrorMessage = "Format d'email invalide")]
    public string Email { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Le téléphone est requis")]
    [Phone(ErrorMessage = "Format de téléphone invalide")]
    public string Phone { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Veuillez sélectionner une destination")]
    public int DestinationId { get; set; }
    
    [Required(ErrorMessage = "La date de départ est requise")]
    public DateTime DepartureDate { get; set; } = DateTime.Now.AddDays(7);
    
    [Required(ErrorMessage = "Le nombre de voyageurs est requis")]
    [Range(1, 10, ErrorMessage = "Le nombre de voyageurs doit être entre 1 et 10")]
    public int NumberOfTravelers { get; set; } = 1;
    
    public string SpecialRequests { get; set; } = string.Empty;
    
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    
    public ReservationStatus Status { get; set; } = ReservationStatus.Pending;
}

public enum ReservationStatus
{
    Pending,
    Confirmed,
    Cancelled
}
