using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookConsumer.Entities
{
    public class Book
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public string AuthorName { get; set; }
    }
}