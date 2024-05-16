using GenericRepositoryPattern.Models;
using GenericRepositoryPattern.Models.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GenericRepositoryPattern.Controllers
{
    public class LoginsController : Controller
    {
        // GET: Logins
        private IRepository<Login> interfaceObj;
        public LoginsController()
        {
            this.interfaceObj = new RepositoryImpl<Login>();
        }
        public ActionResult Index()
        {
            return View(from m in interfaceObj.GetModel() select m);
        }

        // GET: Logins/Details/5
        public ActionResult Details(int id)
        {
            Login model = interfaceObj.GetModelById(id);
            if (model == null)
                return HttpNotFound();

            return View(model);
        }

        // GET: Logins/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Logins/Create
        [HttpPost]
        public ActionResult Create(Login collection)
        {
            try
            {
                // TODO: Add insert logic here
                interfaceObj.InsertModel(collection);
                interfaceObj.Save();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Logins/Edit/5
        public ActionResult Edit(int id)
        {
            Login model = interfaceObj.GetModelById(id);
            if (model == null)
                return HttpNotFound();

            return View(model);
        }

        // POST: Logins/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Login collection)
        {
            try
            {
                // TODO: Add update logic here
                interfaceObj.UpdateModel(collection);
                interfaceObj.Save();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Logins/Delete/5
        public ActionResult Delete(int id)
        {
            Login model = interfaceObj.GetModelById(id);
            if (model == null)
                return HttpNotFound();

            return View(model);
        }

        // POST: Logins/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Login collection)
        {
            try
            {
                // TODO: Add delete logic here
                interfaceObj.DeleteModel(id);
                interfaceObj.Save();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
