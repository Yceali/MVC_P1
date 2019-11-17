using MVC_P1.Models.DBModels;
using MVC_P1.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_P1.Controllers
{
    public class ProductsController : Controller
    {
        ProductsRepository productsRepository = new ProductsRepository(new NorthwindEntities());
        CategoryRepository categoryRepository = new CategoryRepository(new NorthwindEntities());
        // GET: Products
        public ActionResult Index()
        {            
            return View(productsRepository.GetAll());
        }

        public ActionResult Create()
        {
            ViewBag.Kategoriler = categoryRepository.GetAll();
            ViewBag.Tedarikciler = productsRepository.GetTedarikciler();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Urunler urun)
        {
            if (ModelState.IsValid)
            {
                productsRepository.Save(urun);
            }

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int Id)
        {
            ViewBag.Kategoriler = categoryRepository.GetAll();
            ViewBag.Tedarikciler = productsRepository.GetTedarikciler();
            return View(productsRepository.Get(Id));
        }

        [HttpPost]
        public ActionResult Edit(Urunler urun)
        {
            if (ModelState.IsValid)
            {
                productsRepository.Update(urun);
            }

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            ViewBag.Kategoriler = categoryRepository.GetAll();
            ViewBag.Tedarikciler = productsRepository.GetTedarikciler();

            Urunler urun = productsRepository.Get(id);
            return View(urun);
        }

        [HttpPost,ActionName("Delete")]
        public ActionResult DeleteUrun(int id)
        {
            if (ModelState.IsValid)
            {
                productsRepository.Delete(productsRepository.Get(id));
            }
            return RedirectToAction("Index");
        }


    }
}