using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoMVC.Web.Models;

namespace TodoMVC.Web.Infrastructure.Interface
{
    interface IToDoListRepository
    {
        void Create(ToDoListViewModel doListViewModel);
        void Edit(ToDoListModels doListModel);
        void Delete(int id);
        void DeleteAll(string i);

    }
}
