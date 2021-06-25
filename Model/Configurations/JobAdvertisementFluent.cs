using Model.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Configurations
{
    class JobAdvertisementFluent : EntityTypeConfiguration<JobAdvertisement>
    {
        public JobAdvertisementFluent()
        {
            ToTable("APP_JOB_ADVERTISEMENT");
            HasKey(j => j.Id);

            Property(j => j.Id).HasColumnName("JOB_ADV_ID").IsRequired();
            Property(j => j.Title).HasColumnName("JOB_ADV_TITLE").IsRequired().HasMaxLength(255);
            Property(j => j.Description).HasColumnName("JOB_ADV_DESCRIPTION");
            Property(j => j.Salary).HasColumnName("JOB_ADV_SALARY");
            Property(j => j.Date).HasColumnName("JOB_ADV_DATE");
            Property(j => j.Manager).HasColumnName("JOB_ADV_MANAGER");
            Property(j => j.StatusId).IsRequired().HasColumnName("STA_ID");

            HasRequired(j => j.Status).WithMany(s => s.JobAdvertisements).HasForeignKey(j => j.StatusId);
            HasMany(j => j.Postulations).WithRequired(p => p.JobAdvertisement).HasForeignKey(p => p.JobAdvertisementId);
        }
    }
}
