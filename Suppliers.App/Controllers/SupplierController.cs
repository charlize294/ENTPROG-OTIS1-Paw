using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Suppliers.DataModel;
using System.Security.AccessControl;

namespace Suppliers.App.Controllers
{
    public class SupplierController : Controller
    {
        private readonly AppDbContext context;

        public SupplierController(AppDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            return View(context.SuppliersINV.ToList());
        }

        public IActionResult Add()
        {
            return View(new SuppliersINV());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> Add(SuppliersINV entity)
        {
            entity.DateAdded = DateTime.Now;
            await context.AddAsync(entity);
            await context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var supplier = await context.SuppliersINV.FindAsync(id);
            context.Set<SuppliersINV>().Remove(supplier);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");

            var supplier = await context.SuppliersINV.FindAsync(id);
            return View(supplier);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> Edit(SuppliersINV entity)
        {
            entity.DateModified = DateTime.Now;
            context.Set<SuppliersINV>().Update(entity);
            await context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
