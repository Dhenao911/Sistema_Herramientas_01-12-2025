using SH.Share.Models;

namespace SH.Backend.Repositories.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<ICollection<Employee>> GetEmployeeAsync();

        Task<Employee> GetEmployeeAsync(int id);

        Task<bool> EmployeeExitsByIdAsync(int id);

        Task<bool> EmployeeExisteByNameAsync(string name);

        Task<bool> CreateEmployeeAsync(Employee employee);

        Task<bool> UpdateEmployeeAsync(Employee employee);

        Task<bool> DeleteEmployeeAsync(int id);
    }
}