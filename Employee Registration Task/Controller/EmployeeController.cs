using Employee_Registration_Task.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Employee_Registration_Task.Controller
{

    [ApiController]
    public class EmployeeController : ControllerBase
    {
       
        
        [HttpPost]
        [IgnoreAntiforgeryToken]
        [Route("api/[controller]/Post")]
        public IActionResult Post(Employee Obj)
        {
            Employee emp = new Employee();
            emp.Id = Obj.Id;
            emp.Name = Obj.Name;
            emp.Job = Obj.Job;
            emp.salary =Obj.salary;
            emp.Adddetails(emp);
            return Ok("Register succuessfully");
        }
        [HttpGet]
        [IgnoreAntiforgeryToken]
        [Route("api/[controller]/Getdetails")]
        public IActionResult Getdetails()
        {

            Employee Emp   = new Employee();
            var result =Emp.GetEmployeesData();

            return Ok(result);
        }


    }
}
