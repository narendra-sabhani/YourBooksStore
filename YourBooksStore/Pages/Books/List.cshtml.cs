using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using YourBooksStore.Core;
using YourBooksStore.Data;

namespace YourBooksStore.Pages.Books {
    public class ListModel : PageModel {
        IConfiguration Configuration { get; }
        IBookData BookData { get; }
        public IEnumerable<Book> Books { get; set; }

       [BindProperty(SupportsGet=true)]
       public string SearchTerm { get; set; }
        public ListModel (IConfiguration configuration, IBookData bookData) {
            this.BookData = bookData;
            this.Configuration = configuration;

        }
        public void OnGet () {
           
            Books = BookData.GetAllBooksByName(SearchTerm);
        }
    }
}