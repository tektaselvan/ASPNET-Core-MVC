using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services.Contracts;

namespace StoreApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrderController : Controller
    {
        private readonly IServiceManager _manager;

        public OrderController(IServiceManager manager)
        {
            _manager = manager;
        }

        public IActionResult Index()
        {
            var order = _manager.OrderService.Orders;
            return View(order);
        }

        [HttpPost]
        public IActionResult Complete([FromForm] int id)
        {
            _manager.OrderService.Complete(id);
            return RedirectToAction("Index");
        }

    }
}