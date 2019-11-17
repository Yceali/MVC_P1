using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_P1.Models.DBModels;
using MVC_P1.Models.Repository;

namespace MVC_P1.Controllers
{
    public class CategoryController : Controller
    {
        CategoryRepository categoryRepository = new CategoryRepository(new NorthwindEntities());
        // GET: Category
        public ActionResult Index()
        {
            return View(categoryRepository.GetAll());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Kategoriler model)
        {
            if (ModelState.IsValid)
            {
                categoryRepository.Save(model);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            return View(categoryRepository.Get(id));
        }

        [HttpPost]
        public ActionResult Edit(Kategoriler model)
        {
            if (ModelState.IsValid)
            {
                categoryRepository.Update(model);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            return View(categoryRepository.Get(id));
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteCat(int id)
        {
            if (ModelState.IsValid)
            {
                categoryRepository.Delete(categoryRepository.Get(id));
            }

            return RedirectToAction("Index");
        }
    }
}