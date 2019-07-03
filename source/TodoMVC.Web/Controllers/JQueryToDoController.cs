using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using TodoMVC.Web.Infrastructure.Repository;
using TodoMVC.Web.Models;
using TodoMVC.Web.Infrastructure.Service;
using EntityFramework.Extensions;

namespace TodoMVC.Web.Controllers
{
    public class JQueryToDoController : Controller
    {
        private TodoMVCWebContext db = new TodoMVCWebContext();
        ToDoListViewModel listViewModel = new ToDoListViewModel();
        ToDoListModels toDoList = new ToDoListModels();

        public string CamelCase()
        {
           var setting = new JsonSerializerSettings
            {
                ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver()
            };
            var json = JsonConvert.SerializeObject(db.ToDoListModels.ToList(), Formatting.None, setting);
            return json;
        }
    
        // GET: JQueryToDo
        public ActionResult Index()
        {
         
            return View();
        }
        public JsonResult GetList()
        {
         
            return Json(CamelCase(), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult Add(string input)
        {
            new JQueryToDoRepository().Add(input);
            return Json(CamelCase(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Completed()
        {
         
            return Json(CamelCase(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Active()
        {
          
            return Json(CamelCase(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Clean()
        {
            new JQueryToDoRepository().Clean();
            return Json(CamelCase(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Change(int Id)
        {
            new JQueryToDoRepository().Change(Id);        
            return Json(CamelCase(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Cancel(int Id)
        {
            new JQueryToDoRepository().Cancel(Id);        
            return Json(CamelCase(), JsonRequestBehavior.AllowGet);
        }

    }
}