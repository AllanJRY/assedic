using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication.Models
{
    public class JobAdvertisementViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
        
        public float Salary { get; set; }

        public DateTime? Date { get; set; }
        
        public int StatusId { get; set; }

        public StatusViewModel Status { get; set; }
        public string Manager { get; set; }

        #region view_specific_fields
        public SelectList AppStatusList { get; set; }
        
        
        #endregion

    }
}