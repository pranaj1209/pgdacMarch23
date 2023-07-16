using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplications.Models;

namespace WebApplications.Controllers
{
    public class ProductsController : Controller
    {
        // GET: ProductsController
        public ActionResult Index()
        {
            List<Product> lstPro = Product.GetAllProduct();
            return View(lstPro);
        }

        // GET: ProductsController/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
                return NotFound();

            Product obj = Product.GetSingleProduct(id.Value);

            return View(obj);
        }

        // GET: ProductsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product obj)
        {
            try
            {
                Product.InsertProduct(obj);
                ViewBag.message = "Success";
                return View();
                //return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.message = ex.Message;
                return View();
            }
        }

        // GET: ProductsController/Edit/5
        public ActionResult Edit(int? id)
        {
            if(id == null)
                return NotFound();
            Product obj = Product.GetSingleProduct(id.Value);

            return View(obj);
        }

        // POST: ProductsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product obj, int id, IFormCollection collection)
        {
            try
            {
                Product.UpdateProduct(obj);
                ViewBag.message = "Update Successfully";
                return View();
                //return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                ViewBag.message = ex.Message;
                return View();
            }
        }

        // GET: ProductsController/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return NotFound();
            Product obj = Product.GetSingleProduct(id.Value);

            return View(obj);
        }

        // POST: ProductsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                Product.DeleteProduct(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
