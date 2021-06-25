using Model.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Configurations
{
    class ExperienceFluent : EntityTypeConfiguration<Experience>
    {
        public ExperienceFluent()
        {
            ToTable("APP_EXPERIENCE");
            HasKey(e => e.Id);

            Property(e => e.Id).HasColumnName("EXP_ID").IsRequired();
            Property(e => e.Title).HasColumnName("EXP_TITLE").IsRequired();
            Property(e => e.Date).HasColumnName("EXP_DATE");
            Property(e => e.EmployeeId).HasColumnName("EMP_ID").IsRequired();
        }
    }
}
