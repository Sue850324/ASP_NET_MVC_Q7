using EntityFramework.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TodoMVC.Web.Infrastructure.Interface;
using TodoMVC.Web.Models;

namespace TodoMVC.Web.Infrastructure.Repository
{
    public class ToDoListRepository : IToDoListRepository
    {
        private TodoMVCWebContext db = new TodoMVCWebContext();
        ToDoListViewModel listViewModel = new ToDoListViewModel();
        ToDoListModels toDoList = new ToDoListModels();
        public void Create(ToDoListViewModel x)
        {
            toDoList.Subject = x.toDoList.Subject;
            toDoList.Status = false;
            listViewModel.toDoList = toDoList;
            db.ToDoListModels.Add(listViewModel.toDoList);
            db.SaveChanges();
        }
        public void Edit(ToDoListModels x)
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

        }
        public void Delete(int id)
        {

            listViewModel.toDoList = db.ToDoListModels.Find(id);
            db.ToDoListModels.Remove(listViewModel.toDoList);
            db.SaveChanges();

        }
        public void DeleteAll(string i)
        {

            var query = db.ToDoListModels.Where(x => x.Status == true).Delete();
            db.SaveChanges();

        }


    }
}