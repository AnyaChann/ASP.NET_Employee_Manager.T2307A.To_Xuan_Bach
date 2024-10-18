using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using EnterpriseInfoManager.Models;
using EnterpriseInfoManager.Repositories;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EnterpriseInfoManager.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly EmployeeRepository _employeeRepository;
        private readonly DepartmentRepository _departmentRepository;

        public EmployeesController(EmployeeRepository employeeRepository, DepartmentRepository departmentRepository)
        {
            _employeeRepository = employeeRepository;
            _departmentRepository = departmentRepository;
        }

        public async Task<IActionResult> Create()
        {
            ViewData["DepartmentId"] = new SelectList(await _departmentRepository.GetAllAsync(), "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Salary,Status,JoiningDate,DepartmentId")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                await _employeeRepository.CreateAsync(employee);
                return RedirectToAction(nameof(Index));
            }
            ViewData["DepartmentId"] = new SelectList(await _departmentRepository.GetAllAsync(), "Id", "Name", employee.DepartmentId);
            return View(employee);
        }

        public async Task<IActionResult> Index()
        {
            var employees = await _employeeRepository.GetAllAsync();
            return View(employees);
        }
    }
}