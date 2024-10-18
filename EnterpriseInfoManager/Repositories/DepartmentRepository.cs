using EnterpriseInfoManager.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EnterpriseInfoManager.Repositories
{
    public class DepartmentRepository
    {
        private readonly IMongoCollection<Department> _departments;

        public DepartmentRepository(IMongoDatabase database)
        {
            _departments = database.GetCollection<Department>("Departments");
        }

        public async Task<List<Department>> GetAllAsync()
        {
            return await _departments.Find(d => true).ToListAsync();
        }

        public async Task<Department?> GetByIdAsync(string id)
        {
            return await _departments.Find(d => d.Id == id).FirstOrDefaultAsync();
        }

        public async Task CreateAsync(Department department)
        {
            await _departments.InsertOneAsync(department);
        }

        public async Task UpdateAsync(string id, Department department)
        {
            await _departments.ReplaceOneAsync(d => d.Id == id, department);
        }

        public async Task DeleteAsync(string id)
        {
            await _departments.DeleteOneAsync(d => d.Id == id);
        }
    }
}