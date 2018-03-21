using CheeseMVC.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CheeseMVC.ViewModels
{
    public class AddCheeseViewModel
    {
        [Required]
        [Display(Name = "Cheese Name")]
        public string Name { get; set; }

        //[Required(ErrorMessage = "You must give your cheese a description!!!!!!!!!")]
        [Required]
        [Display(Name = "Description YO!")]
        public string Description { get; set; }
        // TODO - This is going threw Null in add form
        [Required(ErrorMessage = "Proper Category Not Selected! I don't need this here, its a test :(")]
        [Display(Name = "Category")]
        public int CategoryID { get; set; }
        // TODO - THESE ARE GOING THREW NULL AT ADD FORM.
        public List<SelectListItem> Categories { get; set; }

        // TODO - Default Constructor?
        public AddCheeseViewModel()
        {
            
            Categories = new List<SelectListItem>();

            foreach (var category in Categories)
            {
                Categories.Add(new SelectListItem
                {
                    Value = category.ToString(),
                    Text =  category.ToString()
                });
            }

            /*
            // <option value="0">Hard</option>
            Categories.Add(new SelectListItem {
                Value = 1,//((int)CheeseType.Soft).ToString(),
                Text = "hello" // CheeseType.Hard.ToString()
            });

            Categories.Add(new SelectListItem
            {
                Value = 2.ToString(),//((int)CheeseType.Soft).ToString(),
                Text = "and hello"//CheeseType.Soft.ToString()
            });

            Categories.Add(new SelectListItem
            {
                Value = 3.ToString(),//((int)CheeseType.Fake).ToString(),
                Text = "and Hello again!"//CheeseType.Fake.ToString()
            });
            */

        }

        public AddCheeseViewModel(IEnumerable<CheeseCategory> categories)
        {
            
            Categories = new List<SelectListItem>();

            foreach (CheeseCategory category in categories)
            {
                Categories.Add(new SelectListItem
                {
                    Value = category.ID.ToString(),
                    Text = category.Name
                });
            }

            /*
            // <option value="0">Hard</option>
            Categories.Add(new SelectListItem {
                Value = 1,//((int)CheeseType.Soft).ToString(),
                Text = "hello" // CheeseType.Hard.ToString()
            });

            Categories.Add(new SelectListItem
            {
                Value = 2.ToString(),//((int)CheeseType.Soft).ToString(),
                Text = "and hello"//CheeseType.Soft.ToString()
            });

            Categories.Add(new SelectListItem
            {
                Value = 3.ToString(),//((int)CheeseType.Fake).ToString(),
                Text = "and Hello again!"//CheeseType.Fake.ToString()
            });
            */

        }
        // TODO - this was my origina version :(
        //public AddCheeseViewModel(List<CheeseCategory> cheeseCategories)
    }
}
