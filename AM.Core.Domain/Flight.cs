using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AM.Core.Domain
{
    public class Flight
    {
        public int FlightId { get; set; }
        public string Destination { get; set; }
        public string Departure { get; set; }
        public DateTime FlightDate { get; set; }
        public DateTime EffectiveArrival { get; set; }
        public int EstimateDuration { get; set; }
        public string Comments { get; set; }

        [ForeignKey("MyPlane")]
        public int PlaneId { get; set; }

        // Navigation properties with virtual for lazy loading
        public virtual Plane MyPlane { get; set; }
        public virtual IList<Passenger> Passengers { get; set; }
        public virtual IList<Reservation> Reservations { get; set; }
    }
}
