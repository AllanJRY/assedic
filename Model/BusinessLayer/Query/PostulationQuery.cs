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
    public class PostulationQuery
    {
        private readonly Context _context;

        public PostulationQuery(Context context)
        {
            _context = context;
        }

        public IQueryable<Postulation> GetAll()
        {
            return _context.Postulations.Include(p => p.Employee).Include(p => p.JobAdvertisement);
        }

        public Postulation GetById(int id)
        {
            return _context.Postulations.Find(id);
        }

        public IQueryable<Postulation> GetByJobAdvertisementAndEmployee(int jobAdvertisementId, int employeeId)
        {
            return _context.Postulations.Where(p => p.JobAdvertisement.Id == jobAdvertisementId && p.Employee.Id == employeeId).Include(p => p.Employee).Include(p => p.JobAdvertisement);
        }

        public IQueryable<Postulation> GetAllOfEmployee(int employeeId)
        {
            return _context.Postulations.Where(p => p.Employee.Id == employeeId).Include(p => p.Employee).Include(p => p.JobAdvertisement);
        }
    }
}
