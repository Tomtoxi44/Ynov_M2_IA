using TimeTravelAgency.Models;

namespace TimeTravelAgency.Services;

public class ReservationService
{
    private readonly List<Reservation> _reservations = new();
    private int _nextId = 1;

    public Task<bool> CreateReservationAsync(Reservation reservation)
    {
        reservation.Id = _nextId++;
        reservation.CreatedAt = DateTime.Now;
        reservation.Status = ReservationStatus.Pending;
        _reservations.Add(reservation);
        return Task.FromResult(true);
    }

    public Task<List<Reservation>> GetAllReservationsAsync()
    {
        return Task.FromResult(_reservations.ToList());
    }

    public Task<Reservation?> GetReservationByIdAsync(int id)
    {
        return Task.FromResult(_reservations.FirstOrDefault(r => r.Id == id));
    }
}
