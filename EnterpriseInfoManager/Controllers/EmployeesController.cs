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

        // GET: Employees
        public async Task<IActionResult> Index()
        {
            var employees = await _employeeRepository.GetAllAsync();
            return View(employees);
        }

        // GET: Employees/Details/{id}
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _employeeRepository.GetByIdAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Employees/Create
        public async Task<IActionResult> Create()
        {
            ViewData["DepartmentId"] = new SelectList(await _departmentRepository.GetAllAsync(), "Id", "Name");
            return View();
        }

        // POST: Employees/Create
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

        // GET: Employees/Edit/{id}
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _employeeRepository.GetByIdAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            ViewData["DepartmentId"] = new SelectList(await _departmentRepository.GetAllAsync(), "Id", "Name", employee.DepartmentId);
            return View(employee);
        }

        // POST: Employees/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Name,Salary,Status,JoiningDate,DepartmentId")] Employee employee)
        {
            if (id != employee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _employeeRepository.UpdateAsync(id, employee);
                return RedirectToAction(nameof(Index));
            }

            ViewData["DepartmentId"] = new SelectList(await _departmentRepository.GetAllAsync(), "Id", "Name", employee.DepartmentId);
            return View(employee);
        }

        // GET: Employees/Delete/{id}
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _employeeRepository.GetByIdAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employees/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            await _employeeRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}