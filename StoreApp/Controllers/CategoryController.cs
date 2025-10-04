using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Repositories.Contracts;
using Services.Contracts;

namespace StoreApp.Controllers
{

    public class CategoryController : Controller
    {
        private IServiceManager _manager;

        public CategoryController(IServiceManager manager)
        {
            _manager = manager;
        }

        public IActionResult Index()
        {

            var model = _manager.CategoryService.GetAllCategories(false);
            return View(model);
        }


    }
}