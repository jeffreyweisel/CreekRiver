using System.ComponentModel.DataAnnotations;

namespace CreekRiver.Models.DTOs;

public class UserProfileDTO
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    [Required]
    public string Email { get; set; }

    public List<Reservation> Reservations { get; set; }

}