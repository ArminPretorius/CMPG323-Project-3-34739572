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
using EcoPower_Logistics.Services;

namespace Controllers
{
    [Authorize]
    public class OrderDetailsController : Controller
    {
        //Declares the service that will be used by the controller
        private readonly IOrderDetailsService _orderDetailsService;
        private readonly IOrdersService _ordersService;

        //Constructor that will be used to inject the service into the controller
        public OrderDetailsController(IOrdersService ordersService, IOrderDetailsService orderDetailsService)
        {
            this._orderDetailsService = orderDetailsService;
            this._ordersService = ordersService;
        }

        // GET: OrderDetails
        public async Task<IActionResult> Index()
        {
            return View(_orderDetailsService.GetAllOrderDetails().ToList());
        }

        // GET: OrderDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id != null)
            {
                var result = _orderDetailsService.GetOrderDetailsById(id.Value);

                return View(result);
            }
            else
            {
                return NotFound();
            }
        }

        // GET: OrderDetails/Create
        public IActionResult Create()
        {
            var orders = _ordersService.GetAllOrders();
            ViewData["OrderId"] = new SelectList(orders, "OrderId", "OrderId");

            return View();
        }

        // POST: OrderDetails/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderDetailsId,OrderId,ProductId,Quantity,Discount")] OrderDetail orderDetail)
        {
            if (ModelState.IsValid)
            {
                _orderDetailsService.AddOrderDetails(orderDetail);
                return RedirectToAction(nameof(Index));
            }
            ViewData["OrderId"] = new SelectList(_ordersService.GetAllOrders(), "OrderId", "OrderId", orderDetail.OrderId);
            return View(orderDetail);
        }

        // GET: OrderDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var orders = _ordersService.GetAllOrders();
            ViewData["OrderId"] = new SelectList(orders, "OrderId", "OrderId");
            if (id == null)
            {
                return NotFound();
            }

            var orderDetail = _orderDetailsService.GetOrderDetailsById(id.Value);
            if (orderDetail == null)
            {
                return NotFound();
            }
            return View(orderDetail);
        }

        // POST: OrderDetails/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderDetailsId,OrderId,ProductId,Quantity,Discount")] OrderDetail orderDetail)
        {
            if (id != orderDetail.OrderDetailsId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _orderDetailsService.UpdateOrderDetails(orderDetail);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderDetailExists(orderDetail.OrderDetailsId))
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
            var orders = _ordersService.GetAllOrders();
            ViewData["OrderId"] = new SelectList(orders, "OrderId", "OrderId", orderDetail.OrderId);
            return View(orderDetail);
        }

        // GET: OrderDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var orders = _ordersService.GetAllOrders();
            ViewData["OrderId"] = new SelectList(orders, "OrderId", "OrderId");
            if (id == null)
            {
                return NotFound();
            }

            var orderDetail = _orderDetailsService.GetOrderDetailsById(id.Value);
            if (orderDetail == null)
            {
                return NotFound();
            }

            return View(orderDetail);
        }

        // POST: OrderDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var orderDetail = _orderDetailsService.GetOrderDetailsById(id);
            _orderDetailsService.DeleteOrderDetails(orderDetail);
    
            return RedirectToAction(nameof(Index));
        }

        private bool OrderDetailExists(int id)
        {
            return _orderDetailsService.GetAllOrderDetails().Any(e => e.OrderDetailsId == id);
        }
    }
}
