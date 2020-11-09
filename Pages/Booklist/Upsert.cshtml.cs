using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookList.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace MyApp.Namespace
{
    public class UpsertModel : PageModel
    {
          private ApplicationDbContext _db;

        public UpsertModel(ApplicationDbContext db)
        {
            _db = db;
        }
        [BindProperty]
        public Book Book { get; set; }
        
        public async Task<IActionResult> OnGet(int? id)
        {
            Book = new Book();
            
            if(id == null)
            {
                //Create
                return Page();

            }
               //Update
            Book =  await _db.Book.FirstOrDefaultAsync(u => u.ID == id);
            if (Book == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
               if (Book.ID == 0)
               {
                   _db.Book.Add(Book);
               }
               else
               {
                   _db.Book.Update(Book);
                   
               }

                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            return RedirectToPage();
        }

    }
}
