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
    public class IndexModel : PageModel
    {
        private readonly LibraryManagement.Data.LibraryManagementContext _context;

        public IndexModel(LibraryManagement.Data.LibraryManagementContext context)
        {
            _context = context;
        }

        public IList<LibraryItem> LibraryItem { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.LibraryItem != null)
            {
                LibraryItem = await _context.LibraryItem.ToListAsync();
            }
        }
    }
}
