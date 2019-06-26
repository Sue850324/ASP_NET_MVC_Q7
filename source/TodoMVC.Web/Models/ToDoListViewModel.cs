using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TodoMVC.Web.Models
{
    public class ToDoListViewModel
    {
        public ToDoListModels toDoList { set; get; }
        public List<ToDoListModels> toDoListModels { set; get; }
    }
}