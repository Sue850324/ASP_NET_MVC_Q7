using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TodoMVC.Web.Models;
using TodoMVC.Web.Infrastructure.Repository;
using TodoMVC.Web.Infrastructure.Service;
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
            listViewModel.toDoListModels = db.ToDoListModels.ToList();
            return View(listViewModel);
        }

        // POST: ToDoListModels/Indexep 
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        [HttpPost]
        public ActionResult Index(bool status)
        {
            if (status == true)
            {
                var query = db.ToDoListModels.Where(x => x.Status == true).ToList();
                listViewModel.toDoListModels = query;

            }
            else
            {
                var query = db.ToDoListModels.Where(x => x.Status == false).ToList();
                listViewModel.toDoListModels = query;

            }
            return View("Index", listViewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ToDoListViewModel x)
        {
            if (ModelState.IsValid)
            {
                new ToDoListRepository().Create(x);
                return RedirectToAction("Index", listViewModel.toDoList);
            }
                return View();
        }


        public ActionResult Edit(ToDoListModels x)
        {
            new ToDoListRepository().Edit(x);
            return RedirectToAction("Index", listViewModel);
        }

        public ActionResult Delete(int id)
        {
            new ToDoListRepository().Delete(id);
            return RedirectToAction("Index", listViewModel);
        }

        [HttpPost]
        public ActionResult DeleteAll(string i)
        {
            new ToDoListRepository().DeleteAll(i);
            return RedirectToAction("Index");
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
