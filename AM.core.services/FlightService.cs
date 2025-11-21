

using AM.Core.Domain;
using System.Collections.Generic;

namespace AM.core.services

{
    public class FlightService : IFlightService
    {
        public IList<Flight> Flights { get; set; }

        public IList<DateTime> GetFlightDates(string destination)
        {

            IList<DateTime> times = new List<DateTime>();
            /*

                        for (int i = 0; i < Flights.Count; i++)
                        {
                            if (Flights[i].Destination == destination)
                            {
                                times.Add(Flights[i].FlightDate);
                            }

                        }
            */
            foreach (Flight flight in Flights)
            {

                if (flight.Destination == destination)
                {
                    times.Add(flight.FlightDate);
                }

            }


            return times;
        }

        public IList<DateTime> GetFlightDatesIMQ(string destination)
        {
            IEnumerable<DateTime> times = from flight in Flights
                                          where flight.Destination == destination
                                          select flight.FlightDate;

            return times.ToList();


        }



        public void ShowFlightDetails(Plane avion)
        {
            var f = from flight in Flights
                    where flight.MyPlane.PlaneID == avion.PlaneID
                    select new { flight.Destination, flight.FlightDate };


            foreach (var obj in f)
            {
                Console.WriteLine(obj.FlightDate + ":" + obj.Destination);
            }

            /*
             Flights.where(f => f.MyPlane.PlaneId == plane.PlaneID
            .select ( f=> new {f.FlighDate, f.Destination};
             */

        }

        public int GetWeeklyFlightNumber(DateTime dateTime)
        {
            var count =
                Flights.Count(
                    flight =>
                flight.FlightDate >= dateTime && flight.FlightDate < dateTime.AddDays(7));

            return count;
        }

       
        //10
        public IList<Flight> SortFlights()
        {
           
            //return Flights.OrderByDescending(f => f.EstimateDuration).ToList();

            
             return ( from Flight in Flights
            orderby Flight.EstimateDuration descending
            select Flight ).ToList();
             


        }
        //11
        public IList<Passenger> GetThreeOlderTravellers(Flight flight)
        {
            

            return (from p in flight.Passengers
                orderby p.BirthDate
                    select p).Take(3).ToList();
         
        }
        //12
        public void ShowGroupedFlights()
        {
            IEnumerable<    IGrouping<string, Flight >     > groups =
                          from f in Flights
                          group f by f.Destination;
            foreach (var group in groups)
            {
                Console.WriteLine(group.Key);
                foreach(var f in group)
                {
                    Console.WriteLine(f);
                }
            }
                  
            



        }
          // 9
        

        double IFlightService.GetDurationAverage(string destination)
        {
            return (from f in Flights
                   where f.Destination == destination  
                   select f.EstimateDuration).Average();

        }

        public int GetDailyFlight()
        {
            DateTime aujourdHui = DateTime.Now;
            DateTime demain = aujourdHui.AddDays(1);


            return Flights.Count(f => f.FlightDate >= aujourdHui && f.FlightDate < demain);

        }

        public void GetLongFlight()
        {
            var f = from flight in Flights
                    where flight.EstimateDuration > 120
                    select new { flight.Destination, flight.EstimateDuration };


            foreach (var obj in f)
            {
                Console.WriteLine(obj.Destination + ":" + obj.EstimateDuration);
            }

        }

        public int GetLatePlane()
        {
            return (from f in Flights
                    where f.EffectiveArrival > f.FlightDate.AddMinutes(f.EstimateDuration)
                    select f).Count();

        }

        public IList<Plane> GetUnusedPlans()
        {
            throw new NotImplementedException();
        }
    }
}
