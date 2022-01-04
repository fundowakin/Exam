using Exam.Models;
using System.Collections.Generic;

namespace Exam.ViewModels
{
    public class UserTicketsModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        public double Balance { get; set; }

        public List<Ticket> UserTickets { get; set; }
        
    }
}