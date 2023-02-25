using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LibraryManagement.Data;
using LibraryManagement.Models;

namespace LibraryManagement.Pages.ItemsToBorrow
{
    public class DeleteModel : PageModel
    {
        private readonly LibraryManagement.Data.LibraryManagementContext _context;

        public DeleteModel(LibraryManagement.Data.LibraryManagementContext context)
        {
            _context = context;
        }

        [BindProperty]
      public LibraryItem LibraryItem { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.LibraryItem == null)
            {
                return NotFound();
            }

            var libraryitem = await _context.LibraryItem.FirstOrDefaultAsync(m => m.ID == id);

            if (libraryitem == null)
            {
                return NotFound();
            }
            else 
            {
                LibraryItem = libraryitem;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.LibraryItem == null)
            {
                return NotFound();
            }
            var libraryitem = await _context.LibraryItem.FindAsync(id);

            if (libraryitem != null)
            {
                LibraryItem = libraryitem;
                _context.LibraryItem.Remove(LibraryItem);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
