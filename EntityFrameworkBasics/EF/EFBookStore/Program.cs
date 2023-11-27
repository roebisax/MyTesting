using Microsoft.EntityFrameworkCore;

namespace EF
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            BookStoreContext bookStoreContext = new BookStoreContext();

            List<BooksEntity> l = bookStoreContext.Books
                .Include(b => b.Categories)
                .ToList();

            var be = bookStoreContext.Books.Include(b => b.Categories).Select(b=>b.Categories);

            List<CategoryEntity> c = bookStoreContext.Category.ToList();

            List<CategoryEntity> bc = l.First().Categories.ToList();

            bc.Add(c.First());

            l.First().Categories = bc;


            bookStoreContext.SaveChanges();
        }
    }
}
