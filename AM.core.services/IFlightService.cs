using AM.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.core.services
{
    public interface IFlightService
    {
        IList<DateTime> GetFlightDates(string destination);
        IList<DateTime> GetFlightDatesIMQ(string destination);

        void ShowFlightDetails(Plane avion);

        int GetWeeklyFlightNumber(DateTime dateTime);

        double GetDurationAverage(string destination);

        public IList<Flight> SortFlights();

        public IList<Passenger> GetThreeOlderTravellers(Flight flight);

        public void ShowGroupedFlights();

        int GetDailyFlight();
        public void GetLongFlight();
        int GetLatePlane();
        IList<Plane>  GetUnusedPlans();



    }
}
