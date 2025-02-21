using System.Runtime.CompilerServices;
using EmployeeAdminPortal.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAdminPortal.Data
{

    //ApplicationDbContext class will inherit the properties of DbContext class
    //which we have installed from Microsoft.EntityFrameworkCore
    public class ApplicationDbContext :DbContext
    {
        //now we will craete the contructor for this class
        //public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        //{
            // This  contructor is alos fine
        //}

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        //now we will add property for the collection we are going to store
        //here we are going to store employee 
        //so we are going to have create the DB set of employee type
        //syntax to define property
        //prop tab
        //public int MyProperty { get; set; }

        //we generally write the propertyName as  the plural form of the entities name 
        public DbSet<Employee> Employees { get; set; }

    }
}
