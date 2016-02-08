using EnitityLocator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain;
using EntityLocatorData;
using System.Data.Entity;

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
        public ActionResult Save(SetupViewModel setupViewModel)
        {

            //identify the domain object by Category

            Type type=SetupCodeEntityResolver.Instance.Resolve(setupViewModel.Category);

            var setupEntity = (ISetupEntityCode) Activator.CreateInstance(type);


            EntityLocatorDbContext dbcontext = new EntityLocatorDbContext();

            // setupEntity = Convert.ChangeType(setupEntity, type);

            //  CourtCode setupEntity = new CourtCode();


            //use auto mapper
            setupEntity.Id = setupViewModel.Id;
            setupEntity.Code = setupViewModel.Code;
            setupEntity.Description = setupViewModel.Description;
            setupEntity.StartDate = Convert.ToDateTime(setupViewModel.StartDate);
            setupEntity.EndDate = Convert.ToDateTime(setupViewModel.EndDate);
            //dbcontext.Set(type);
            //dbcontext.Entry(setupEntity);
            //dbcontext.SaveChanges();

            var dbSet=dbcontext.Set(setupEntity.GetType()).Add(setupEntity);

            dbcontext.SaveChanges();

            return RedirectToAction("Edit",new { Id = setupEntity.Id, Category = setupViewModel.Category });
        }

        public ActionResult Edit(int Id,string Category)
        {




            //Build an object for ESB and publish

            




            Type type = SetupCodeEntityResolver.Instance.Resolve(Category);

            var setupEntity = (ISetupEntityCode)Activator.CreateInstance(type);


            EntityLocatorDbContext dbcontext = new EntityLocatorDbContext();

            var entitySet  = dbcontext.Set(setupEntity.GetType());

            var queryables = entitySet as IQueryable<ISetupEntityCode>;

            var codes = queryables.FirstOrDefault<ISetupEntityCode>(x => x.Id == Id);

            var setupViewModel = new SetupViewModel
            {
                Category = Category,
                Code = codes.Code,
                Id = codes.Id,
                Description = codes.Description,
                StartDate = codes.StartDate,
                EndDate = codes.EndDate
            };



            return View("Index", setupViewModel);


        }
    }
}