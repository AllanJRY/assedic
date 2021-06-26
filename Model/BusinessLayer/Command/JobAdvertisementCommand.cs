using Model;
using Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Command
{
    public class JobAdvertisementCommand
    {
        private readonly Context _context;

        public JobAdvertisementCommand(Context context)
        {
            _context = context;
        }

        public int Add(JobAdvertisement jobAdvertisement)
        {
            _context.JobAdvertisements.Add(jobAdvertisement);
            _context.SaveChanges();
            return jobAdvertisement.Id;
        }

        public void Update(JobAdvertisement newJobAdvertisementData)
        {
            JobAdvertisement jobAdvertisementToUpdate = _context.JobAdvertisements.Find(newJobAdvertisementData.Id);
            if(jobAdvertisementToUpdate != null) {
                jobAdvertisementToUpdate.Title = newJobAdvertisementData.Title;
                jobAdvertisementToUpdate.Description = newJobAdvertisementData.Description;
                jobAdvertisementToUpdate.Salary = newJobAdvertisementData.Salary;
                jobAdvertisementToUpdate.Date = newJobAdvertisementData.Date;
                jobAdvertisementToUpdate.Manager = newJobAdvertisementData.Manager;
                jobAdvertisementToUpdate.Date = newJobAdvertisementData.Date;
            }

            _context.SaveChanges();
        }

        public void Delete(int jobAdvertisementId)
        {
            JobAdvertisement jobAdvertisement = _context.JobAdvertisements.Find(jobAdvertisementId);
            if(jobAdvertisement != null)
            {
                _context.JobAdvertisements.Remove(jobAdvertisement);
            }

            _context.SaveChanges();
        }
    }
}
