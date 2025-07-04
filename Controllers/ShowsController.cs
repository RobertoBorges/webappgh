using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using TicketSystem.Data;
using TicketSystem.Models;
using System.Security.Claims;

namespace TicketSystem.Controllers
{
    public class ShowsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ShowsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Shows
        public async Task<IActionResult> Index()
        {
            var shows = await _context.Shows
                .Where(s => s.DateTime > DateTime.Now)
                .OrderBy(s => s.DateTime)
                .ToListAsync();
            return View(shows);
        }

        // GET: Shows/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var show = await _context.Shows
                .FirstOrDefaultAsync(m => m.Id == id);
            if (show == null)
            {
                return NotFound();
            }

            return View(show);
        }

        // POST: Shows/PurchaseTicket
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> PurchaseTicket(int showId, int quantity = 1)
        {
            var show = await _context.Shows.FindAsync(showId);
            if (show == null)
            {
                return NotFound();
            }

            if (show.AvailableTickets < quantity)
            {
                TempData["Error"] = "Not enough tickets available.";
                return RedirectToAction(nameof(Details), new { id = showId });
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            
            for (int i = 0; i < quantity; i++)
            {
                var ticket = new Ticket
                {
                    ShowId = showId,
                    UserId = userId,
                    PurchaseDate = DateTime.Now,
                    PricePaid = show.Price,
                    SeatNumber = $"Seat {show.TotalTickets - show.AvailableTickets + i + 1}"
                };
                _context.Tickets.Add(ticket);
            }

            show.AvailableTickets -= quantity;
            await _context.SaveChangesAsync();

            TempData["Success"] = $"Successfully purchased {quantity} ticket(s) for {show.Title}!";
            return RedirectToAction("MyTickets");
        }

        // GET: Shows/MyTickets
        [Authorize]
        public async Task<IActionResult> MyTickets()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var tickets = await _context.Tickets
                .Include(t => t.Show)
                .Where(t => t.UserId == userId)
                .OrderByDescending(t => t.PurchaseDate)
                .ToListAsync();

            return View(tickets);
        }
    }
}