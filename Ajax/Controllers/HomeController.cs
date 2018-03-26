using Ajax.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace AJAXTable.Controllers
{
    public class HomeController : Controller
    {
        List<EmployeeModel> listEmployee = new List<EmployeeModel>() {
            new EmployeeModel()
            {
                ID = 1,
                Name = "Nguyen Van A",
                Salary = 2000000,
                Status = true
            },
            new EmployeeModel()
            {
                ID = 2,
                Name = "Nguyen Van B",
                Salary = 3000000,
                Status = true
            },
            new EmployeeModel()
            {
                ID = 3,
                Name = "Nguyen Van C",
                Salary = 5000000,
                Status = true
            },
              new EmployeeModel()
            {
                ID = 4,
                Name = "Nguyen Van D",
                Salary = 42342,
                Status = true
            },
                new EmployeeModel()
            {
                ID = 5,
                Name = "Nguyen Van EC",
                Salary = 54342,
                Status = true
            },
                  new EmployeeModel()
            {
                ID = 6,
                Name = "Nguyen Van F",
                Salary = 504300,
                Status = true
            },
                    new EmployeeModel()
            {
                ID = 7,
                Name = "Nguyen Van G",
                Salary = 5300,
                Status = true
            },
                      new EmployeeModel()
            {
                ID = 8,
                Name = "Nguyen Van H",
                Salary = 6535232,
                Status = true
            },
        };

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult LoadData(int page, int pageSize = 3)
        {
            var model = listEmployee.Skip((page - 1) * pageSize).Take(pageSize);
            int totalRow = listEmployee.Count;
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
            EmployeeModel employee = serializer.Deserialize<EmployeeModel>(model);

            //save db
            var entity = listEmployee.Single(x => x.ID == employee.ID);
            entity.Salary = employee.Salary;
            return Json(new
            {
                status = true
            });
        }
    }
}