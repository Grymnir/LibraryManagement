using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using LibraryManagement.Data;
using LibraryManagement.Models;

namespace LibraryManagement.Pages.CategoryLibrary
{
    public class CreateModel : PageModel
    {
        private readonly LibraryManagement.Data.LibraryManagementContext _context;

        public CreateModel(LibraryManagement.Data.LibraryManagementContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Category Category { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if(!_context.Category.Any(c => c.CategoryName == Category.CategoryName))
            {
                if (!ModelState.IsValid || _context.Category == null || Category == null)
                {
                    return Page();
                }



                _context.Category.Add(Category);
                await _context.SaveChangesAsync();

                //return RedirectToPage("./Index");
            }

            //if (!ModelState.IsValid || _context.Category == null || Category == null)
            //{
            //    return Page();
            //}

            //_context.Category.Add(Category);
            //await _context.SaveChangesAsync();
            ModelState.AddModelError(string.Empty, "That Category already exists!");

            //return RedirectToPage("./Create");

            return RedirectToPage("./Index");


        }
    }
}
