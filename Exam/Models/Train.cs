using System.Collections.Generic;

namespace Exam.Models
{
    public class Train
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public ICollection<Place> Places { get; set; }
    }
}
