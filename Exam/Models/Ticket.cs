using System;

namespace Exam.Models
{
    public class Ticket
    {
        public int ID { get; set; }

        public DateTime DateOfBuying { get; set; }
        
        public double Price { get; set; }

        public int CustomersID { get; set; }

        public Customer Customer { get; set; }

        public int PlaceID { get; set; }

        public Place Place { get; set; }

        public int TripID { get; set; }

        public Trip Trip { get; set; }

    }
}
