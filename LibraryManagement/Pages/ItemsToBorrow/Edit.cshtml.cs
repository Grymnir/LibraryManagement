using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LibraryManagement.Data;
using LibraryManagement.Models;

namespace LibraryManagement.Pages.ItemsToBorrow
{
    public class EditModel : PageModel
    {
        private readonly LibraryManagement.Data.LibraryManagementContext _context;

        public EditModel(LibraryManagement.Data.LibraryManagementContext context)
        {
            _context = context;
        }

        [BindProperty]
        public LibraryItem LibraryItem { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            List<Category> categories = _context.Category.ToList();
            ViewData["Categories"] = new SelectList(categories, "ID", "CategoryName");
            if (id == null || _context.LibraryItem == null)
            {
                return NotFound();
            }


            var libraryitem =  await _context.LibraryItem.FirstOrDefaultAsync(m => m.ID == id);
            if (libraryitem == null)
            {
                return NotFound();
            }
            LibraryItem = libraryitem;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(LibraryItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LibraryItemExists(LibraryItem.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool LibraryItemExists(int id)
        {
          return (_context.LibraryItem?.Any(e => e.ID == id)).GetValueOrDefault();
        }

        public async Task<IActionResult> OnPostCheckIn()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(LibraryItem).State = EntityState.Modified;

            LibraryItem.Borrower= null;
            LibraryItem.BorrowerDate = null;

            await _context.SaveChangesAsync();
            return RedirectToPage("./ItemsToBorrow/Edit");
        }
        public async Task<IActionResult> OnPostCheckOut()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(LibraryItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LibraryItemExists(LibraryItem.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }
    }
}
