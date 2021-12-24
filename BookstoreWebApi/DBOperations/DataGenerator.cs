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
                if (context.Books.Any())
                {
                    return;
                }
                context.Books.AddRange(
                    new Book
                    {
                        //ID = 1,
                        Title = "Suc ve Ceza",
                        GenreID = 1, // novel
                        PageCount = 450,
                        PublishDate = new DateTime(1985, 06, 12),

                    },
                    new Book
                    {
                        //ID = 2,
                        Title = "1984",
                        GenreID = 2, // History fiction
                        PageCount = 400,
                        PublishDate = new DateTime(1984, 03, 10),

                    },
                    new Book
                    {
                        //ID = 3,
                        Title = "Aspidistra",
                        GenreID = 1, // novel
                        PageCount = 200,
                        PublishDate = new DateTime(1999, 09, 20),

                    });
                context.SaveChanges();
            }
        }
    }
}