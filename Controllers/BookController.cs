using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BookList.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookList.Controllers
{
    [Route("api/Book")]
    [ApiController]
    public class BookController : Controller
    {
        private readonly ApplicationDbContext _db;
        public BookController(ApplicationDbContext db)
        {
            _db = db;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Json(new { data = await _db.Book.ToListAsync()});
        }


        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var BookFromDB = await _db.Book.FirstOrDefaultAsync(u => u.ID == id);
            if (BookFromDB == null)
            {
                return Json (new { success = false, message = "There is an error while deleting"});
            }
            _db.Book.Remove(BookFromDB);
            await _db.SaveChangesAsync();
            return Json (new { success = true, message = "Delete Successfully"});
        }
    }
}
