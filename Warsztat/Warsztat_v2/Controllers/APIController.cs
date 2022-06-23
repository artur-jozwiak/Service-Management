using Microsoft.AspNetCore.Mvc;
using Warsztat.BLL.Models;
using Warsztat_v2.Data;
using Warsztat_v2.Repositories.Interfaces;

namespace Warsztat_v2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class APIController : Controller
    {
        private readonly ServiceContext _context;
        private readonly IEmployeeRepository _employeeRepository;

        public APIController(ServiceContext context, IEmployeeRepository employeeRepository)
        {
            _context = context;
            _employeeRepository = employeeRepository;
        }

        [HttpGet("/vehicle")]
        public async Task<IActionResult> GetVehicles()
        {
        
            var client = new HttpClient();
            var response = await client.GetAsync("https://vpic.nhtsa.dot.gov/api//vehicles/GetModelsForMake/honda?format=json");
            var vehicleResponse = await response.Content.ReadFromJsonAsync<VehicleResponse>();
            
            return Ok(vehicleResponse.Results.OrderBy(v => v.MakeName));          
        }

        [HttpPost("/employee")]
        public async Task<IActionResult> AddEmployees(Employee employee)
        {
            _employeeRepository.Add(employee);
           
           return Ok();
        }
    }
    public class VehicleResponse
    {
        public Car Car { get; set; }
        public class Vehicle
        {
            public int Make_ID { get; set; }
            public string MakeName { get; set; }
            public string ModelName { get; set; }
            public string VehicleTypeName { get; set; }
        }
        //{"Count":10202,"Message":"Response returned successfully","SearchCriteria":null,"Results":[{"Make_ID":440,"Make_Name":"ASTON MARTIN"},{"Make_ID":441,"Make_Name":"TESLA"},

        public int Count { get; set; }
        public string Message { get; set; }
        public  Car[] Results { get; set; }

    }
}
