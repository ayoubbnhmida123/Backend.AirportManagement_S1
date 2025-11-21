using System;
using System.Collections.Generic;
using AM.Core.Domain;
using AM.Data;

namespace AM.UI.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Ajout d’un nouveau Staff et Traveller ===");

            using (var context = new AMContext())
            {
                // ✅ Création d’un nouvel avion (Plane)
                var plane = new Plane
                {
                    Capacity = 200,
                    ManufactureDate = new DateTime(2020, 3, 15),
                    PlaneType = PlaneType.BOEING
                };

                // ✅ Création d’un nouveau Traveller
                var traveller = new Traveller
                {
                    FirstName = "louay",
                    LastName = "amari",
                    PassportNumber = "4123456",
                    EmailAdress = "sara.benali@email.com",
                    TelNumber = "55223344",
                    BirthDate = new DateTime(1997, 8, 10),
                    Nationality = "Tunisian",
                    HealthInformation = "Healthy"
                };

                // ✅ Création d’un nouveau Staff
                var staff = new Staff
                {
                    FirstName = "louay",
                    LastName = "louay",
                    PassportNumber = "S996877",
                    EmailAdress = "ahmed.mansour@email.com",
                    TelNumber = "55889900",
                    BirthDate = new DateTime(1982, 1, 5),
                    Salary = 4200,
                    Function = "Pilot",
                    EmploymentDate = new DateTime(2010, 6, 15)
                };

                // ✅ Création d’un vol associé à l’avion et au traveller
                var flight = new Flight
                {
                    Departure = "Tunis",
                    Destination = "Paris",
                    FlightDate = new DateTime(2025, 11, 20, 8, 30, 0),
                    EffectiveArrival = new DateTime(2025, 11, 20, 11, 30, 0),
                    EstimateDuration = 180,
                    Comments = "Morning flight",
                    MyPlane = plane,
                    Passengers = new List<Passenger> { traveller, staff }  // <- les deux types dérivés
                };

                // ✅ Ajout des entités au contexte
                context.Planes.Add(plane);
                context.Flights.Add(flight);
                context.Passengers.Add(traveller);
                context.Passengers.Add(staff);
                var reservation = new Reservation
                {
                    ReservationDate = DateTime.Now,
                    SeatNumber = "12A",
                    Price = 350.50m,
                    IsConfirmed = true,
                    PassportNumber = traveller.PassportNumber,
                    FlightId = flight.FlightId
                };

                context.Reservations.Add(reservation);
                int resResult = context.SaveChanges();

                try
                {
                    // ✅ Sauvegarde en base
                    int result = context.SaveChanges();
                    Console.WriteLine($"\n✅ Enregistrements ajoutés avec succès ! ({result} lignes affectées)");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("\n❌ Erreur lors de l’enregistrement :");
                    Console.WriteLine(ex.ToString());
                }

                
               
            }

            Console.WriteLine("\nFin du programme...");
            Console.ReadKey();
        }
    }
}
