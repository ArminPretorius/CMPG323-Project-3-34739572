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
    public class CustomersController : Controller
    {
        private readonly SuperStoreContext _context;

        public CustomersController(SuperStoreContext context)
        {
            _context = context;
        }

        // GET: Customers
        public async Task<IActionResult> Index()
        {
            CustomersRepository customersRepository = new CustomersRepository();

            var results = customersRepository.GetAll();

            return View(results);
        }

        // GET: Customers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            CustomersRepository customersRepository = new CustomersRepository();

            if (id != null)
            {
                var result = customersRepository.GetById(id.Value);

                return View(result);
            }
            else
            {
                return View(null);
            }
        }

        // GET: Customers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CustomerId,CustomerTitle,CustomerName,CustomerSurname,CellPhone")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                CustomersRepository customersRepository = new CustomersRepository();
                customersRepository.Add(customer);
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        // GET: Customers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            CustomersRepository customersRepository = new CustomersRepository();

            if (id != null)
            {
                var result = customersRepository.GetById(id.Value);

                return View(result);
            }
            else
            {
                return View(null);
            }
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CustomerId,CustomerTitle,CustomerName,CustomerSurname,CellPhone")] Customer customer)
        {
            if (id != customer.CustomerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                CustomersRepository customersRepository = new CustomersRepository();
                customersRepository.Update(customer);
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        // GET: Customers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            CustomersRepository customersRepository = new CustomersRepository();

            if (id != null)
            {
                var result = customersRepository.GetById(id.Value);

                return View(result);
            }
            else
            {
                return View(null);
            }
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            CustomersRepository customersRepository = new CustomersRepository();
            var customer = customersRepository.GetById(id);
            customersRepository.Delete(customer);
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerExists(int id)
        {
            CustomersRepository customersRepository = new CustomersRepository();
            var result = customersRepository.GetById(id);

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
