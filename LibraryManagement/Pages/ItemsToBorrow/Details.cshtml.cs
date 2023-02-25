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
    public class DetailsModel : PageModel
    {
        private readonly LibraryManagement.Data.LibraryManagementContext _context;

        public DetailsModel(LibraryManagement.Data.LibraryManagementContext context)
        {
            _context = context;
        }

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
    }
}
