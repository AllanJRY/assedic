using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entity
{
    public class Status
    {
        public int Id { get; set; }
        public string Label { get; set; }
        public ICollection<JobAdvertisement> JobAdvertisements { get; set; }
    }
}
