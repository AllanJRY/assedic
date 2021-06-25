using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entity
{
    class Employee
    {
        public int Id { get; set; }

        public string Lastname { get; set; }

        public string Firstname { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Biography { get; set; }

        public int Seniority { get; set; }

        public ICollection<Formation> Formations { get; set; }

        public ICollection<Experience> Experiences { get; set; }
        
        public ICollection<Postulation> Postulations { get; set; }
    }
}
