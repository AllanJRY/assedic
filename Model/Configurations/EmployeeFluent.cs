using Model.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Configurations
{
    class EmployeeFluent : EntityTypeConfiguration<Employee>
    {
        public EmployeeFluent()
        {
            ToTable("APP_EMPLOYEE");
            HasKey(e => e.Id);

            Property(e => e.Id).HasColumnName("EMP_ID").IsRequired();
            Property(e => e.Lastname).HasColumnName("EMP_LASTNAME").IsRequired();
            Property(e => e.Firstname).HasColumnName("EMP_FIRSTNAME");
            Property(e => e.Biography).HasColumnName("EMP_BIOGRAPHY");
            Property(e => e.DateOfBirth).HasColumnName("EMP_DATEOFBIRTH");
            Property(e => e.Seniority).HasColumnName("EMP_SENIORITY");

            HasMany(e => e.Formations).WithRequired(f => f.Employee).HasForeignKey(f => f.EmployeeId);
            HasMany(e => e.Experiences).WithRequired(e => e.Employee).HasForeignKey(e => e.EmployeeId);
            HasMany(e => e.Postulations).WithRequired(p => p.Employee).HasForeignKey(p => p.EmployeeId);
        }
    }
}
