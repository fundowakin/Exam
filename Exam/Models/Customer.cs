using System.Collections.Generic;

namespace Exam.Models
{
    public class Customer
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }


        public double Balance { get; set; }

        public ICollection<Ticket> Ticketes { get; set; }
    }
}