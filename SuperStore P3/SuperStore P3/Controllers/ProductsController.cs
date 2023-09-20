using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Data;
using Models;
using EcoPower_Logistics.Repository;
using EcoPower_Logistics.Services; 

namespace Controllers
{
    [Authorize]
    public class ProductsController : Controller
    {
        //Declares the service that will be used by the controller
        private readonly IProductsService _productsService;
        
        //Constructor that will be used to inject the service into the controller
        public ProductsController(IProductsService productsService)
        {
            this._productsService = productsService;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            return View(_productsService.GetAllProducts().ToList());
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id != null)
            {
                var result = _productsService.GetProductById(id.Value);

                return View(result);
            }
            else
            {
                return NotFound();
            }
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductId,ProductName,ProductDescription,UnitsInStock")] Product product)
        {
            _productsService.AddProduct(product);
            return RedirectToAction(nameof(Index));
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null)
            {
                var result = _productsService.GetProductById(id.Value);

                return View(result);
            }
            else
            {
                return NotFound();
            }
        }

        // POST: Products/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductId,ProductName,ProductDescription,UnitsInStock")] Product product)
        {
            if (id != product.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _productsService.UpdateProduct(product);
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                var result = _productsService.GetProductById(id.Value);

                return View(result);
            }
            else
            {
                return NotFound();
            }
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = _productsService.GetProductById(id);
            _productsService.DeleteProduct(product);
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _productsService.GetAllProducts().Any(e => e.ProductId == id);
        }
    }
}
