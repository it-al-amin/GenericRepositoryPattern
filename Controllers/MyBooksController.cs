using GenericRepositoryPattern.Models;
using GenericRepositoryPattern.Models.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GenericRepositoryPattern.Controllers
{
    public class MyBooksController : Controller
    {
        // GET: MyBooks
        private IRepository<Book> interfaceObj;
        public MyBooksController()
        {
            this.interfaceObj = new RepositoryImpl<Book>();
        }
        public ActionResult Index()
        {
            return View(from m in interfaceObj.GetModel() select m);
        }

        // GET: MyBooks/Details/5
        public ActionResult Details(int id)
        {
            
            return View(interfaceObj.GetModelById(id));
        }

        // GET: MyBooks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MyBooks/Create
        [HttpPost]
        public ActionResult Create(Book collection)
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

        // GET: MyBooks/Edit/5
        public ActionResult Edit(int id)
        {
            return View(interfaceObj.GetModelById(id));
        }

        // POST: MyBooks/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Book collection)
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

        // GET: MyBooks/Delete/5
        public ActionResult Delete(int id)
        {
            return View(interfaceObj.GetModelById(id));
        }

        // POST: MyBooks/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Book collection)
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
