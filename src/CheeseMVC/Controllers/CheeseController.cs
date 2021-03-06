﻿using Microsoft.AspNetCore.Mvc;
using CheeseMVC.Models;
using System.Collections.Generic;
using CheeseMVC.ViewModels;
using CheeseMVC.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;
// TODO -1- its Time for final-touches
namespace CheeseMVC.Controllers
{
    public class CheeseController : Controller
    {
        private CheeseDbContext context;

        public CheeseController(CheeseDbContext dbContext)
        {
            context = dbContext;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {// TODO - Changed to include "include" based after video...
            IList<Cheese> cheeses = context.Cheeses.Include(c => c.Category).ToList();

            return View(cheeses);
        }

        public IActionResult Add()
        {
            //////////////////////////////////////////////////////
            int categoryCount = context.Categories.Count();
            if (categoryCount == 0)
            {
                CheeseCategory defaultCategory1 = new CheeseCategory { Name = "Hard" };
                CheeseCategory defaultCategory2 = new CheeseCategory { Name = "Soft" };
                CheeseCategory defaultCategory3 = new CheeseCategory { Name = "Fake" };
                context.Categories.Add(defaultCategory1);// TODO - Can I refractor?
                context.Categories.Add(defaultCategory2);
                context.Categories.Add(defaultCategory3);
                context.SaveChanges();
            }
            //////////////////////////////////////////////////////
            
            // TODO - Changed as per video...
            AddCheeseViewModel addCheeseViewModel = new AddCheeseViewModel(context.Categories.ToList());
            return View(addCheeseViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddCheeseViewModel addCheeseViewModel)
        {
            //This "debugitem" is to watch in debugger.
            //var debugitem = (context.Categories.First(c => c.Name == (addCheeseViewModel.Name)).ID);
            var debugitem2 = context.Categories;

            if (ModelState.IsValid)
            {
                // TODO - added this as per video....
                // TODO - IMPORTANT, remove "Equals" and replace the "==" that was originally there!!!!! Or rewrite Equals????
                CheeseCategory newCheeseCategory =
                    context.Categories.Single(c => c.ID.Equals( addCheeseViewModel.CategoryID));
                // Add the new cheese to my existing cheeses
                Cheese newCheese = new Cheese
                {
                    Name = addCheeseViewModel.Name,
                    Description = addCheeseViewModel.Description,
                    Category = newCheeseCategory
                };
                // TODO - maybe?? context.Categories.Add(addCheeseViewModel.Type);
                context.Cheeses.Add(newCheese);
                //context.Categories.Add(newCheese.Category);
                context.SaveChanges();

                return Redirect("/Cheese");
            }
            // TODO - SHOULD I pass Catagories into this View Somehow??
            return View(addCheeseViewModel); // ( addCheeseViewModel.Categories ) ??
        }

        public IActionResult Remove()
        {
            ViewBag.title = "Remove Cheeses";
            ViewBag.cheeses = context.Cheeses.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Remove(int[] cheeseIds)
        {
            foreach (int cheeseId in cheeseIds)
            {
                Cheese theCheese = context.Cheeses.Single(c => c.ID == cheeseId);
                context.Cheeses.Remove(theCheese);
            }

            context.SaveChanges();

            return Redirect("/");
        }

        // TODO - Added this because of video....
        // /Controller/Action/id
        public IActionResult Category(int id)
        {
            if (id == 0)
            {
                return Redirect("/Category");
            }

            CheeseCategory theCategory = context.Categories
                .Include(cat => cat.Cheeses)
                .Single(cat => cat.ID == id);

            ViewBag.title = "Cheeses in category: " + theCategory.Name;

            return View("Index", theCategory.Cheeses);
        }
    }
}
