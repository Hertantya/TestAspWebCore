using Microsoft.AspNetCore.Mvc;
using AspNetCoreWebMVC.Models;
using Microsoft.EntityFrameworkCore;
using AspNetCoreWebMVC.Repositories;
using Rotativa.AspNetCore;
using System.Data;
using ClosedXML.Excel;

namespace AspNetCoreWebMVC.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeRepository _EmployeeRepository;

        public EmployeeController(EmployeeRepository EmployeeRepository)
        {
            _EmployeeRepository = EmployeeRepository;
        }

        public IActionResult Index()
        {
            var Employees = _EmployeeRepository.GetAllEmployee();
            List<Employee> lstEmployee = Employees.ToList();
            return View(lstEmployee);
        }

        public IActionResult Details(int id)
        {
            var Employee = _EmployeeRepository.GetEmployeeById(id);
            if (Employee == null)
            {
                return NotFound();
            }
            return View(Employee);
        }
        public IActionResult AddorEdit(int id = 0)
        {
            var employees = _EmployeeRepository.GetEmployeeById(id);
            if (id == 0)
                return View(new Employee());
            else
                return View(employees);
        }

        public IActionResult ExportToPdf()
        {
            var employees = _EmployeeRepository.GetAllEmployee(); // Fetch the data again
            return new ViewAsPdf("ExportPdfView", employees)
            {
                FileName = "Employees.pdf"
            };
        }
        public IActionResult ExportToExcel()
        {
            var dataTable = _EmployeeRepository.GetEmployeeForExcel();
            DataTable dtx = new DataTable();
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Employees");
                worksheet.Cell(1, 1).InsertTable(dataTable);

                // Auto-fit columns
                worksheet.ColumnsUsed().AdjustToContents();

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    stream.Position = 0;

                    string fileName = $"Employees.xlsx";
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
                }
            }
        }

        // POST: Employee/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SaveEmployee(Employee employee)
        {
            if (ModelState.IsValid)
            {
                if(employee.Id == 0)
                    _EmployeeRepository.AddEmployee(employee);
                else
                    _EmployeeRepository.UpdateEmployee(employee);

                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }
        public IActionResult Delete(int id)
        {
            var Employee = _EmployeeRepository.GetEmployeeById(id);
            if (Employee == null)
            {
                return NotFound();
            }
            _EmployeeRepository.DeleteEmployee(id);
            return RedirectToAction(nameof(Index));
        }

        //[HttpPost, ActionName("Delete")]
        //public IActionResult DeleteConfirmed(int id)
        //{
        //    _EmployeeRepository.DeleteEmployee(id);
        //    return RedirectToAction(nameof(Index));
        //}
    }
}