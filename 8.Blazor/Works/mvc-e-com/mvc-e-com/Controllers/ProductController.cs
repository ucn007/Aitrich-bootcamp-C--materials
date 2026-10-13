using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using mvc_e_com.Data;
using mvc_e_com.Model;

public class ProductController : Controller
{
    private readonly MyDbContext _context;

    public ProductController(MyDbContext context)
    {
        _context = context;
    }

    // GET: /Product/Create
    [HttpGet]
    public IActionResult Create()
    {
        LoadCategories();

        return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Product product)
    {
        // Check duplicate SKU before saving
        bool skuExists = await _context.Products
            .AnyAsync(p => p.Sku == product.Sku);

        if (skuExists)
        {
            ModelState.AddModelError(
                nameof(product.Sku),
                $"SKU '{product.Sku}' already exists."
            );
        }

        if (!ModelState.IsValid)
        {
            LoadCategories(product.CategoryId);
            return View(product);
        }

        try
        {
            product.CreatedAt = DateTime.UtcNow;
            product.IsActive = true;

            _context.Products.Add(product);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        catch (DbUpdateException ex)
        {
            // Show database error on the form
            ModelState.AddModelError(
                "",
                ex.InnerException?.Message ?? ex.Message
            );

            LoadCategories(product.CategoryId);

            return View(product);
        }
    }
    
    // GET: /Product/Index
    [HttpGet]
    public async Task<IActionResult> Index(string? category)
    {
        var products = _context.Products
            .Include(p => p.Category)
            .AsQueryable();

        if (!string.IsNullOrWhiteSpace(category))
        {
            products = products.Where(p => p.Category.Name == category);
        }

        ViewBag.Categories = await _context.Categories
            .Where(c => c.IsActive)
            .OrderBy(c => c.Name)
            .Select(c => c.Name)
            .ToListAsync();

        ViewBag.SelectedCategory = category;

        return View(await products.ToListAsync());
    }
    private void LoadCategories(int? selectedCategoryId = null)
    {
        ViewBag.Categories = new SelectList(
            _context.Categories
                .Where(c => c.IsActive)
                .OrderBy(c => c.Name)
                .ToList(),
            "CategoryId",
            "Name",
            selectedCategoryId
        );
    }
    
    
    
    // GET: /Product/Details/5
    [HttpGet]
    public async Task<IActionResult> Details(int id)
    {
        var product = await _context.Products
            .Include(p => p.Category)
            .FirstOrDefaultAsync(p => p.ProductId == id);

        if (product == null)
        {
            return NotFound();
        }

        return View(product);
    }
    
    
}