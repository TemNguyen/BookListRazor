using BookViewRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public async Task<IActionResult> GetAllBook()
        {
            return Json(new
            {
                data = await _db.Books.ToListAsync()
            });
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var bookInDb = await _db.Books.FirstOrDefaultAsync(p => p.Id == id);

            if (bookInDb == null)
            {
                return Json(new
                {
                    success = false,
                    message = "Error while deleting."
                });
            }

            _db.Books.Remove(bookInDb);
            await _db.SaveChangesAsync();
            return Json(new
            {
                success = true,
                message = "Delete success!"
            });
        }
    }
}
