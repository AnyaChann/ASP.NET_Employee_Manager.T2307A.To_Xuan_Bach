using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using EnterpriseInfoManager.Models;
using EnterpriseInfoManager.Repositories;

namespace EnterpriseInfoManager.Controllers
{
    public class DepartmentsController : Controller
    {
        private readonly DepartmentRepository _departmentRepository;

        public DepartmentsController(DepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        // GET: Departments
        public async Task<IActionResult> Index()
        {
            var departments = await _departmentRepository.GetAllAsync();
            return View(departments);
        }

        // GET: Departments/Details/{id}
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var department = await _departmentRepository.GetByIdAsync(id);
            if (department == null)
            {
                return NotFound();
            }

            return View(department);
        }

        // GET: Departments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Departments/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name")] Department department)
        {
            if (ModelState.IsValid)
            {
                await _departmentRepository.CreateAsync(department);
                return RedirectToAction(nameof(Index));
            }
            return View(department);
        }

        // GET: Departments/Edit/{id}
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var department = await _departmentRepository.GetByIdAsync(id);
            if (department == null)
            {
                return NotFound();
            }
            return View(department);
        }

        // POST: Departments/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Name")] Department department)
        {
            if (id != department.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _departmentRepository.UpdateAsync(id, department);
                return RedirectToAction(nameof(Index));
            }
            return View(department);
        }

        // GET: Departments/Delete/{id}
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var department = await _departmentRepository.GetByIdAsync(id);
            if (department == null)
            {
                return NotFound();
            }

            return View(department);
        }

        // POST: Departments/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            await _departmentRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}