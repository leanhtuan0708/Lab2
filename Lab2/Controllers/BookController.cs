using Lab2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab2.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        public String HelloTeacher(String name) {
            return "Hello Lê Anh Tuấn" +name;
        }
        public ActionResult ListBook()
        {
            var books = new List<string>();
            books.Add("HTML5 & CSS3 The complete Manual - Author Name Book 1");
            books.Add("HTML 5 & CSS3 Responsive web Design");
            books.Add("Professional ASP.NET MVC5 Book");
            ViewBag.Books = books;
;           return View();
        }
        public ActionResult ListBookModel()
        {
            var books = new List<Book>();
            books.Add(new Book(1, "HTML5 & CSS3 The complete Manual","Author Name Book 1", "/Content/Images/book1.jpg"));
            books.Add(new Book(2, "HTML5 & CSS3 The complete Manua2", "Author Name Book 2", "/Content/Images/book2.jpg"));
            books.Add(new Book(3, "HTML5 & CSS3 The complete Manua3", "Author Name Book 3", "/Content/Images/book3.jpg"));
            return View(books);
        }
        public ActionResult EditBook(int id) {
            var books = new List<Book>();
            books.Add(new Book(1, "HTML5 & CSS3 The complete Manual", "Author Name Book 1", "/Content/Images/book1.jpg"));
            books.Add(new Book(2, "HTML5 & CSS3 The complete Manua2", "Author Name Book 2", "/Content/Images/book2.jpg"));
            books.Add(new Book(3, "HTML5 & CSS3 The complete Manua3", "Author Name Book 3", "/Content/Images/book3.jpg"));
            //check if not exit
            Book book = new Book();
            foreach(Book b in books)
            {
                if (b.Id == id) {
                    book = b;
                    break;
                }
            }
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }
        [HttpPost, ActionName("EditBook")]
        [ValidateAntiForgeryToken]
        public ActionResult EditBook(int Id, string Title, string Author, string Imagecover)
        {

            var books = new List<Book>();
            books.Add(new Book(1, "HTML5 & CSS3 The complete Manual", "Author Name Book 1", "/Content/Images/book1.jpg"));
            books.Add(new Book(2, "HTML5 & CSS3 The complete Manua2", "Author Name Book 2", "/Content/Images/book2.jpg"));
            books.Add(new Book(3, "HTML5 & CSS3 The complete Manua3", "Author Name Book 3", "/Content/Images/book3.jpg"));
            //check if not exit
            if (Id == null)
            {
                return HttpNotFound();
            }
            foreach (Book b in books)
            {
                if (b.Id == Id)
                {
                    b.Title = Title;
                    b.Author = Author;
                    b.Imagecover = Imagecover;
                    break;
                }
            }

            return View("ListBookModel", books);
        }
        public ActionResult CreateBook() {
            return View();
        }
        [HttpPost, ActionName("CreateBook")]
        [ValidateAntiForgeryToken]
        public ActionResult Contact([Bind(Include = "Id,Title,Author,Imagecover")]Book book)
        {
            var books = new List<Book>();
            books.Add(new Book(1, "HTML5 & CSS3 The complete Manual", "Author Name Book 1", "/Content/Images/book1.jpg"));
            books.Add(new Book(2, "HTML5 & CSS3 The complete Manua2", "Author Name Book 2", "/Content/Images/book2.jpg"));
            books.Add(new Book(3, "HTML5 & CSS3 The complete Manua3", "Author Name Book 3", "/Content/Images/book3.jpg"));
            try
            {
                if (ModelState.IsValid)
                {

                    books.Add(book);
                }
            }
            catch (Exception /* dex */) {
            }
            return View("ListBookModel", books);
        }
        public ActionResult DeleteBook() 
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteBook(int? Id)
        {
            var books = new List<Book>();
            books.Add(new Book(1, "HTML5 & CSS3 The complete Manual", "Author Name Book 1", "/Content/Images/book1.jpg"));
            books.Add(new Book(2, "HTML5 & CSS3 The complete Manua2", "Author Name Book 2", "/Content/Images/book2.jpg"));
            books.Add(new Book(3, "HTML5 & CSS3 The complete Manua3", "Author Name Book 3", "/Content/Images/book3.jpg"));
            //check if not exit
            foreach (Book b in books)
            {
                if (b.Id == Id)
                {
                    books.Remove(b);
                    break;
                }
            }
            return View("ListBookModel", books);
        }

    }
}