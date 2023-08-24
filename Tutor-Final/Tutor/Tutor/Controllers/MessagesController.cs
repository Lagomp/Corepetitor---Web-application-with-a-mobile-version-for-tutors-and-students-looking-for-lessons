using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Tutor.Data;
using Tutor.DataTransferObjects;
using Tutor.Models;

namespace Tutor.Controllers
{
    [Authorize]
    public class MessagesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ITutorService _tutorService;

        public MessagesController(ApplicationDbContext context, ITutorService tutorService)
        {
            _context = context;
            _tutorService = tutorService;
        }

        // GET: Messages
        public async Task<IActionResult> Index()
        {
            var currentUser = await _tutorService.GetCurrentUser(User.Identity.Name);
            var allUsers = await _context.Users.Where(x=>x.Id!=currentUser.UserId).ToListAsync();
            ViewBag.Users = allUsers;
            return View(await _context.Messages.ToListAsync());
        }

        public async Task<IActionResult> LoadMessages(string userId)
        {
            var username = User.Identity.Name;
            var currentUser = await _context.Users.Where(x => x.UserName == username).FirstOrDefaultAsync();

            var messages = await _context.Messages.
                Where(x => 
                (x.FromId == currentUser.Id && x.ToId == userId) 
                || x.ToId == currentUser.Id && x.FromId == userId).Select(x => new MessageDto
            {
                IsFromMessage = x.ToId == currentUser.Id ? true : false,
                MessageId = x.Id,
                MessageText = x.MessageText,
                MessageTime = x.Date
            }).ToListAsync();


            return PartialView("_LoadMessages", messages);
        }

        [HttpPost]
        public async Task<IActionResult> SaveMessage(string message, string toId)
        {
            var currentUser = await _tutorService.GetCurrentUser(User.Identity.Name);
            var msg = new Message()
            {
                FromId=currentUser.UserId,
                Date=DateTime.Now,
                MessageText=message,
                ToId=toId
            };
            await _context.Messages.AddAsync(msg);
            await _context.SaveChangesAsync();
            return Json(true);
        }

        // GET: Messages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Messages == null)
            {
                return NotFound();
            }

            var message = await _context.Messages
                .FirstOrDefaultAsync(m => m.Id == id);
            if (message == null)
            {
                return NotFound();
            }

            return View(message);
        }

        // GET: Messages/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Messages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ToId,FromId,MessageText,Date")] Message message)
        {
            if (ModelState.IsValid)
            {
                _context.Add(message);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(message);
        }

        // GET: Messages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Messages == null)
            {
                return NotFound();
            }

            var message = await _context.Messages.FindAsync(id);
            if (message == null)
            {
                return NotFound();
            }
            return View(message);
        }

        // POST: Messages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ToId,FromId,MessageText,Date")] Message message)
        {
            if (id != message.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(message);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MessageExists(message.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(message);
        }

        // GET: Messages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Messages == null)
            {
                return NotFound();
            }

            var message = await _context.Messages
                .FirstOrDefaultAsync(m => m.Id == id);
            if (message == null)
            {
                return NotFound();
            }

            return View(message);
        }

        // POST: Messages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Messages == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Messages'  is null.");
            }
            var message = await _context.Messages.FindAsync(id);
            if (message != null)
            {
                _context.Messages.Remove(message);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MessageExists(int id)
        {
            return _context.Messages.Any(e => e.Id == id);
        }
    }
}
