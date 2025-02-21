using System.ComponentModel.DataAnnotations;
using EmployeeAdminPortal.Data;
using EmployeeAdminPortal.Model;
using EmployeeAdminPortal.Model.Entities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using MvcRoute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace EmployeeAdminPortal.Controllers
{
    //localhost:xxxx/api/employees
    //[Route("api/[controller]")]
    [MvcRoute("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        //syntax of the method
        //IActionResult is the return type

        public EmployeesController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        //read
        public IActionResult GetAllEmployees()
        {//     objectname   = fieldname.Propertyname
            var allEmployees = dbContext.Employees.ToList();

            //since we are following restful convenction,we want to send this as Ok response
            return Ok(allEmployees);
        }

        //getfromsearch
        //read
        [HttpGet]
        //[Route("{id:guid}")]
        [MvcRoute("{id:guid}")]
        public IActionResult GetEmployeeById(Guid id)
        {
            var employee = dbContext.Employees.Find(id);

            if (employee is null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        //post methgod
        //create
        [HttpPost]
        public IActionResult AddEmployee(AddEmployeeDto addEmployeeDto)
        {
            //var employeeEntity = new Employee()
            var employeeEntity = new Employee()
            {
                Name = addEmployeeDto.Name,
                Email = addEmployeeDto.Email,
                Phone = addEmployeeDto.Phone,
                Salary = addEmployeeDto.Salary
            };
            dbContext.Employees.Add(employeeEntity);
            dbContext.SaveChanges();

            return Ok(employeeEntity);

        }


        //update
        //put
        //since we are updating we need a unique identifier to update the record
        //so we need to route to id
        [HttpPut]
        ////[Route("{id:guid}")]
        //[Route("{id:guid}")]
        [MvcRoute("{id:guid}")]

        public IActionResult UpdateEmployee(Guid id, UpdateEmployeeDto updateEmployeeDto)
        {
            var employee = dbContext.Employees.Find(id);

            if (employee is null)
            {
                return NotFound();
            }
            employee.Name = updateEmployeeDto.Name;
            employee.Email = updateEmployeeDto.Email;
            employee.Phone = updateEmployeeDto.Phone;
            employee.Salary = updateEmployeeDto.Salary;
            //always remeebr to saave changes to get reflected in database
            dbContext.SaveChanges();

            return Ok(employee);



            }

        //delete operation
        [HttpDelete]
        [MvcRoute("{id:guid}")]

        public IActionResult DeleteEmployee(Guid id)
        {
            var employee = dbContext.Employees.Find(id);
            if(employee is null)
            {
                return NotFound();
            }

            dbContext.Employees.Remove(employee);

            dbContext.SaveChanges();

            return Ok();
        }

    }
}
