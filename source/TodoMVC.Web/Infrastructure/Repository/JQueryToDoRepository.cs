using EntityFramework.Extensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TodoMVC.Web.Infrastructure.Interface;
using TodoMVC.Web.Models;

namespace TodoMVC.Web.Infrastructure.Repository
{
    public class JQueryToDoRepository : IJQueryToDoRepository
    {
        private TodoMVCWebContext db = new TodoMVCWebContext();
        ToDoListViewModel listViewModel = new ToDoListViewModel();
        ToDoListModels toDoList = new ToDoListModels();
        public void Add(string input)
        {
            toDoList.Subject = input;
            toDoList.Status = false;
            listViewModel.toDoList = toDoList;
            db.ToDoListModels.Add(listViewModel.toDoList);
            db.SaveChanges();
        }
        public void Change(int Id)
        {
            var query = db.ToDoListModels.Where(x => x.Id == Id).FirstOrDefault();
            if (query.Status == false)
            {
                query.Status = true;
            }
            else
            {
                query.Status = false;
            }
            db.SaveChanges();
        }
        public void Clean()
        {
            var query = db.ToDoListModels.Where(x => x.Status == true).Delete();
            db.SaveChanges();

        }
        public void Cancel(int Id)
        {
            var query = db.ToDoListModels.Where(x => x.Id == Id).FirstOrDefault();
            db.ToDoListModels.Remove(query);
            db.SaveChanges();
        }
    }
}