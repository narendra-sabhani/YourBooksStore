using System.ComponentModel.DataAnnotations;
namespace YourBooksStore.Core
{
    public class Book
    {

        public int ISN { get; set; }
        [Required]
        [StringLength(255)]
        public string Title { get; set; }
        public decimal Price { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public Category Category { get; set; }
    }

}