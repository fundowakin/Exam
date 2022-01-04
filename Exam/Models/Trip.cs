using System;
using System.Collections.Generic;
namespace Exam.Models
{
    public class Trip
    {
        public int ID { get; set; }

        public string CityOfDeparture { get; set; }

        public string CityOfArrival { get; set; }

        public DateTime DateOfDeparture { get; set; }

        public DateTime DateOfArrival { get; set; }

        public ICollection<Ticket> Ticketes { get; set; }
    }
}
