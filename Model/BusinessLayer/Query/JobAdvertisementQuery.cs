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
    public class JobAdvertisementQuery
    {
        private readonly Context _context;

        public JobAdvertisementQuery(Context context)
        {
            _context = context;
        }

        public IQueryable<JobAdvertisement> GetAll()
        {
            return _context.JobAdvertisements.Include(j => j.Status);
        }

        public JobAdvertisement GetById(int id)
        {
            return _context.JobAdvertisements.Find(id);
        }

        public IQueryable<JobAdvertisement> GetAllWithStatus(Status status)
        {
            return _context.JobAdvertisements.Where(j => j.Status.Id == status.Id).Include(j => j.Status);
        }

        public IQueryable<JobAdvertisement> findContainingInTitleAndDesc(string query)
        {
            return _context.JobAdvertisements.Where( j =>
                    j.Title.ToLower().Contains(query.ToLower())
                    ||
                    j.Description.ToLower().Contains(query.ToLower())
                ).Include(j => j.Status);
        }

    }
}
