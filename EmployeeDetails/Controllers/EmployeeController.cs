using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EmployeeDetails.Models;
using System.Collections;

namespace EmployeeDetails.Controllers
{
    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            // return new string[] { "value1", "value2" };
            EmployeedataAccessLayer employeeDataAccessLayers = new EmployeedataAccessLayer();
            return employeeDataAccessLayers.GetAllEmployees();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Employee Get(int id)
        {
            //return "value";
            EmployeedataAccessLayer employeeDataAccessLayers = new EmployeedataAccessLayer();
            var employee = employeeDataAccessLayers.GetEmployeeData(id);
            return employee;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]Employee employee)
        {
            EmployeedataAccessLayer employeeDataAccessLayers = new EmployeedataAccessLayer();
            employeeDataAccessLayers.AddEmployee(employee);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody]Employee employee)
        {
            if (id!=employee.ID)
            {
                return BadRequest();
            }
            EmployeedataAccessLayer employeeDataAccessLayers = new EmployeedataAccessLayer();
            employeeDataAccessLayers.UpdateEmployee(employee);
            return Ok();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            EmployeedataAccessLayer employeeDataAccessLayers = new EmployeedataAccessLayer();
            employeeDataAccessLayers.DeleteEmployee(id);
            return Ok();
        }
    }
}
