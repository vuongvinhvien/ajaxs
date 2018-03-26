using AjaxTable.Data;
using AjaxTable.Data.Models;
using System.Linq;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace AJAXTable.Controllers
{
    public class HomeController : Controller
    {
        private EmployeeDbContext _context;

        public HomeController()
        {
            _context = new EmployeeDbContext();
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult LoadData(int page, int pageSize = 3)
        {
            var model = _context.Employee
                .OrderByDescending(x=>x.CreatedDate)
                .Skip((page - 1) * pageSize)
                .Take(pageSize);
            int totalRow = _context.Employee.Count();
            return Json(new
            {
                data = model,
                total = totalRow,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Update(string model)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            Employee employee = serializer.Deserialize<Employee>(model);

            //save db
            var entity = _context.Employee.Find(employee.ID);
            entity.Salary = employee.Salary;
            return Json(new
            {
                status = true
            });
        }
    }
}