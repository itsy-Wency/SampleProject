using Microsoft.AspNetCore.Mvc;
using SampleProject.Models;

namespace SampleProject.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ProductRepository _repository =
            new ProductRepository();

        // READ: Display all products
        public IActionResult Index()
        {
            var products = _repository.GetAll();
            return View(products);
        }

        // READ: Display one product
        public IActionResult Details(int id)
        {
            var product = _repository.GetById(id);

            if (product == null)
                return NotFound();

            return View(product);
        }

        // CREATE: Display the form
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // CREATE: Save the submitted product
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _repository.Add(product);
                return RedirectToAction(nameof(Index));
            }

            return View(product);
        }

        // UPDATE: Display the edit form
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var product = _repository.GetById(id);

            if (product == null)
                return NotFound();

            return View(product);
        }

        // UPDATE: Save changes
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                var existing = _repository.GetById(product.Id);

                if (existing == null)
                    return NotFound();

                _repository.Update(product);
                return RedirectToAction(nameof(Index));
            }

            return View(product);
        }

        // DELETE: Display confirmation
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var product = _repository.GetById(id);

            if (product == null)
                return NotFound();

            return View(product);
        }

        // DELETE: Remove the product
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var product = _repository.GetById(id);

            if (product == null)
                return NotFound();

            _repository.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}