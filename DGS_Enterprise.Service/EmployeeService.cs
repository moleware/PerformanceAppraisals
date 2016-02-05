using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DGS_Enterprise.Model;
using DGS_Enterprise.Data;
using DGS_Enterprise.Data.Repositories;
using DGS_Enterprise.Data.Infrastructure;

namespace DGS_Enterprise.Service
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> GetEmployees();
        Employee GetEmployee(int employeeId);
        Employee GetEmployeeByLogin(string login);
    }
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository employeesRepository;
        private readonly IUnitOfWork unitOfWork;

        //    public AssociateService(IAssociateRepository associatesRepository, IAssociateWorkRepository associateWorkRepository, IUnitOfWork unitOfWork)
        public EmployeeService(IEmployeeRepository employeesRepository, IUnitOfWork unitOfWork)
        {
            this.employeesRepository = employeesRepository;
            //    this.associateWorkRepository = associateWorkRepository;
            this.unitOfWork = unitOfWork;
        }

        #region IEmployeeService Members

        public IEnumerable<Employee> GetEmployees()
        {
            var employees = employeesRepository.GetAll();
            return employees;
        }

        public Employee GetEmployee(int employeeId)
        {
            var employee = employeesRepository.GetById(employeeId);
            return employee;
        }

        public Employee GetEmployeeByLogin(string login)
        {
            var employee = employeesRepository.GetEmployeeByLogin(login);
            return employee;
        }

        #endregion

    }
}
