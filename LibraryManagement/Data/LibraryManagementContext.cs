using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LibraryManagement.Models;

namespace LibraryManagement.Data
{
    public class LibraryManagementContext : DbContext
    {
        public LibraryManagementContext (DbContextOptions<LibraryManagementContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Category { get; set; } = default!;

        public DbSet<LibraryItem> LibraryItem { get; set; } = default!;
    }
}
