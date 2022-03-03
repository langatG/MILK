using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MILK.Data;
using MILK.Model;

namespace MILK.Pages.Categories
{
    [BindProperties]
    public class UpsertModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public Category Category { get; set; }
        public UpsertModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> OnGet(int? id)
        {
            Category = new Category();
            if(id == null)
            {
                return Page();
            }
            Category = _db.Category.FirstOrDefault(c => c.Id == id);
            if(Category == null)
            {
                return NotFound();
            }
            return Page();
        }
        public async Task<IActionResult> OnPost()
        {
            if (Category.Name == Category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Category.name", "Display order and Name cannot be the same");
            }
            if (ModelState.IsValid)
            {
                if (Category.Id == 0)
                {
                    _db.Category.AddAsync(Category);
                }
                else
                {
                    _db.Category.Update(Category);
                }
                await _db.SaveChangesAsync();
                if (Category.Id == 0)
                {
                    TempData["success"] = "Category Created successfully";
                }
                else
                {
                    TempData["success"] = "Category updated successfully";
                }
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
