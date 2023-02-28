using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManagement.Models
{
    public class Category
    {

        public int ID { get; set; }
        [Required]
        [StringLength(50)]
        public string? CategoryName { get; set; }
    }
}
