using Model.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Configurations
{
    class FormationFluent : EntityTypeConfiguration<Formation>
    {
        public FormationFluent()
        {
            ToTable("APP_FORMATION");
            HasKey(f => f.Id);

            Property(f => f.Id).HasColumnName("FOR_ID").IsRequired();
            Property(f => f.Title).HasColumnName("FOR_TITLE");
            Property(f => f.Date).HasColumnName("FOR_DATE");
            Property(f => f.EmployeeId).HasColumnName("EMP_ID").IsRequired();
        }
    }
}
