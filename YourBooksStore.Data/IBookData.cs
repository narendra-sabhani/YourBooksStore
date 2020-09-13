using System.Collections.Generic;
using System.Linq;
using YourBooksStore.Core;

namespace YourBooksStore.Data {
    public interface IBookData {
        IEnumerable<Book> GetAllBooksByName (string name);
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

        public IEnumerable<Book> GetAllBooksByName (string name = null) {
            var result = books.Where(x => string.IsNullOrEmpty(name) || x.Title.Contains(name));
            return result;
        }
    }
}