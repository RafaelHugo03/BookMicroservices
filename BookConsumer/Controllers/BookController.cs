using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BookConsumer.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BookConsumer.Controllers
{
    [Route("Book")]
    public class BookController : Controller
    {
       private readonly IBookRepository bookRepository;

       public BookController(IBookRepository bookRepository)
       {
            this.bookRepository = bookRepository;
       }

       [HttpGet("get-books")]
       public IActionResult Get()
       {
            return Ok(bookRepository.GetBooks());
       }

       [HttpGet("get-book")]
       public IActionResult GetById(Guid id)
       {
            return Ok(bookRepository.GetBook(id));
       }
    }
}