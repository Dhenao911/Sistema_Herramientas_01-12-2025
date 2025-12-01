using SH.Share.Models;

namespace SH.Backend.Repositories.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<ICollection<Employee>> GetEmployeeAsync();

        Task<Employee> GetEmployeeAsync(int id);
    }
}