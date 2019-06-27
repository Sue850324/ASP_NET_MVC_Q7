using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TodoMVC.Web.Infrastructure.Interface
{
    interface IToDoListService
    {
        void CompareStatus(bool status);
    }
}