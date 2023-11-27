using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF
{
    public class BookStoreContext : DbContext
    {
        public DbSet<BooksEntity> Books { get; set; }

        public DbSet<CategoryEntity> Category { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BooksEntity>()
                .ToTable("Books")
                .HasKey(m => m.id);

            modelBuilder.Entity<CategoryEntity>()
                .HasKey(m => m.Id);


        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=WIN10TIA\LearnServer; Database=EF; Trusted_Connection=True; Encrypt = no");
        }
    }
}
