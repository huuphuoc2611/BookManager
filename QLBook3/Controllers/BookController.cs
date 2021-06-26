using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLBook3.Models;

namespace QLBook3.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        public ActionResult ListBook()
        {
            BookManagerContext context = new BookManagerContext();
            var listBook = context.Books.ToList();
            var book = new List<Book>();
            listBook.Add(item: new Book(1, "HTML5 & CSS3 The complete Manual", "Author Name Book 1", " / Content/Images/book1cover.png", "Decsprition 1 ", 1000));
            listBook.Add(new Book(2, "HTML5 & CSS Responsive web Design cookbook", " Author Name Book 2", "/ Content/Images/book2cover.png", "Decsprition 2 ", 1000));
            listBook.Add(new Book(3, " MVC5", "Author Name Book 3", "/Content/Images/book3cover.png", "Decsprition 3 ", 1000));
            return View(listBook);
        }

        //create
        public ActionResult CreateBook()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateBook(Book book)
        {
            BookManagerContext context = new BookManagerContext();
            context.Books.AddOrUpdate(book); //Add or Update Book b
            context.SaveChanges();
            return RedirectToAction("ListBook"); // tên của cái hàm mà mình muốn trở về khi thành công -> tự động chuyển trang từ create sang listbook
        }
        [Authorize]
        public ActionResult Buy(int id)
        {
            BookManagerContext context = new BookManagerContext();
            Book book = context.Books.SingleOrDefault(p => p.ID == id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);


        }

        public ActionResult Edit(int id)
        {
            BookManagerContext context = new BookManagerContext();
            Book book = context.Books.SingleOrDefault(p => p.ID == id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }
        [HttpPost]
        public ActionResult Edit(Book book)
        {
            BookManagerContext context = new BookManagerContext();
            Book bookUpdate = context.Books.SingleOrDefault(p => p.ID == book.ID);
            if (bookUpdate != null)
            {
                //bạn quên set primary cho table nên mới dẫn đến tình trạng sai lúc edit
                context.Books.AddOrUpdate(book);
                context.SaveChanges();
            }
            return RedirectToAction("ListBook");
        }
        public ActionResult Delete(int id)
        {
            BookManagerContext context = new BookManagerContext();
            Book book = context.Books.SingleOrDefault(p => p.ID == id);
            if (book == null)
            {
                return HttpNotFound();

            }
            return View(book);
        }
        [Authorize]
        [HttpPost]
        public ActionResult DeleteBook(int id)
        {
            BookManagerContext context = new BookManagerContext();
            Book book = context.Books.SingleOrDefault(p => p.ID == id);
            if (book != null)
            {
                context.Books.Remove(book);
                context.SaveChanges();

            }
            return RedirectToAction("ListBook");
        }

    }


}
