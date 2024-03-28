using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class NotesContext : DbContext
    {
        protected override void OnConfiguring
       (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "NotesDB");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Note>().HasData(
                new Note { Id = 1, Title = "1", Content = "1", CreationDate = DateTime.Now, CreatedByUser = 1 },
                new Note { Id = 2, Title = "2", Content = "2", CreationDate = DateTime.Now, CreatedByUser = 1 },
                new Note { Id = 3, Title = "3", Content = "3", CreationDate = DateTime.Now, CreatedByUser = 1 },
                new Note { Id = 4, Title = "4", Content = "4", CreationDate = DateTime.Now, CreatedByUser = 1 },
                new Note { Id = 5, Title = "5", Content = "5", CreationDate = DateTime.Now, CreatedByUser = 1 },
                new Note { Id = 6, Title = "6", Content = "6", CreationDate = DateTime.Now, CreatedByUser = 1 },
                new Note { Id = 7, Title = "7", Content = "7", CreationDate = DateTime.Now, CreatedByUser = 1 },
                new Note { Id = 8, Title = "8", Content = "8", CreationDate = DateTime.Now, CreatedByUser = 1 },
                new Note { Id = 9, Title = "9", Content = "9", CreationDate = DateTime.Now, CreatedByUser = 1 },
                new Note { Id = 10, Title = "10", Content = "10", CreationDate = DateTime.Now, CreatedByUser = 1 },
                new Note { Id = 11, Title = "11", Content = "11", CreationDate = DateTime.Now, CreatedByUser = 1 },
                new Note { Id = 12, Title = "12", Content = "12", CreationDate = DateTime.Now, CreatedByUser = 1 },
                new Note { Id = 13, Title = "13", Content = "13", CreationDate = DateTime.Now, CreatedByUser = 1 },
                new Note { Id = 14, Title = "14", Content = "14", CreationDate = DateTime.Now, CreatedByUser = 1 },
                new Note { Id = 15, Title = "15", Content = "15", CreationDate = DateTime.Now, CreatedByUser = 1 },
                new Note { Id = 16, Title = "16", Content = "16", CreationDate = DateTime.Now, CreatedByUser = 2 }
            );
        }

        public DbSet<Note> Notes { get; set; }
    }
}