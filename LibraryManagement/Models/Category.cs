using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Models
{
    public class Category
    {

        public int ID { get; set; }
        [Required]
        [StringLength(50)]
        public string? CategoryName { get; set; }

        public static IEnumerable<SelectListItem>? TypeCategoryOptions()
        {
            return new[]
            {
                new SelectListItem{ Text="CategoryName", Value="ID"}
            };
        }
    }
}
