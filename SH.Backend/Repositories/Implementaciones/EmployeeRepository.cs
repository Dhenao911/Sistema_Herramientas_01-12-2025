using Microsoft.EntityFrameworkCore;
using SH.Backend.DAL;
using SH.Backend.Repositories.Interfaces;
using SH.Share.Models;

namespace SH.Backend.Repositories.Implementaciones
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DataContext _context;

        public EmployeeRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateEmployeeAsync(Employee employee)
        {
            employee.CreatedDate = DateTime.UtcNow;
            var employeeCreate = await _context.Employees.AddAsync(employee);

            return await _context.SaveChangesAsync() >= 0 ? true : false;
        }

        public async Task<bool> DeleteEmployeeAsync(int id)
        {
            var employeeExist = await GetEmployeeAsync(id);

            if (employeeExist == null)
            {
                return false;
            }

            _context.Employees.Remove(employeeExist);

            return await _context.SaveChangesAsync() >= 0 ? true : false;
        }

        public async Task<bool> EmployeeExisteByNameAsync(string name)
        {
            return await _context.Employees
                .AsNoTracking()
                .AnyAsync(e => e.Name == name);
        }

        public async Task<bool> EmployeeExitsByIdAsync(int id)
        {
            return await _context.Employees
                .AsNoTracking()
                .AnyAsync(e => e.id == id);
        }

        public async Task<ICollection<Employee>> GetEmployeeAsync()
        {
            return await _context.Employees
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Employee> GetEmployeeAsync(int id)
        {
            return await _context.Employees
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.id == id);
        }

        public async Task<bool> UpdateEmployeeAsync(Employee employee)
        {
            employee.UpdatedDate = DateTime.UtcNow;

            _context.Employees.Update(employee);

            return await _context.SaveChangesAsync() >= 0 ? true : false;
        }
    }
}