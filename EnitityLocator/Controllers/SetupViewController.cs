using EnitityLocator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain;


namespace EnitityLocator.Controllers
{
    public class SetupViewController : Controller
    {
        // GET: SetupView
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(SetupViewModel setupViewModel)
        {

            //identify the domain object by Category

            Type type=Locator.Instance.Locate(setupViewModel.Category);

            var bClass = (ISetupEntityCode)Activator.CreateInstance(type);

            return View(setupViewModel);
        }
    }
}