using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using YourBooksStore.Core;
using YourBooksStore.Data;

namespace YourBooksStore.Pages.Books {
    public class EditModel : PageModel {
        public IHtmlHelper HtmlHelper { get; }

        public EditModel (IBookData bookData, IHtmlHelper htmlHelper) {
            this.HtmlHelper = htmlHelper;
            this.BookData = bookData;
        }

        public IBookData BookData { get; }

        [BindProperty]
        public Book Book { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; }
        public IActionResult OnGet (int? isn) {
            if (isn.HasValue) {
                this.Book = BookData.GetByISN (isn.Value);
            } else {
                this.Book = new Book ();
            }
            this.Categories = HtmlHelper.GetEnumSelectList<Category> ();

            if (Book == null) {
                return RedirectToPage ("./NotFound");
            }
            return Page ();
        }

        public IActionResult OnPost () {
            if (!ModelState.IsValid) {
                this.Categories = HtmlHelper.GetEnumSelectList<Category> ();
                return Page ();
            }

            if (Book.ISN > 0) {
                BookData.Update (Book);
            } else {
                BookData.Add (Book);
            }
            BookData.Commit ();
            TempData["Message"] = "Book Saved";
            return RedirectToPage ("./Detail", new { isn = Book.ISN });

        }
    }
}