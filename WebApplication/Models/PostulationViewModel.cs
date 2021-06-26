using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class PostulationViewModel
    {
        public int JobAdvertisementId { get; set; }

        public JobAdvertisementViewModel JobAdvertisement { get; set; }

        public int EmployeeId { get; set; }

        public DateTime Date { get; set; }

        public string Status { get; set; }

        //public SelectList Employees { get; set; }
    }
}