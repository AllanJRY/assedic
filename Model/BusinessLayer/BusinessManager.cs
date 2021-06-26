using BusinessLayer.Command;
using BusinessLayer.Query;
using Model;
using Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class BusinessManager
    {
        private readonly Context context;

        private static BusinessManager businessManager = null;

        private BusinessManager()
        {
            context = new Context();
        }

        public static BusinessManager Instance()
        {
            if(businessManager == null)
            {
                businessManager = new BusinessManager();
            }

            return businessManager;
        }

        #region JobAdvertisement
        public List<JobAdvertisement> GetAllJobAdvertisements()
        {
            JobAdvertisementQuery jobAdvertisementQuery = new JobAdvertisementQuery(context);
            return jobAdvertisementQuery.GetAll().ToList();
        }

        public int AddJobAdvertisement(JobAdvertisement jobAdvertisement)
        {
            jobAdvertisement.Status = GetStatusById(jobAdvertisement.StatusId);

            JobAdvertisementCommand jobAdvertisementCommand = new JobAdvertisementCommand(context);
            return jobAdvertisementCommand.Add(jobAdvertisement);
        }

        public void UpdateJobAdvertisement(JobAdvertisement newJobAdvertisementData)
        {
            newJobAdvertisementData.Status = GetStatusById(newJobAdvertisementData.StatusId);
            JobAdvertisementCommand jobAdvertisementCommand = new JobAdvertisementCommand(context);
            jobAdvertisementCommand.Update(newJobAdvertisementData);
        }

        public void DeleteJobAdvertisement(int jobAdvertisementId)
        {
            JobAdvertisementCommand jobAdvertisementCommand = new JobAdvertisementCommand(context);
            jobAdvertisementCommand.Delete(jobAdvertisementId);
        }
        #endregion

        #region Status
        public List<Status> GetAllStatus()
        {
            return (new StatusQuery(context)).GetAll().ToList();
        }

        public Status GetStatusById(int id)
        {
            return (new StatusQuery(context)).GetById(id);
        }
        #endregion

        #region Employee
        public List<Employee> GetAllEmployee()
        {
            EmployeeQuery employeeQuery = new EmployeeQuery(context);
            return employeeQuery.GetAll().ToList();
        }

        public Employee GetEmployeeById(int id)
        {
            EmployeeQuery employeeQuery = new EmployeeQuery(context);
            return employeeQuery.GetById(id);
        }

        public int AddEmployee(Employee employee)
        {
            EmployeeCommand employeeCommand = new EmployeeCommand(context);
            return employeeCommand.Add(employee);
        }

        public void UpdateEmployee(Employee newEmployeeData)
        {
            EmployeeCommand employeeCommand = new EmployeeCommand(context);
            employeeCommand.Update(newEmployeeData);
        }

        public void DeleteEmployee(int id)
        {
            EmployeeCommand employeeCommand = new EmployeeCommand(context);
            employeeCommand.Delete(id);
        }
        #endregion

        #region Postulation
        public List<Postulation> GetAllPostulation()
        {
            return (new PostulationQuery(context)).GetAll().ToList();
        }

        public List<Postulation> GetPostulationByJobAdvertisementId(int jobAdvertisementId)
        {
            return (new PostulationQuery(context)).GetAllOfJobAdvertisement(jobAdvertisementId).ToList();
        }

        public List<Postulation> GetPostulationByEmployeeId(int employeeId)
        {
            return (new PostulationQuery(context)).GetAllOfEmployee(employeeId).ToList();
        }

        public List<Employee> GetAllPostulants(int jobAdvertisementId)
        {
            return (new EmployeeQuery(context)).GetPostulantsOfJobAdvertisement(jobAdvertisementId).ToList();
        }

        public Postulation NewPostulation(int jobAdvertisementId, int employeeId)
        {
            Postulation postulation = new Postulation
            {
                Date = DateTime.Now,
                Status = "to-review",
                EmployeeId = employeeId,
                JobAdvertisementId = jobAdvertisementId
            };

            PostulationCommand postulationCommand = new PostulationCommand(context);
            postulationCommand.Add(postulation);

            return postulation;
        }
        #endregion
    }
}
