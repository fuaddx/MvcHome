﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pustok2.Areas.Admin.Controllers;
using Pustok2.Contexts;
using Pustok2.ModelClass;
using Pustok2.Models;
using Pustok2.ViewModel.HomeVm;
using Pustok2.ViewModel.ProductVM;
using Pustok2.ViewModel.SliderVM;
using System.Diagnostics;

namespace Pustok2.Controllers
{
    public class HomeController : Controller
    {
        PustokDbContent _context { get; }

        public HomeController(PustokDbContent context)
        {
            _context = context;
        }
        /*1 ci versiya*/
        /*public async Task<IActionResult> Index()
        {
            var sliders = await _context.Sliders.ToListAsync();
            var products = await _context.Products.ToListAsync();
            ProductSliderVM md = new ProductSliderVM();
            md.Sliders = sliders;
            md.Products = products;
            return View(md);
        }*/
        /*2 ci versiya*/
        public async Task<IActionResult> Index() {

            HomeVm vm = new HomeVm
            {
                Sliders = await _context.Sliders.Select(s => new SliderListItemVM
                {
                    Id = s.Id,
                    ImageUrl = s.ImageUrl,
                    IsLeft = s.IsLeft,
                    Title = s.Title,
                    Text = s.Text,
                }).ToListAsync(),
                Products = await _context.Products.Where(p => !p.IsDeleted).Select(p => new ProductListVM
                {
                    Id = p.Id,
                    Category = p.Category,
                    Discount = p.Discount,
                    Name = p.Name,
                    ImageUrl = p.ImageUrl,
                    Quantity = p.Quantity,
                    SellPrice = p.SellPrice,
                    CostPrice = p.CostPrice,
                    About = p.About,
                }).ToListAsync()
            };
            return View(vm);
        }
        
    }
}