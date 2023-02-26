using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Models
{
    public class LibraryItem
    {
        public int ID { get; set; }

        public Category? Category { get; set; }
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        [Required]
        public string? Title { get; set; }
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        [Required]
        public string? Author { get; set; }
        [Required]
        public Nullable<int> Pages { get; set; }

        [Range(1, 100)]
        [Required]
        public Nullable<int> RunTimeMinutes { get; set; }

        public bool isBorrowable { get; set; }
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        public string? Borrower { get; set; }
        [DataType(DataType.Date)]
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
