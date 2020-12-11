using Common.Contracts;
using System.Collections.Generic;

namespace BusinessManager.Interface
{
    public interface IEmployeeBusiness
    {
        IList<EmployeeContract> GetAllEmployee();
        string AddEmployee(EmployeeContract employeeContract);
        string UpdateEmployee(EmployeeContract employeeContract, int EmpId);
        EmployeeContract GetById(int empId);
        string DeleteEmployee(int empId);
    }
}
