using EnitityLocator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain;
using EntityLocatorData;

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

            Type type=SetupCodeEntityResolver.Instance.Resolve(setupViewModel.Category);

            var setupEntity = (ISetupEntityCode) Activator.CreateInstance(type);


            EntityLocatorDbContext dbcontext = new EntityLocatorDbContext();

            // setupEntity = Convert.ChangeType(setupEntity, type);

            //CourtCode setupEntity = new CourtCode();

            setupEntity.Code = setupViewModel.Code;
            setupEntity.Description = setupViewModel.Description;

            //dbcontext.Set(type);
            dbcontext.Entry(setupEntity);
            dbcontext.SaveChanges();
            

            return View(setupViewModel);
        }
    }
}