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
        Employee employee;
      
        public Employee Add(Employee emp)
        {
            cx.Employees.Add(emp);
            cx.SaveChanges();
            return emp;
            
        }
    }
}