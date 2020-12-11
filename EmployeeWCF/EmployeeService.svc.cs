using BusinessManager;
using BusinessManager.Interface;
using Common;
using Common.Contracts;
using System;
using System.Collections.Generic;
using System.Net;
using System.ServiceModel.Web;

namespace EmployeeWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "EmployeeService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select EmployeeService.svc or EmployeeService.svc.cs at the Solution Explorer and start debugging.
    public class EmployeeService : IEmployeeService
    {
        public readonly IEmployeeBusiness employeeBusiness;

        public EmployeeService()
        {
            employeeBusiness = new EmployeeBusiness();
        }
        public string AddEmployee(EmployeeContract employeeContract)
        {
            try
            {
                return employeeBusiness.AddEmployee(employeeContract);
            }
            catch(Exception e)
            {
                ErrorClass err = new ErrorClass();
                err.success = false;
                err.message = e.Message;
                throw new WebFaultException<ErrorClass>(err, HttpStatusCode.NotFound);
            }
        }
        public IList<EmployeeContract> GetAllEmployees()
        {
            try
            {
                return employeeBusiness.GetAllEmployee();
            }
            catch(Exception e)
            {
                ErrorClass err = new ErrorClass();
                err.success = false;
                err.message = e.Message;
                throw new WebFaultException<ErrorClass>(err, HttpStatusCode.NotFound);
            }
        }
        public EmployeeContract GetById(string EmpId)
        {
            try
            {
                return employeeBusiness.GetById(Convert.ToInt32(EmpId));
            }
            catch (Exception e)
            {
                ErrorClass err = new ErrorClass();
                err.success = false;
                err.message = e.Message;
                throw new WebFaultException<ErrorClass>(err, HttpStatusCode.NotFound);
            }
        }
        public string DeleteEmployee(string EmpId)
        {
            try
            {
                return employeeBusiness.DeleteEmployee(Convert.ToInt32(EmpId));
            }
            catch (Exception e)
            {
                ErrorClass err = new ErrorClass();
                err.success = false;
                err.message = e.Message;
                throw new WebFaultException<ErrorClass>(err, HttpStatusCode.NotFound);
            }
        }

        public string UpdateEmploye(EmployeeContract employeeContract, string EmpId)
        {
            try
            {
                return employeeBusiness.UpdateEmployee(employeeContract, Convert.ToInt32(EmpId));
            }
            catch (Exception e)
            {
                ErrorClass err = new ErrorClass();
                err.success = false;
                err.message = e.Message;
                throw new WebFaultException<ErrorClass>(err, HttpStatusCode.NotFound);
            }
        }
    }
}
