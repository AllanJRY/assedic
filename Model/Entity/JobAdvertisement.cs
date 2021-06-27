using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entity
{
    public class JobAdvertisement
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime? Date { get; set; }

        public float Salary { get; set; }

        public string Manager { get; set; }

        public int StatusId { get; set; }

        public Status Status { get; set; }

        public ICollection<Postulation> Postulations { get; set; }
    }
}
