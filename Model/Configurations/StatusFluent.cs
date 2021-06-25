using Model.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Configurations
{
    class StatusFluent : EntityTypeConfiguration<Status>
    {
        public StatusFluent()
        {
            ToTable("APP_STATUS");
            HasKey(s => s.Id);

            Property(s => s.Id).HasColumnName("STA_ID").IsRequired();
            Property(s => s.Label).HasColumnName("STA_LABEL").IsRequired().HasMaxLength(255);
        }

    }
}
