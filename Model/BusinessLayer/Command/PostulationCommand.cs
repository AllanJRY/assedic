using Model;
using Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Command
{
    public class PostulationCommand
    {
        private readonly Context _context;

        public PostulationCommand(Context context)
        {
            _context = context;
        }

        public Postulation Add(Postulation postulation)
        {
            _context.Postulations.Add(postulation);
            _context.SaveChanges();
            return postulation;
        }
    }
}
