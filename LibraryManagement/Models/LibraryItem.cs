using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Models
{
    public class LibraryItem
    {
        public int ID { get; set; }

        public virtual Category? Category { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$", ErrorMessage = "Only Text Please! No numbers!")]
        [Required]
        public string? Title { get; set; }
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$", ErrorMessage = "Only text please!")]
        [Required]
        public string? Author { get; set; }
        [Required]
        [Range(1, 1000)]
        public Nullable<int> Pages { get; set; }

        [Range(1, 1000)]
        public Nullable<int> RunTimeMinutes { get; set; }

        public bool isBorrowable { get; set; }
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$", ErrorMessage = "Borrower cant be number! Only text!")]
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
