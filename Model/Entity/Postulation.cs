using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entity
{
    class Postulation
    {
        public int JobAdvertisementId { get; set; }

        public JobAdvertisement JobAdvertisement { get; set; }

        public int EmployeeId { get; set; }

        public Employee Employee { get; set; }

        public DateTime Date { get; set; }

        public string Status { get; set; }
    }
}
