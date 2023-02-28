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


        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        public SelectList? Genres { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? MovieGenre { get; set; }
        [BindProperty(SupportsGet = true)]
        public string? TypeItem { get; set; }

        public async Task OnGetAsync()
        {
            // Use LINQ to get list of genres.
            IQueryable<string> genreQuery = from m in _context.LibraryItem
                                            orderby m.Type
                                            select m.Type;

            //var movies = from m in _context.LibraryItem
            //             select m;
            var libraryTypes = from m in _context.LibraryItem
                         select m;

            if (!string.IsNullOrEmpty(TypeItem))
            {
                libraryTypes = libraryTypes.Where(x => x.Type == TypeItem);
            }
            Genres = new SelectList(await genreQuery.Distinct().ToListAsync());
            LibraryItem = await libraryTypes.ToListAsync();


        }
    }
}
