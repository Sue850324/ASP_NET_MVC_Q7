using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TodoMVC.Web.Controllers
{
    public class JQueryToDoController : Controller
    {
        // GET: JQueryToDo
        public ActionResult Index()
        {
            return View();
        }
    }
}