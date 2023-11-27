using Microsoft.EntityFrameworkCore;

namespace EF
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            BookStoreContext bookStoreContext = new BookStoreContext();

            var l = bookStoreContext.Books
                //.Include(b=>b.Categories)
                .First();

            bookStoreContext.Category.Add(new CategoryEntity() { Name = "asdf" });





            bookStoreContext.SaveChanges();

            
        }


    }

    public static class EntityExtensions
    {
        public static void AddToListProperty<TEntity, TProperty>(this TEntity einity, Func<TEntity, IEnumerable<TProperty>> property, TProperty newValue)
        {

        }
    }
}
