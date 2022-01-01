using Microsoft.EntityFrameworkCore;
using BookstoreWebApi.Entity;

namespace BookstoreWebApi.DBOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BookstoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<BookstoreDbContext>>()))
            {
                if (context.Books.Any() || context.Genres.Any() || context.Authors.Any())
                {
                    return;
                }

                context.Authors.AddRange(new Author {
                  FirstName = "Fyodor",
                  LastName = "Dostoyevski",
                  BirthDate = new DateTime(1821, 11, 11)
                },new Author {
                    FirstName = "George",
                    LastName = "Orwell",
                    BirthDate = new DateTime(1903, 06, 25)
                },
                new Author{
                    FirstName = "George R.R",
                    LastName = "Martin",
                    BirthDate = new DateTime(1948, 09, 20)
                }
                );
                
                context.Genres.AddRange(new Genre
                {
                    Name = "Personal Growth"
                },
                new Genre
                {
                    Name = "Sicence Fiction"
                },
                new Genre
                {
                    Name = "Novel"
                });

                context.Books.AddRange(
                    new Book
                    {
                        Title = "Suc ve Ceza",
                        GenreID = 1,
                        AuthorId = 1,
                        PageCount = 450,
                        PublishDate = new DateTime(1985, 06, 12),

                    },
                    new Book
                    {
                        Title = "1984",
                        GenreID = 2,
                        AuthorId = 2,
                        PageCount = 400,
                        PublishDate = new DateTime(1984, 03, 10),

                    },
                    new Book
                    {
                        Title = "Aspidistra",
                        GenreID = 1,
                        AuthorId = 2,
                        PageCount = 200,
                        PublishDate = new DateTime(1999, 09, 20),

                    });
                context.SaveChanges();
            }
        }
    }
}