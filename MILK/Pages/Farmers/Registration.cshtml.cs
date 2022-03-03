using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MILK.Data;
using MILK.Model;

namespace MILK.Pages.Farmers
{
    [BindProperties]
    public class RegistrationModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public Farmer Farmer { get; set; }
        public RegistrationModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> OnGet(int? id)
        {
            Farmer = new Farmer();
            if(id == null)
            {
                return Page();
            }
            Farmer = _db.Farmer.FirstOrDefault(c => c.id == id);
            if(Farmer == null)
            {
                return NotFound();
            }
            return Page();
        }
        public async Task<IActionResult> OnPost()
        {
            if (_db.Farmer.Any(m => m.MemberNo.ToUpper().Equals(Farmer.MemberNo.ToUpper())))
            {
                TempData["success"] = "Farmer Member No already exist";
                return Page();
            }
            if (_db.Farmer.Any(m => m.IDNo.Equals(Farmer.IDNo)))
            {
                TempData["success"] = "Farmer ID No already exist";
                return Page();
            }

            if (Farmer.Name == Farmer.IDNo.ToString())
            {
                ModelState.AddModelError("Category.name", "Display order and Name cannot be the same");
            }
            if (ModelState.IsValid)
            {
                var newid = Farmer.id;
                if (Farmer.id == 0)
                {

                    _db.Farmer.AddAsync(Farmer);
                }
                else
                {
                    _db.Farmer.Update(Farmer);
                }
                await _db.SaveChangesAsync();
                if (newid == 0)
                {
                    TempData["success"] = "Farmer Created successfully";
                }
                else
                {
                    TempData["success"] = "Farmer updated successfully";
                }
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
