using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoCRUD.IRepository;
using MongoCRUD.Models;

namespace MongoCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IGenericRepository<Employee> _employeeRepository;

        public EmployeesController(IGenericRepository<Employee> employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet("GetAllEmployees")]
        public IActionResult GetAllEmployees()
        {
            var employees = _employeeRepository.GetAll();
            return Ok(employees);
        }

        [HttpPost("SaveEmployee")]
        public IActionResult SaveEmployee(Employee employee)
        {
            var employees = _employeeRepository.Save(employee);
            return Ok(employees);
        }

        [HttpDelete("DeleteEmployee")]
        public IActionResult Deletemployee(string employeeId)
        {
            string result = _employeeRepository.Delete(employeeId);
            return Ok(result);
        }
    }
}
