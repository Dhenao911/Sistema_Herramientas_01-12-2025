using Microsoft.AspNetCore.Mvc;
using SH.Backend.Services.Interfaces;
using SH.Share.Dtos;

namespace SH.Backend.Controllers
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ICollection<EmployeeDto>>> GetEmployeeAsync()
        {
            try
            {
                var getEmployee = await _employeeService.GetEmployeeAsync();
                return Ok(getEmployee);
            }
            catch (InvalidOperationException ex) when (ex.Message.Contains("No hay"))
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("{id:int}", Name = "GetEmployeeAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<EmployeeDto>> GetEmployeeAsync(int id)
        {
            try
            {
                var getEmployee = await _employeeService.GetEmployeeAsync(id);
                return Ok(getEmployee);
            }
            catch (InvalidOperationException ex) when (ex.Message.Contains("No existe"))
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex2)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost(Name = "CreateEmployeeAync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<EmployeeDto>> CreateEmployeeAsync(EmployeeCreateDto employeeCreateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var createEmployee = await _employeeService.CreateEmployeeAsync(employeeCreateDto);

                return CreatedAtRoute("GetEmployeeAsync",
                    new { id = createEmployee.Id },
                    createEmployee);
            }
            catch (InvalidOperationException ex) when (ex.Message.Contains("Ya existe"))
            {
                return Conflict(ex.Message);
            }
            catch (Exception ex1)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}