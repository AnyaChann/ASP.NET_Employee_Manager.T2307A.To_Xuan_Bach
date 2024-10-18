using EnterpriseInfoManager.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EnterpriseInfoManager.Repositories
{
    public class EmployeeRepository
    {
        private readonly IMongoCollection<Employee> _employees;

        public EmployeeRepository(IMongoDatabase database)
        {
            _employees = database.GetCollection<Employee>("Employees");
        }

        public async Task<List<Employee>> GetAllAsync()
        {
            return await _employees.Find(e => true).ToListAsync();
        }

        public async Task<Employee> GetByIdAsync(string id)
        {
            return await _employees.Find(e => e.Id == id).FirstOrDefaultAsync();
        }

        public async Task CreateAsync(Employee employee)
        {
            await _employees.InsertOneAsync(employee);
        }

        public async Task UpdateAsync(string id, Employee employee)
        {
            await _employees.ReplaceOneAsync(e => e.Id == id, employee);
        }

        public async Task DeleteAsync(string id)
        {
            await _employees.DeleteOneAsync(e => e.Id == id);
        }
    }
}