﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pustok2.Contexts;
using Pustok2.Helpers;
using Pustok2.Models;
using Pustok2.ViewModel.ProductImagesVm;
using Pustok2.ViewModel.ProductVM;

namespace Pustok2.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class ProductImagesController : Controller
    {
        PustokDbContent _db { get; }
        public ProductImagesController(PustokDbContent db)
        {
            _db = db;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _db.ProductImages.Select(c => new ProductImagesListVm
            {
                Id = c.Id,
                ImagePath = c.ImagePath,
                IsActive = c.IsActive,
                Product = c.Product
            }).ToListAsync());
        }
        public IActionResult Create()
        {
            ViewBag.Product = _db.Products;
            return View();
        }
        /*[HttpPost]*/
        /*public async Task<IActionResult> Create(ProductImagesVm vm)
        {
            if (vm.ImageFile != null)
            {
                if (!vm.ImageFile.IsCorrectType())
                {
                    ModelState.AddModelError("ImageFile", "Wrong file type");
                }
                if (!vm.ImageFile.IsValidSize())
                {
                    ModelState.AddModelError("ImageFile", "Files length must be less than kb");
                }
            }
            *//*ProductImages frod = new ProductImages
            {
                ImagePath = vm.ImagePath,
                IsActive = vm.IsActive,
                ProductId = vm.ProductId,
            };

            await _db.Products.AddAsync(frod);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));*//*
        }*/
    }
}
