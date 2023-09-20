using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookConsumer.Entities;

namespace BookConsumer.Repositories
{
    public interface IBookRepository
    {
        void Save(Book book);
        List<Book> GetBooks();
        Book GetBook(Guid id);
    }
}