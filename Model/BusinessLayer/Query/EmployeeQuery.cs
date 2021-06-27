using Model;
using Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace BusinessLayer.Query
{
    public class EmployeeQuery
    {
        private readonly Context _context;

        public EmployeeQuery(Context context)
        {
            _context = context;
        }

        public IQueryable<Employee> GetAll()
        {
            return _context.Employees.Include(e => e.Formations).Include(e => e.Experiences).Include(e => e.Postulations);
        }

        public Employee GetById(int id)
        {
            return _context.Employees.Find(id);
        }

        public IQueryable<Employee> GetPostulantsOfJobAdvertisement(int jobAdvertisementId)
        {
            return _context.Postulations.Where(p => p.JobAdvertisementId == jobAdvertisementId).Select(p => p.Employee);
        }
    }
}
