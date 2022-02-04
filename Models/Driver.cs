using System;

using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
namespace API.Models
{
    public class Driver
    {
        [Key]
        public int Id { get; set; }
        
        public string Name {get; set;}

        public string Truck {get; set;}

        public string Address {get; set;}
         public virtual ICollection<Trip> Trip {get; set;}
    }
}