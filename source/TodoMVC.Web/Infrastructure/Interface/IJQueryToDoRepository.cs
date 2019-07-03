using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoMVC.Web.Models;

namespace TodoMVC.Web.Infrastructure.Interface
{
    interface IJQueryToDoRepository
    {
        void Add(string input);
        void Change(int Id);
        void Clean();
        void Cancel(int Id);
    }
}
