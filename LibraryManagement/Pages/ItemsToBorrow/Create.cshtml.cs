using LibraryManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LibraryManagement.Pages.ItemsToBorrow
{
    public class CreateModel : PageModel
    {
        private readonly Data.LibraryManagementContext _context;

        public CreateModel(Data.LibraryManagementContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            List<Category> categories = _context.Category.ToList();
            ViewData["Categories"] = new SelectList(categories, "ID", "CategoryName");
            return Page();
        }

        [BindProperty]
        public LibraryItem LibraryItem { get; set; } = default!;
        public Category LibraryCategory { get; set; }
        public SelectList getCategories { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.LibraryItem == null || LibraryItem == null)
          {
                return Page();
          }
            _context.LibraryItem.Add(LibraryItem);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
