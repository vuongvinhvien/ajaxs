using Ajax.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Ajax.Controllers
{
    public class HomeController : Controller
    {
        List<EmployeeModel> listEmployee = new List<EmployeeModel>() {
            new EmployeeModel()
        {
                Id = 1,
                Name = "Nguyen Van A",
                Salary = 1000,
                Status = false,
            },
            new EmployeeModel()
        {
                Id = 2,
                Name = "Nguyen Van B",
                Salary = 20800,
                Status = true,
            },
            new EmployeeModel()
        {
                Id = 3,
                Name = "Nguyen Van c",
                Salary = 306400,
                Status = true,
            },
                        new EmployeeModel()
        {
                Id = 4,
                Name = "Nguyen Van D",
                Salary = 305500,
                Status = true,
            },
            new EmployeeModel()
        {
                Id = 5,
                Name = "Nguyen Van E",
                Salary = 30300,
                Status = true,
            },
            new EmployeeModel()
        {
                Id = 6,
                Name = "Nguyen Van F",
                Salary = 30700,
                Status = true,
            },
            new EmployeeModel()
        {
                Id = 7,
                Name = "Nguyen Van G",
                Salary = 36000,
                Status = true,
            },
            new EmployeeModel()
        {
                Id = 8,
                Name = "Nguyen Van c",
                Salary = 35000,
                Status = true,
            },
            new EmployeeModel()
        {
                Id = 9,
                Name = "Nguyen Van c",
                Salary = 30400,
                Status = true,
            },



    };

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult LoadData()
        {
            return Json(new
            {
                data = listEmployee,
                status = true,
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Update(string model)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            EmployeeModel employee = serializer.Deserialize<EmployeeModel>(model);
            //save dtbase
            var entity = listEmployee.Single(x => x.Id == employee.Id);
            entity.Salary = employee.Salary;
            return Json(new

            {
                status = true,
            });
        }
    }
}