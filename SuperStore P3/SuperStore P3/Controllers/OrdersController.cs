using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Models;
using Data;
using EcoPower_Logistics.Repository;
using EcoPower_Logistics.Services;

namespace Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        //Declares the service that will be used by the controller
        private readonly IOrdersService _ordersService;
        private readonly ICustomersService _customersService;
        private readonly IProductsService _productsService;

        //Constructor that will be used to inject the service into the controller
        public OrdersController(IOrdersService ordersService, ICustomersService customersService, IProductsService productsService)
        {
            this._ordersService = ordersService;
            this._customersService = customersService;
            this._productsService = productsService;
        }

        // GET: Orders
        public async Task<IActionResult> Index()
        {
            return View(_ordersService.GetAllOrders().ToList());
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id != null)
            {
                var result = _ordersService.GetOrderById(id.Value);

                return View(result);
            }
            else
            {
                return NotFound();
            }
        }

        // GET: Orders/Create
        public IActionResult Create()
        {
            var customers = _customersService.GetAllCustomers();
            ViewData["CustomerId"] = new SelectList(customers, "CustomerId", "CustomerId");

            return View();
        }

        // POST: Orders/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderId,OrderDate,CustomerId,DeliveryAddress")] Order order)
        {
            _ordersService.AddOrder(order);
            return RedirectToAction(nameof(Index));
        }

        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var customers = _customersService.GetAllCustomers();
            ViewData["CustomerId"] = new SelectList(customers, "CustomerId", "CustomerId");

            if (id != null)
            {
                var result = _ordersService.GetOrderById(id.Value);

                return View(result);
            }
            else
            {
                return NotFound();
            }
        }

        // POST: Orders/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderId,OrderDate,CustomerId,DeliveryAddress")] Order order)
        {
            if (id != order.OrderId)
            {
                return NotFound();
            }

            _ordersService.UpdateOrder(order);

            return RedirectToAction(nameof(Index));
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                var result = _ordersService.GetOrderById(id.Value);

                return View(result);
            }
            else
            {
                return NotFound();
            }
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var order = _ordersService.GetOrderById(id);
            _ordersService.DeleteOrder(order);
            return RedirectToAction(nameof(Index));
        }

        private bool OrderExists(int id)
        {
            return _ordersService.GetAllOrders().Any(e => e.CustomerId == id);
        }
    }
}
