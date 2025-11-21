using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AM.Core.Domain
{
    public class Passenger
    {
        [Key]
        [StringLength(7, MinimumLength = 7, ErrorMessage = "Passport number must have exactly 7 characters.")]
        public string PassportNumber { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "First name must have at least 3 characters.")]
        [MaxLength(25, ErrorMessage = "First name cannot exceed 25 characters.")]
        public string FirstName { get; set; }

        [MaxLength(25)]
        public string LastName { get; set; }

        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string EmailAdress { get; set; }

        [RegularExpression(@"^[0-9]{8}$", ErrorMessage = "Phone number must contain exactly 8 digits.")]
        public string TelNumber { get; set; }

        // Navigation properties
        public virtual IList<Flight> Flights { get; set; }
        public virtual IList<Reservation> Reservations { get; set; }
    }
}
