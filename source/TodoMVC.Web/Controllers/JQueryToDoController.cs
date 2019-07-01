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
    
        // GET: JQueryToDo
        public ActionResult Index()
        {
         
            return View();
        }
        public JsonResult GetList()
        {
            string json = JsonConvert.SerializeObject(db.ToDoListModels.ToList());
            return Json(json,JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult Add(string input)
        {
            toDoList.Subject = input;
            toDoList.Status = false;
            listViewModel.toDoList = toDoList;
            db.ToDoListModels.Add(listViewModel.toDoList);
            db.SaveChanges();
            string json = JsonConvert.SerializeObject(db.ToDoListModels.ToList());
            return Json(json, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Completed()
        {
            string json = JsonConvert.SerializeObject(db.ToDoListModels.ToList());
            return Json(json, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Active()
        {
            string json = JsonConvert.SerializeObject(db.ToDoListModels.ToList());
            return Json(json, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Clean()
        {
            var query = db.ToDoListModels.Where(x => x.Status == true).Delete();
            db.SaveChanges();
            string json = JsonConvert.SerializeObject(db.ToDoListModels.ToList());
            return Json(json, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Change(int Id)
        {
            var query = db.ToDoListModels.Where(x => x.Id == Id).FirstOrDefault();
            if (query.Status == true)
            {
                query.Status = false;
            }
            else
            {
                  query.Status = true;
            }
            db.SaveChanges();
            string json = JsonConvert.SerializeObject(db.ToDoListModels.ToList());
            return Json(json, JsonRequestBehavior.AllowGet);
        }
     
        public JsonResult Cancel(int Id)
        {
            var query = db.ToDoListModels.Where(x => x.Id == Id).FirstOrDefault();
            db.ToDoListModels.Remove(query);
            db.SaveChanges();
            string json = JsonConvert.SerializeObject(db.ToDoListModels.ToList());
            return Json(json, JsonRequestBehavior.AllowGet);
        }

     
    }
}