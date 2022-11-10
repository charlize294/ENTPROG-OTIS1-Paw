using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Suppliers.App.Models;
using Suppliers.App.Models.Repositories;
using Suppliers.DataModel;
using System.Reflection;

namespace Suppliers.App.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepo repo;
        private readonly IMapper mapper;

        public ProductController(IProductRepo repo, IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            return View(mapper.Map<List<ProductVM>>(await repo.GetAllAsync()));
        }

        public IActionResult Add()
        {
            return View(new ProductVM());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(ProductVM model)
        {
            if (ModelState.IsValid)
            {
                model.DateAdded = DateTime.Now;
                await repo.AddAsync(mapper.Map<Product>(model));
                return RedirectToAction("Index");
            }

            else
            {
                return View(model);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await repo.DeleteAsync(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return RedirectToAction("Index");
            ProductVM product = mapper.Map<ProductVM>(await repo.GetAsync((int)id));    
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProductVM model)
        {
            if (ModelState.IsValid)
            {
                model.DateModified = DateTime.Now;
                await repo.UpdateAsync(mapper.Map<Product>(model));
                return RedirectToAction("Index");
            }

            else
            {
                return View(model);
            }
        }
    }
}
