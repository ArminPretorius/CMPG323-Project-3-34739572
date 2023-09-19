﻿using System;
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

namespace Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        // GET: Orders
        public async Task<IActionResult> Index()
        {
            OrdersRepository ordersRepository = new OrdersRepository();

            var results = ordersRepository.GetAll();

            return View(results);
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            OrdersRepository ordersRepository = new OrdersRepository();

            if (id != null)
            {
                var result = ordersRepository.GetById(id.Value);

                return View(result);
            }
            else
            {
                return View(null);
            }
        }

        // GET: Orders/Create
        public IActionResult Create()
        {
            //Get the list of customers
            CustomersRepository customersRepository = new CustomersRepository();
            var customers = customersRepository.GetAll();
            ViewData["CustomerId"] = new SelectList(customers, "CustomerId", "CustomerId");
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderId,OrderDate,CustomerId,DeliveryAddress")] Order order)
        {
            CustomersRepository customersRepository = new CustomersRepository();
            var customers = customersRepository.GetAll();

            if (ModelState.IsValid)
            {
                OrdersRepository ordersRepository = new OrdersRepository();
                ordersRepository.Add(order);
                return RedirectToAction(nameof(Index));
            }

            ViewData["CustomerId"] = new SelectList(customers, "CustomerId", "CustomerId");
            return View(order);
        }

        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            OrdersRepository ordersRepository = new OrdersRepository();

            if (id != null)
            {
                var result = ordersRepository.GetById(id.Value);

                //Get the list of customers
                CustomersRepository customersRepository = new CustomersRepository();
                var customers = customersRepository.GetAll();
                ViewData["CustomerId"] = new SelectList(customers, "CustomerId", "CustomerId");

                return View(result);
            }
            else
            {
                return View(null);
            }
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderId,OrderDate,CustomerId,DeliveryAddress")] Order order)
        {
            CustomersRepository customersRepository = new CustomersRepository();
            var customers = customersRepository.GetAll();

            if (ModelState.IsValid)
            {
                OrdersRepository ordersRepository = new OrdersRepository();
                ordersRepository.Update(order);
                return RedirectToAction(nameof(Index));
            }

            ViewData["CustomerId"] = new SelectList(customers, "CustomerId", "CustomerId");
            return View(order);
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            OrdersRepository ordersRepository = new OrdersRepository();

            if (id != null)
            {
                var result = ordersRepository.GetById(id.Value);

                return View(result);
            }
            else
            {
                return View(null);
            }
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            OrdersRepository ordersRepository = new OrdersRepository();
            var order = ordersRepository.GetById(id);
            ordersRepository.Delete(order);
            return RedirectToAction(nameof(Index));
        }

        private bool OrderExists(int id)
        {
            OrdersRepository ordersRepository = new OrdersRepository();
            var order = ordersRepository.GetById(id);
            if (order != null)
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
