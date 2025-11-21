using System;
using System.ComponentModel.DataAnnotations;

namespace AM.Core.Domain
{
    public class Plane
    {
        [Key]
        public int PlaneID { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Capacity must be a positive number.")]
        public int Capacity { get; set; }

        public DateTime ManufactureDate { get; set; }
        public PlaneType PlaneType { get; set; }

        // Virtual for lazy loading
        public virtual IList<Flight> Flights { get; set; }
    }
}
