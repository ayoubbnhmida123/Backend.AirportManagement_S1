using System;

namespace AM.Core.Domain
{
    public class Reservation
    {
        public int ReservationId { get; set; }
        public DateTime ReservationDate { get; set; }
        public string SeatNumber { get; set; }
        public decimal Price { get; set; }
        public bool IsConfirmed { get; set; }

        public string PassportNumber { get; set; }
        public int FlightId { get; set; }

        public Passenger Passenger { get; set; }
        public Flight Flight { get; set; }
    }
}