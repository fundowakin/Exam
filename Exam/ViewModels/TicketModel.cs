using Exam.Models;

namespace Exam.ViewModels
{
    public class TicketModel
    {
        public int ID { get; set; }

        public bool Type { get; set; }

        public int Number { get; set; }

        public string Status { get; set; }

        public int TrainID { get; set; }

        public double price { get; set; }
    }
}
