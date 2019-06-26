using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TodoMVC.Web.Models;
using EntityFramework.Extensions;

namespace TodoMVC.Web.Controllers
{
    public class ToDoListModelsController : Controller
    {
        private TodoMVCWebContext db = new TodoMVCWebContext();
        ToDoListViewModel listViewModel = new ToDoListViewModel();
        ToDoListModels toDoList = new ToDoListModels();
        // GET: ToDoListModels
        public ActionResult Index()
        {
            ToDoListViewModel listViewModel = new ToDoListViewModel();
            listViewModel.toDoListModels = db.ToDoListModels.ToList();
            return View(listViewModel);
        }

        // POST: ToDoListModels/Index
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        [HttpPost]
        public ActionResult Index(bool status)
        {
            if (status == true)
            {
                var query = db.ToDoListModels.Where(x => x.Status == true).ToList();
                listViewModel.toDoListModels = query;
                return View("Index", listViewModel);
            }
            else
            {
                var query = db.ToDoListModels.Where(x => x.Status == false).ToList();
                listViewModel.toDoListModels = query;
                return View("Index", listViewModel);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ToDoListViewModel x)
        {
            if (ModelState.IsValid)
            {

                toDoList.Subject = x.toDoList.Subject;
                toDoList.Status = false;
                listViewModel.toDoList = toDoList;
                db.ToDoListModels.Add(listViewModel.toDoList);
                db.SaveChanges();


                return RedirectToAction("Index", listViewModel.toDoList);
            }

            return View();
        }


        public ActionResult Edit(ToDoListModels x)
        {
            listViewModel.toDoList = db.ToDoListModels.Find(x.Id);
            if (listViewModel.toDoList.Status == true)
            {
                listViewModel.toDoList.Status = false;
            }
            else
            {
                listViewModel.toDoList.Status = true;
            }
            db.SaveChanges();
            return RedirectToAction("Index", listViewModel);
        }


        // POST: ToDoListModels/Delete
        public ActionResult Delete(int id)
        {
            listViewModel.toDoList = db.ToDoListModels.Find(id);
            db.ToDoListModels.Remove(listViewModel.toDoList);
            db.SaveChanges();
            return RedirectToAction("Index", listViewModel);
        }

        [HttpPost]
        public ActionResult DeleteAll(string i)
        {
            var query = db.ToDoListModels.Where(x => x.Status == true).Delete();
            db.SaveChanges();
            return RedirectToAction("Index", query);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }   
    }
}
