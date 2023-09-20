using BookPublisher.Entities;
using BookPublisher.Service;
using Microsoft.AspNetCore.Mvc;

namespace BookPublisher.Controllers
{
    [Route("Book")]
    public class BookController : Controller
    {
        private readonly IMessageBusService messageBus;

        public BookController(IMessageBusService messageBus)
        {
            this.messageBus = messageBus;
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] Book book)
        {
            book.Id = null;

            messageBus.Publish(book, "book-queue");
            return Json(new{
                Message = "Livro publicado na fila de mensagens"
            });
        }

        [HttpPost("edit")]
        public IActionResult Edit([FromBody] Book book)
        {
            if(book.Id == null) return BadRequest("Id não pode ser nulo");

            messageBus.Publish(book, "book-queue");
            return Json(new{
                Message = "Livro publicado na fila de mensagens"
            });
        }
    }
}