namespace Exam.Models
{
    public class Place
    {
        public int ID { get; set; }

        public bool Type { get; set; }

        public int Number { get; set; }

        public string Status { get; set; }

        public int TrainID { get; set; }

        public Train Train { get; set; }

        public Ticket Ticket { get; set; }
    }
}
