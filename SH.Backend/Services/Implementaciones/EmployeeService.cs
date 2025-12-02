using AutoMapper;
using Microsoft.OpenApi.Writers;
using SH.Backend.Repositories.Interfaces;
using SH.Backend.Services.Interfaces;
using SH.Share.Dtos;
using SH.Share.Models;

namespace SH.Backend.Services.Implementaciones
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public async Task<EmployeeDto> CreateEmployeeAsync(EmployeeCreateDto employeeCreate)
        {
            var employeeExist = await _employeeRepository.EmployeeExitsByIdAsync(employeeCreate.Id);
            if (employeeExist)
            {
                throw new InvalidOperationException($"Ya existe un empleado con el id {employeeCreate.Id}");
            }

            //Pasamos de EmployeeCreateDto a Employee
            var employee = _mapper.Map<Employee>(employeeCreate);

            var createEmployeeRepository = await _employeeRepository.CreateEmployeeAsync(employee);

            if (!createEmployeeRepository)
            {
                throw new Exception($"No se pudo crear el empleado en la base de datos");
            }

            return _mapper.Map<EmployeeDto>(employee);
        }

        public Task<bool> DeleteEmployeeAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EmployeeExisteByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EmployeeExitsByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<EmployeeDto>> GetEmployeeAsync()
        {
            var getEmployee = await _employeeRepository.GetEmployeeAsync();
            if (getEmployee == null)
            {
                throw new InvalidOperationException($"No hay empleados registrados");
            }
            return _mapper.Map<ICollection<EmployeeDto>>(getEmployee);
        }

        public async Task<EmployeeDto> GetEmployeeAsync(int id)
        {
            var getEmployee = await _employeeRepository.GetEmployeeAsync(id);

            if (getEmployee == null)
            {
                throw new InvalidOperationException($"No Existe un empleado con el numero de id {id}");
            }
            return _mapper.Map<EmployeeDto>(getEmployee);
        }

        public Task<EmployeeDto> UpdateEmployeeAsync(int id, EmployeeUpdateDto employeeUpdate)
        {
            throw new NotImplementedException();
        }
    }
}