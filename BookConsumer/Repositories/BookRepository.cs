using BookConsumer.Data;
using BookConsumer.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookConsumer.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly SqlContext context;

        public BookRepository(SqlContext context)
        {
            this.context = context;
        }
        public Book GetBook(Guid id)
        {
            return context.Books.AsNoTracking().FirstOrDefault(q => q.Id == id);
        }

        public List<Book> GetBooks()
        {
            return context.Books.AsNoTracking().ToList();
        }

        public void Save(Book book)
        {
            var isNew = !book.Id.HasValue;

            if(isNew)
            {
                context.Books.Add(book);
                context.SaveChanges();
                return;
            }

            context.Entry(book).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}