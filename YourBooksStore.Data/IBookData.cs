using System.Collections.Generic;
using System.Linq;
using YourBooksStore.Core;

namespace YourBooksStore.Data {
    public interface IBookData {
        IEnumerable<Book> GetAllBooksByName (string name);
        Book GetByISN (int isn);

        Book Update (Book updatedBook);

        int Commit ();

        Book Add (Book newBook);
    }
    public class InMemoryBookData : IBookData {
        readonly List<Book> books;
        public InMemoryBookData () {
            books = new List<Book> {
                new Book { ISN = 122, Title = "Title 1", Author = "Narendra Sabhani", Category = Category.Development, Price = 23.99M },
                new Book { ISN = 123, Title = "Title 2", Author = "Vivek Patel", Category = Category.ExamPreparation, Price = 23.99M },
                new Book { ISN = 124, Title = "Title 3", Author = "Batuk Sabhani", Category = Category.History, Price = 23.99M },
                new Book { ISN = 125, Title = "Title 4", Author = "Urmi Sabhani", Category = Category.Law, Price = 23.99M }
            };
        }

        public Book Add (Book newBook) {
            books.Add (newBook);
            newBook.ISN = books.Max (b => b.ISN + 1);
            return newBook;
        }

        public int Commit () {
            return 0;
        }

        public IEnumerable<Book> GetAllBooksByName (string name = null) {
            var result = books.Where (x => string.IsNullOrEmpty (name) || x.Title.Contains (name));
            return result;
        }

        public Book GetByISN (int isn) {
            var result = books.SingleOrDefault (b => b.ISN == isn);
            return result;
        }

        public Book Update (Book updatedBook) {
            var b = GetByISN (updatedBook.ISN);
            if (b != null) {
                b.Author = updatedBook.Author;
                b.Title = updatedBook.Title;
                b.Category = updatedBook.Category;
            }
            return b;
        }
    }
}