using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DevXuongMoc.Models;
using X.PagedList;

namespace DevXuongMoc.Areas.Admins.Controllers
{
    [Area("Admins")]
    [Route("admins/products")]
    public class ProductsController : Controller
    {
        private readonly DevXuongMocContext _context;

        public ProductsController(DevXuongMocContext context)
        {
            _context = context;
        }

        // GET: Admins/Products
        public async Task<IActionResult> Index()
        {
            return View(await _context.Products.ToListAsync());
        }
        // GET: Product
        [HttpGet("Products/Index")]
        public async Task<IActionResult> Index(string searchQuery)
        {
            IQueryable<Product> products = _context.Products;

            if (!string.IsNullOrEmpty(searchQuery))
            {
                products = products.Where(p => p.Title.Contains(searchQuery)); // Lọc trong SQL Server
                ViewData["SearchQuery"] = searchQuery; // Truyền dữ liệu sang View
            }

            return View(await products.ToListAsync()); // Chỉ tải dữ liệu đã được lọc
        }


        [HttpGet("Products/Details/{id}")]
        // GET: Admins/Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Admins/Products/Create
        [HttpGet("Products/Create")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admins/Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Cid,Code,Title,Description,Content,Image,MetaTitle,MetaKeyword,MetaDescription,Slug,PriceOld,PriceNew,Size,Views,Likes,Star,Home,Hot,CreatedDate,UpdatedDate,AdminCreated,AdminUpdated,Status,Isdelete")] Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Admins/Products/Edit/5
        [HttpGet("Products/Edit/{id}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: Admins/Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Cid,Code,Title,Description,Content,Image,MetaTitle,MetaKeyword,MetaDescription,Slug,PriceOld,PriceNew,Size,Views,Likes,Star,Home,Hot,CreatedDate,UpdatedDate,AdminCreated,AdminUpdated,Status,Isdelete")] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Products/Delete/5
        // GET: Admins/Products/Delete/5
        [HttpGet("Delete/{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);  // Return a view with the product data for confirmation
        }

        // POST: Admins/Products/Delete/5
        [HttpPost("Delete/{id}")]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));  // After deletion, redirect to the products list (Index action)
        }




        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
