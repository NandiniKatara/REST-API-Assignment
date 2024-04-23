using AccoliteLaptops.Models;
using Microsoft.AspNetCore.Mvc;

namespace AccoliteLaptops.Controllers
{
    [Route("api/Employee")]
    [ApiController]
    public class LaptopController : ControllerBase
    {
        // To get all the laptops
        [HttpGet]
        [Route("All", Name = "GetAllLaptops")]
        public ActionResult<IEnumerable<Laptop>> GetLaptops()
        {
            // Return all laptops from the repository
            return Ok(EmployeeRespository.Laptops);
        }

        // To get laptop by id
        [HttpGet("{id:int}")]
        public ActionResult<Laptop> GetLaptopsById(int id)
        {
            if (id <= 0)
            {
                // Return bad request if id is not valid
                return BadRequest();
            }

            var laptop = EmployeeRespository.Laptops.FirstOrDefault(n => n.Id == id);
            if (laptop == null)
            {
                // Return not found if laptop with given id is not found
                return NotFound($"Laptop with ID {id} not found");
            }

            // Return the laptop
            return Ok(laptop);
        }

        // To get laptop by employee name
        [HttpGet("{name:alpha}", Name = "GetLaptopsByEmployeeName")]
        public ActionResult<Laptop> GetLaptopByEmployeeName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                // Bad request if name is empty or null
                return BadRequest();
            }

            var laptop = EmployeeRespository.Laptops.FirstOrDefault(n => n.EmployeeName == name);
            if (laptop == null)
            {
                // Return not found if laptop with given name is not found
                return NotFound($"Laptop assigned to employee {name} not found");
            }

            // Return the laptop
            return Ok(laptop);
        }

        // To create a new employee
        [HttpPost]
        public ActionResult<Laptop> CreateEmployee(Laptop laptop)
        {
            if (laptop == null)
            {
                // Return bad request if laptop is null
                return BadRequest();
            }

            // Assign a unique ID to the new laptop
            int newId = EmployeeRespository.Laptops.Count + 1;
            laptop.Id = newId;

            // Add the new laptop to the repository
            EmployeeRespository.Laptops.Add(laptop);

            // Return the newly created laptop
            return Ok(laptop);
        }

        // To delete an employee
        [HttpDelete("{id:int}")]
        public ActionResult<bool> DeleteEmployee(int id)
        {
            if (id <= 0)
            {
                // Return bad request if id is not valid
                return BadRequest();
            }

            var laptop = EmployeeRespository.Laptops.FirstOrDefault(n => n.Id == id);
            if (laptop == null)
            {
                // Return not found if employee with given id is not found
                return NotFound($"Employee with ID {id} not found");
            }

            // Remove the laptop from the repository
            EmployeeRespository.Laptops.Remove(laptop);

            // Return true indicating successful deletion
            return Ok(true);
        }
    }
}
