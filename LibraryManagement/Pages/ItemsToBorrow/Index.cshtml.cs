using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LibraryManagement.Data;
using LibraryManagement.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LibraryManagement.Pages.ItemsToBorrow
{
    public class IndexModel : PageModel
    {
        private readonly LibraryManagement.Data.LibraryManagementContext _context;

        public IndexModel(LibraryManagement.Data.LibraryManagementContext context)
        {
            _context = context;
        }

        public IList<LibraryItem> LibraryItem { get;set; } = default!;

        //public SelectList? Types { get; set; }

        public async Task OnGetAsync()
        {
            if (_context.LibraryItem != null)
            {

                LibraryItem = await _context.LibraryItem.OrderBy(c => c.Category).ToListAsync();
            }
            //Types = new SelectList(await TypeQuery.Distinct().ToListAsync());
        }
    }
}
