using System;
using System.ComponentModel.DataAnnotations;

namespace AM.Core.Domain
{
    public class Staff : Passenger
    {
        [DataType(DataType.Currency, ErrorMessage="cuurency invalid")]
        public int Salary { get; set; }

        public string Function { get; set; }
        public DateTime EmploymentDate { get; set; }
    }
}
