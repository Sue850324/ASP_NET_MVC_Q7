using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TodoMVC.Web.Infrastructure.Interface;
using TodoMVC.Web.Models;

namespace TodoMVC.Web.Infrastructure.Service
{
    public class ToDoListService: IToDoListService
    {
        private TodoMVCWebContext db = new TodoMVCWebContext();
        ToDoListViewModel listViewModel = new ToDoListViewModel();
        ToDoListModels toDoList = new ToDoListModels();
        public void CompareStatus(bool status)
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
        }
    }
}