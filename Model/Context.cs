using Model.Configurations;
using Model.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Context : DbContext
    {
        public Context() : base("name=cs_test")
        {
            Database.SetInitializer<Context>(new DropCreateDatabaseIfModelChanges<Context>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema("dbo");

            modelBuilder.Configurations.Add(new JobAdvertisementFluent());
            modelBuilder.Configurations.Add(new EmployeeFluent());
            modelBuilder.Configurations.Add(new ExperienceFluent());
            modelBuilder.Configurations.Add(new FormationFluent());
            modelBuilder.Configurations.Add(new PostulationFluent());
            modelBuilder.Configurations.Add(new StatusFluent());
        }

        public IDbSet<JobAdvertisement> JobAdvertisements { get; set; }

        public IDbSet<Employee> Employees { get; set; }
        
        public IDbSet<Experience> Experiences { get; set; }
        
        public IDbSet<Formation> Formations { get; set; }

        public IDbSet<Postulation> Postulations { get; set; }

        public IDbSet<Status> Status { get; set; }

    }
}
