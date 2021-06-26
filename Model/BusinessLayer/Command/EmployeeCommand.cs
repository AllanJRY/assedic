using Model;
using Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Command
{
    public class EmployeeCommand
    {
        private readonly Context _context;

        public EmployeeCommand(Context context)
        {
            _context = context;
        }

        public int Add(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
            return employee.Id;
        }

        public void Update(Employee newEmployeeDatas)
        {
            Employee employee = _context.Employees.Where(e => e.Id == newEmployeeDatas.Id).FirstOrDefault();
            if(employee != null)
            {
                employee.Lastname = newEmployeeDatas.Lastname;
                employee.Firstname = newEmployeeDatas.Firstname;
                employee.DateOfBirth = newEmployeeDatas.DateOfBirth;
                employee.Biography = newEmployeeDatas.Biography;
                employee.Seniority = newEmployeeDatas.Seniority;
            }
            _context.SaveChanges();
        }

        public void Delete(int employeeId)
        {
            Employee employeeToDelete = _context.Employees.Find(employeeId);
            if(employeeToDelete != null)
            {
                _context.Employees.Remove(employeeToDelete);
            }

            _context.SaveChanges();
        }

        public void AddPostulation(int employeeId, Postulation postulation)
        {
            Employee employee = _context.Employees.Find(employeeId);
            if(employee != null)
            {
                employee.Postulations.Add(postulation);
                _context.SaveChanges();
            }
        }

        public void RemovePostulation(int employeeId, Postulation postulation)
        {
            Employee employee = _context.Employees.Find(employeeId);
            if (employee != null)
            {
                employee.Postulations.Remove(postulation);
                _context.SaveChanges();
            }
        }
    }
}
