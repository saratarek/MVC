namespace lab2MVC
{
    //using Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class ModelContext : DbContext
    {
      
        public ModelContext()
            : base("name=ModelContext")
        {
        }
        public virtual DbSet<Employee> Employees { get; set; }
        //public virtual DbSet<Department> Departments { get; set; }


    }
}