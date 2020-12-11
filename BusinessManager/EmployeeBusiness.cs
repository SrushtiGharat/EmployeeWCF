using BusinessManager.Interface;
using Common.Contracts;
using RepositoryLayer;
using System;
using System.Collections.Generic;

namespace BusinessManager
{
    public class EmployeeBusiness : IEmployeeBusiness
    {
        public readonly EmployeeRepository employeeRepository;
        public EmployeeBusiness()
        {
            employeeRepository = new EmployeeRepository();
        }
        public IList<EmployeeContract> GetAllEmployee()
        {
            IList<EmployeeContract> employeeContracts = employeeRepository.GetAllEmployee();
            if (employeeContracts != null)
            {
                return employeeContracts;
            }
            else
            {
                return new List<EmployeeContract>();
            }
        }
        public string AddEmployee(EmployeeContract employeeContract)
        {

            if (employeeRepository.GetEmployeeByEmail(employeeContract.Email) != null)
            {
                return "Employee already registered";
            }
            int empDetails = employeeRepository.AddEmployee(employeeContract);
            if (empDetails > 0)
            {
                return "Employee Added successfully";
            }
            else
            {
                return "Employee Addition Failed";
            }
        }
        public string UpdateEmployee(EmployeeContract employeeContract,int EmpId)
        {
            if(employeeRepository.UpdateEmployee(employeeContract,EmpId) == 1)
            {
                return "Employee updated successfully";
            }
            else
            {
                return "Employee not updated";
            }
        }
        public EmployeeContract GetById(int empId)
        {
            EmployeeContract employeeContract = employeeRepository.GetById(empId);
            if(employeeContract!=null)
            {
                return employeeContract;
            }
            else
            {
                return new EmployeeContract();
            }
        }
        public string DeleteEmployee(int empId)
        {
            if(employeeRepository.DeleteEmployee(empId)==1)
            {
                return "Employee deleted successfully";
            }
            else
            {
                return "Employee do not exists";
            }
        }

    }
}

