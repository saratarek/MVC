using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace lab2MVC.Managers
{
    public class EmployeeManager
    {
        ModelContext cx = new ModelContext();
        public Employee GetById(int id)
        {
           return cx.Employees.Find(id);
            
        }
        public Employee Add(Employee emp)
        {
            cx.Employees.Add(emp);
            cx.SaveChanges();
            return emp;
            
        }
        public Employee Edit(Employee emp)
        {
            Employee employee = cx.Employees.FirstOrDefault(c => c.Id == emp.Id);
            employee.Name = emp.Name;
            employee.Email = emp.Email;
            employee.Salary = emp.Salary;
            employee.Address = emp.Address;
            cx.SaveChanges();
            return employee;
        }
        public Employee Delete(int id)
        {
          Employee empId=cx.Employees.FirstOrDefault(c => c.Id == id);
            cx.Employees.Remove(empId);
            cx.SaveChanges();
            return empId;
        }
    }
}