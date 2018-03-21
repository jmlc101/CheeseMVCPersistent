using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CheeseMVC.Data;
using Microsoft.AspNetCore.Mvc;

namespace CheeseMVC.Controllers
{
    public class MenuController : Controller
    {
        private CheeseDbContext context;

        public MenuController(CheeseDbContext dbContext)
        {
            context = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}