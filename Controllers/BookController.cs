using BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Bson;
using System.Net;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        static List<Book> books = new List<Book>();

        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return books;
        }

        //GET api/<BookController>
        [HttpGet("isbn")]
        public ActionResult<Book> Get(string title, string isbn)
        {
            var book = books.FirstOrDefault(x => x.Title == title && x.ISBN == isbn);

            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);

        }

        // POST api/<StudentController>
        [HttpPost]
        public ActionResult Post([FromBody] Book book)
        {
            
            if (books.Any(x => x.ISBN == book.ISBN))
            {
                return BadRequest("Book ISBN is already exits!!");
            }
            books.Add(book);
            return Ok();
        }


        // PUT api/<StudentController>
        [HttpPut("{isbn}")]    
        public ActionResult<Book> Update(string isbn, Book updatedBook)
        {
            var book = books.FirstOrDefault(x => x.ISBN == isbn);

            if (book == null)
            {
                return NotFound();  
            }

            book.Title = updatedBook.Title;
            book.AuthorName = updatedBook.AuthorName;
            book.BookVersion = updatedBook.BookVersion;
            book.Price = updatedBook.Price;
            book.Quantity = updatedBook.Quantity;

            return Ok(book);
        }
        //Delete api/<DeleteController>
        [HttpDelete]
        public ActionResult DeleteBook(string title, string isbn)
        {
                var book = books.FirstOrDefault(x => x.Title == title && x.ISBN == isbn);

                if (book == null)
                {
                    return NotFound(); // Return 404 Not Found if the book is not found
                }

                books.Remove(book);
               // books.SaveChanges();

                return Ok(); // Return 200 OK if the book is successfully deleted
           
        }

    }
}
