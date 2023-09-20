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
    public class CustomersController : Controller
    {
        //Declares the service that will be used by the controller
        private readonly ICustomersService _customersService;

        //Constructor that will be used to inject the service into the controller
        public CustomersController(ICustomersService customersService)
        {
            this._customersService = customersService;
        }

        // GET: Customers
        public async Task<IActionResult> Index()
        {
            return View(_customersService.GetAllCustomers().ToList());
        }

        // GET: Customers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id != null)
            {
                var result = _customersService.GetCustomerById(id.Value);

                return View(result);
            }
            else
            {
                return NotFound();
            }
        }

        // GET: Customers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CustomerId,CustomerTitle,CustomerName,CustomerSurname,CellPhone")] Customer customer)
        {
            _customersService.AddCustomer(customer);
            return RedirectToAction(nameof(Index));
        }

        // GET: Customers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null)
            {
                var result = _customersService.GetCustomerById(id.Value);

                return View(result);
            }
            else
            {
                return NotFound();
            }
        }

        // POST: Customers/Edit/5
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
                _customersService.UpdateCustomer(customer);
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        // GET: Customers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                var result = _customersService.GetCustomerById(id.Value);

                return View(result);
            }
            else
            {
                return NotFound();
            }
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = _customersService.GetCustomerById(id);
            _customersService.DeleteCustomer(product);
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerExists(int id)
        {
            return _customersService.GetAllCustomers().Any(e => e.CustomerId == id);
        }
    }
}
