using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Praktika04
{
    internal class Exemple3
    {
        class Book
        {
            public string Title { get; set; }
            public string Author { get; set; }
            public int Year { get; set; }
        }

        class Library
        {
            private List<Book> books = new List<Book>();

            public void AddBook(Book book)
            {
                books.Add(book);
            }

            public void RemoveBook(string title)
            {
                books.RemoveAll(book => book.Title == title);
            }

            public List<Book> SearchByAuthor(string author)
            {
                return books.Where(book => book.Author == author).ToList();
            }

            public List<Book> SortByTitle()
            {
                return books.OrderBy(book => book.Title).ToList();
            }
        }

        class Program
        {
            static void Main()
            {
                Library library = new Library();
                library.AddBook(new Book { Title = "Book 1", Author = "Author 1", Year = 2000 });
                library.AddBook(new Book { Title = "Book 2", Author = "Author 2", Year = 1995 });
                library.AddBook(new Book { Title = "Book 3", Author = "Author 1", Year = 2010 });
                library.AddBook(new Book { Title = "Book 4", Author = "Author 3", Year = 2022 });

                Console.WriteLine("Все книги в библиотеке:");
                foreach (var book in library.SortByTitle())
                {
                    Console.WriteLine($"Название: {book.Title}, Автор: {book.Author}, Год: {book.Year}");
                }

                Console.WriteLine("\nКниги автора 'Author 1':");
                foreach (var book in library.SearchByAuthor("Author 1"))
                {
                    Console.WriteLine($"Название: {book.Title}, Автор: {book.Author}, Год: {book.Year}");
                }

                library.RemoveBook("Book 2");

                Console.WriteLine("\nПосле удаления книги 'Book 2':");
                foreach (var book in library.SortByTitle())
                {
                    Console.WriteLine($"Название: {book.Title}, Автор: {book.Author}, Год: {book.Year}");
                }
            }
        }
    }
}