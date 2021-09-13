using BookViewRazor.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookViewRazor.Controllers
{
    [Route("api/Books")]
    [ApiController]
    public class BookController : Controller
    {
        private readonly ApplicationDbContext _db;
        public BookController(ApplicationDbContext db)
        {
            _db = db;
        }
        [HttpGet]
        public IActionResult GetAllBook()
        {
            return Json(new
            {
                data = _db.Books.ToList()
            });
        }
    }
}
