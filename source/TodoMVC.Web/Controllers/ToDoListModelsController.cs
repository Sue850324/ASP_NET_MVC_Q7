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

        // GET: ToDoListModels
        public ActionResult Index()
        {
            return View(db.ToDoListModels.ToList());
        }


        // GET: ToDoListModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ToDoListModels/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Subject,Status")] ToDoListModels toDoListModels)
        {
            if (ModelState.IsValid)
            {
                db.ToDoListModels.Add(toDoListModels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(toDoListModels);
        }

        // GET: ToDoListModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ToDoListModels toDoListModels = db.ToDoListModels.Find(id);
            if (toDoListModels == null)
            {
                return HttpNotFound();
            }
            return View(toDoListModels);
        }

        // POST: ToDoListModels/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Subject,Status")] ToDoListModels toDoListModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(toDoListModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(toDoListModels);
        }

        // GET: ToDoListModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ToDoListModels toDoListModels = db.ToDoListModels.Find(id);
            if (toDoListModels == null)
            {
                return HttpNotFound();
            }
            return View(toDoListModels);
        }

        // POST: ToDoListModels/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            ToDoListModels toDoListModels = db.ToDoListModels.Find(id);
            db.ToDoListModels.Remove(toDoListModels);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteAll()
        {

            return View("DeleteAll", db.ToDoListModels.Where(x => x.Status == true).ToList());
        }

        [HttpPost]
        public ActionResult DeleteAll(string i)
        {
            var query = db.ToDoListModels.Where(x => x.Status == true).Delete();

            db.SaveChanges();

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
        public ActionResult Search()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Search(bool status)
        {
            if (status == true)
            {
                var query = db.ToDoListModels.Where(x => x.Status == true).ToList();
                return View(query);
            }
            else
            {
                var query = db.ToDoListModels.Where(x => x.Status == false).ToList();
                return View(query);
            }
        }

    }
}
