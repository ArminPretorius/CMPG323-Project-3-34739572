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

namespace Controllers
{
    [Authorize]
    public class ProductsController : Controller
    {
        // GET: Products
        public async Task<IActionResult> Index()
        {
            ProductsRepository productsRepository = new ProductsRepository();

            var results = productsRepository.GetAll();

            return View(results);
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            ProductsRepository productsRepository = new ProductsRepository();

            if (id != null)
            {
                var result = productsRepository.GetById(id.Value);

                return View(result);
            }
            else
            { 
                return View(null); 
            }
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductId,ProductName,ProductDescription,UnitsInStock")] Product product)
        {
            if (ModelState.IsValid)
            {
                ProductsRepository productsRepository = new ProductsRepository();
                productsRepository.Add(product);
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ProductsRepository productsRepository = new ProductsRepository();

            if (id != null)
            {
                var result = productsRepository.GetById(id.Value);

                return View(result);
            }
            else
            {
                return View(null);
            }
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
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
                try
                {
                    ProductsRepository productsRepository = new ProductsRepository();
                    productsRepository.Update(product);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.ProductId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            ProductsRepository productsRepository = new ProductsRepository();

            if (id != null)
            {
                var result = productsRepository.GetById(id.Value);

                return View(result);
            }
            else
            {
                return View(null);
            }
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            ProductsRepository productsRepository = new ProductsRepository();
            var product = productsRepository.GetById(id);
            productsRepository.Delete(product);
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            ProductsRepository productsRepository = new ProductsRepository();
            var result = productsRepository.GetById(id);

            if (result != null)
            {
                return true;
            }
            else
            {
                return false;
            }   
        }
    }
}
