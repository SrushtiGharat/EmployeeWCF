using Common.Contracts;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
namespace RepositoryLayer
{
    public class EmployeeRepository:IEmployeeRepository
    {
        employee_managementEntities1 employeeManagementEntitiesObj;
        public EmployeeRepository()
        {
            employeeManagementEntitiesObj = new employee_managementEntities1();
        }
        public IList<EmployeeContract> GetAllEmployee()
        {
            var query = (from emp in employeeManagementEntitiesObj.EmployeeDetails select emp).Distinct();
            List<EmployeeContract> employeeData = new List<EmployeeContract>();
            query.ToList().ForEach(x =>
            {
                employeeData.Add(new EmployeeContract
                {
                    Id = x.Id,
                    Name = x.Name,
                    Email = x.Email,
                    Salary = (int)x.Salary
                });
            });
            return employeeData;
        }
        public int AddEmployee(EmployeeContract employeeContract)
        {
            EmployeeDetail emp = new EmployeeDetail()
            {
                Name = employeeContract.Name,
                Email = employeeContract.Email,
                Salary = employeeContract.Salary
            };
            employeeManagementEntitiesObj.EmployeeDetails.Add(emp);
            return employeeManagementEntitiesObj.SaveChanges();
        }
        public int UpdateEmployee(EmployeeContract employeeContract,int EmpId)
        {
            EmployeeDetail employee = employeeManagementEntitiesObj.EmployeeDetails.Find(EmpId);
            if(employee!=null)
            {
                employee.Email = employeeContract.Email;
                employee.Name = employeeContract.Name;
                employee.Salary = employeeContract.Salary;
                return employeeManagementEntitiesObj.SaveChanges();
            }
            else
            {
                throw new Exception("Employee do not exists");
            }
        }
        public EmployeeContract GetById(int empId)
        {
            var employee = employeeManagementEntitiesObj.EmployeeDetails.Find(empId);
            EmployeeContract employeeContract = new EmployeeContract()
            {
                Name = employee.Name,
                Email = employee.Email,
                Salary = (int)employee.Salary,
                Id = employee.Id
            };
            return employeeContract;
        }

        public int DeleteEmployee(int empId)
        {
            var employee = (from emp in employeeManagementEntitiesObj.EmployeeDetails where emp.Id == empId select emp).FirstOrDefault();
            if(employee != null)
            {
                employeeManagementEntitiesObj.EmployeeDetails.Remove(employee);
                return employeeManagementEntitiesObj.SaveChanges();
            }
            else
            {
                return 0;
            }
        }
        public EmployeeContract GetEmployeeByEmail(string email)
        {
            var employee = (from emp in employeeManagementEntitiesObj.EmployeeDetails where emp.Email == email select emp).FirstOrDefault();

            if (employee != null)
            {
                EmployeeContract employeeContract = new EmployeeContract()
                {
                    Name = employee.Name,
                    Email = employee.Email,
                    Salary = (int)employee.Salary,
                    Id = employee.Id
                };
                return employeeContract;
            }
            return null;
        }

    }
}
