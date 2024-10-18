using EnterpriseInfoManager.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EnterpriseInfoManager.Data
{
    public class DatabaseSeeder
    {
        private readonly IMongoDatabase _database;

        public DatabaseSeeder(IMongoDatabase database)
        {
            _database = database;
        }

        public async Task SeedAsync()
        {
            var departmentsCollection = _database.GetCollection<Department>("Departments");
            var employeesCollection = _database.GetCollection<Employee>("Employees");

            if (await departmentsCollection.CountDocumentsAsync(FilterDefinition<Department>.Empty) == 0)
            {
                var departments = new List<Department>
                {
                    new Department { Name = "Human Resource" },
                    new Department { Name = "Tech Research" },
                    new Department { Name = "Sales & Marketing" },
                    new Department { Name = "Management Board" }
                };

                await departmentsCollection.InsertManyAsync(departments);
            }

            if (await employeesCollection.CountDocumentsAsync(FilterDefinition<Employee>.Empty) == 0)
            {
                var departments = await departmentsCollection.Find(FilterDefinition<Department>.Empty).ToListAsync();

                var employees = new List<Employee>
                {
                    new Employee { Name = "Bill Gates", Salary = 2500, Status = true, JoiningDate = new DateTime(2016, 12, 28), DepartmentId = departments[0].Id },
                    new Employee { Name = "Steve Jobs", Salary = 3000, Status = true, JoiningDate = new DateTime(2017, 1, 15), DepartmentId = departments[1].Id },
                    new Employee { Name = "Elon Musk", Salary = 4000, Status = true, JoiningDate = new DateTime(2018, 3, 22), DepartmentId = departments[2].Id },
                    new Employee { Name = "Jeff Bezos", Salary = 3500, Status = true, JoiningDate = new DateTime(2019, 5, 10), DepartmentId = departments[3].Id },
                    new Employee { Name = "Mark Zuckerberg", Salary = 4500, Status = true, JoiningDate = new DateTime(2020, 7, 18), DepartmentId = departments[0].Id },
                    new Employee { Name = "Larry Page", Salary = 5000, Status = true, JoiningDate = new DateTime(2021, 9, 25), DepartmentId = departments[1].Id },
                    new Employee { Name = "Sergey Brin", Salary = 5500, Status = true, JoiningDate = new DateTime(2022, 11, 30), DepartmentId = departments[2].Id },
                    new Employee { Name = "Tim Cook", Salary = 6000, Status = true, JoiningDate = new DateTime(2023, 2, 5), DepartmentId = departments[3].Id },
                    new Employee { Name = "Satya Nadella", Salary = 6500, Status = true, JoiningDate = new DateTime(2023, 4, 12), DepartmentId = departments[0].Id },
                    new Employee { Name = "Sundar Pichai", Salary = 7000, Status = true, JoiningDate = new DateTime(2023, 6, 20), DepartmentId = departments[1].Id }
                };

                await employeesCollection.InsertManyAsync(employees);
            }
        }
    }
}