using Model.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Configurations
{
    class PostulationFluent : EntityTypeConfiguration<Postulation>
    {
        public PostulationFluent()
        {
            ToTable("APP_POSTULATION");
            HasKey(p => new { p.JobAdvertisementId, p.EmployeeId });

            Property(p => p.EmployeeId).HasColumnName("EMP_ID").IsRequired();
            Property(p => p.JobAdvertisementId).HasColumnName("JOB_ADV_ID").IsRequired();
            Property(p => p.Date).HasColumnName("POS_DATE").IsRequired();
            Property(p => p.Status).HasColumnName("POS_STATUS").IsRequired();
        }
    }
}
