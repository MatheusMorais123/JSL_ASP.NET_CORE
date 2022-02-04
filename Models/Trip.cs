using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
namespace API.Models
{
    public class Trip
    {
        public int Id {get; set;}
        public int DriverId { get; set;}
        public DateTime TripDate {get; set;}
        public string Deliverylocation {get; set;}

        public string ExitLocation {get; set;}

        public string Km {get;set;}
    }
}