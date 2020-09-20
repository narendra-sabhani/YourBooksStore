using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using YourBooksStore.Core;

namespace YourBooksStore.Pages.Books {
    public class DetailModel : PageModel {
        public Book Book { get; set; }
        public void OnGet () {
            Book = new Book ();
        }
    }
}