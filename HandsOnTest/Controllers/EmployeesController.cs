using HandsOnTest.Entities;
using HandsOnTest.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HandsOnTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService; 

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                var data = await _employeeService.Get();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult> Get([FromRoute] int Id)
        {
            try
            {
                var data = await _employeeService.GetOne(Id);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }
    }
}
