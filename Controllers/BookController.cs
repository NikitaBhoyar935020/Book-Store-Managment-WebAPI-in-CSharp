using BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Bson;
using System.Net;

namespace BookStore.Controllers
{
   ///This is the router
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        static List<Book> books = new List<Book>();     ///This is the list whoch stored books.

        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return books;                              ///It returns books details.
        }

        //GET api/<BookController>
        [HttpGet("isbn")]
        public ActionResult<Book> Get(string title, string isbn)
        {
            var book = books.FirstOrDefault(x => x.Title == title && x.ISBN == isbn);

            if (book == null)
            {
                return NotFound();                  // Return 404 Not Found if the book is not found
            }

            return Ok(book);                       // Return 200 OK if the book is successfully fetch.

        }

        // POST api/<StudentController>
        [HttpPost]
        public ActionResult Post([FromBody] Book book)
        {
            
            if (books.Any(x => x.ISBN == book.ISBN))
            {
                return BadRequest("Book ISBN is already exits!!");  // Return 400 OK if the book is successfully not submitted.
            }
            books.Add(book);
            return Ok();                                           // Return 200 OK if the book is successfully submitted.
        }


        // PUT api/<StudentController>
        [HttpPut("{isbn}")]                                             
        public ActionResult<Book> Update(string isbn, Book updatedBook)  //This method updated the book details.
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
        public ActionResult DeleteBook(string title, string isbn)         //This method delete the book details.       
        {
                var book = books.FirstOrDefault(x => x.Title == title && x.ISBN == isbn);

                if (book == null)
                {
                    return NotFound();                                  // Return 404 Not Found if the book is not found
                }

                books.Remove(book);
               // books.SaveChanges();

                return Ok();                                            // Return 200 OK if the book is successfully deleted
           
        }

    }
}
