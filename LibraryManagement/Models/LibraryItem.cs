using Microsoft.AspNetCore.Mvc.Rendering;

namespace LibraryManagement.Models
{
    public class LibraryItem
    {
        public int ID { get; set; }

        public Category? Category { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }
        public Nullable<int> Pages { get; set; }
        public Nullable<int> RunTimeMinutes { get; set; }
        public bool isBorrowable { get; set; }
        public string? Borrower { get; set; }
        public Nullable<DateTime> BorrowerDate { get; set; }
        public string? Type { get; set; }
        public static IEnumerable<SelectListItem>? TypeOptions()
        {
            return new[]
            {
                new SelectListItem { Text = "book", Value = "book" },
                new SelectListItem { Text="reference book", Value="reference book"},
                new SelectListItem { Text="dvd", Value="dvd" },
                new SelectListItem{ Text="audio book", Value="audio book"}
            };
        }

    }
}
