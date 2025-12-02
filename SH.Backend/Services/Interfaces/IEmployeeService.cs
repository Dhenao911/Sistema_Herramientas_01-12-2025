using SH.Share.Dtos;
using SH.Share.Models;

namespace SH.Backend.Services.Interfaces
{
    public interface IEmployeeService
    {
        Task<ICollection<EmployeeDto>> GetEmployeeAsync();

        Task<EmployeeDto> GetEmployeeAsync(int id);

        Task<EmployeeDto> CreateEmployeeAsync(EmployeeCreateDto employeeCreate);

        Task<EmployeeDto> UpdateEmployeeAsync(int id, EmployeeUpdateDto employeeUpdate);

        Task<bool> EmployeeExitsByIdAsync(int id);

        Task<bool> EmployeeExisteByNameAsync(string name);

        Task<bool> DeleteEmployeeAsync(int id);
    }
}