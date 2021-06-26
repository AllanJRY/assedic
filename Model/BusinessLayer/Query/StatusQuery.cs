using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Model.Entity;

namespace BusinessLayer.Query
{
    public class StatusQuery
    {
        private readonly Context _context;

        public StatusQuery(Context context)
        {
            _context = context;
        }

        public IQueryable<Status> GetAll()
        {
            return _context.Status;
        }

        public Status GetById(int id)
        {
            return _context.Status.Find(id);
        }
    }
}
