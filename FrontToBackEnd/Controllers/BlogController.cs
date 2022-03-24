﻿using FrontToBackEnd.Data;
using FrontToBackEnd.Models;
using FrontToBackEnd.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontToBackEnd.Controllers
{
    
    public class BlogController : Controller
    {
        private readonly AppDbContext _context;
        public BlogController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            List<Category> categories = await _context.Categories.ToListAsync();
            List<CategoryName> categoryNames = await _context.CategoryNames.ToListAsync();
            List<Fruit> fruits = await _context.Fruits.ToListAsync();
            List<Beverage> beverages = await _context.Beverages.ToListAsync();
            HomeVM homeVM = new HomeVM
            {

                Categories = categories,
                CategoryNames = categoryNames,
                Fruits = fruits,
                Beverages = beverages

            };
            return View(homeVM);
        }
    }
}
