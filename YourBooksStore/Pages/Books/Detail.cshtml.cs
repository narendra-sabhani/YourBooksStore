using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using YourBooksStore.Core;
using YourBooksStore.Data;

namespace YourBooksStore.Pages.Books
{
    public class DetailModel : PageModel {
        public IBookData Books { get; }
        public DetailModel (IBookData Books) {
            this.Books = Books;

        }
        public Book Book { get; set; }
        public IActionResult OnGet (int isn) {
            Book = Books.GetByISN (isn);
            if (Book is null) {
                return RedirectToPage ("./NotFound");
            }
            return Page ();
        }
    }
}