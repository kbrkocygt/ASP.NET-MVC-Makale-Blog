using Asp_Net_MVC_Blog.Models.sınıflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Asp_Net_MVC_Blog.Controllers
{
    public class AdminController : Controller //controllerden miras aldı
    {
        private Contex db = new Contex();
        // GET: Admin
        public ActionResult Index()
        {

            return View();
        }
        
            
            
        
       

    }
}

