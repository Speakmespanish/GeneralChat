using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using GeneralChat.UI.Presentation.Models;
using GeneralChat.UI.Presentation.Data;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace GeneralChat.UI.Presentation.Controllers
{
    [Authorize]
    public class ChatController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public ChatController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Chat() => View();

        [HttpPost]
        public async Task<IActionResult> SendMessage([FromBody] ChatMessage message)
        {
            message.Usuario = User.Identity.Name;
            _context.ChatMessages.Add(message);
            await _context.SaveChangesAsync();
            return Json(new { status = "Message sent" });
        }

        public async Task<IActionResult> GetMessages()
        {
            var messages = await _context.ChatMessages.OrderBy(m => m.FechaHora).ToListAsync();
            return Json(messages.Select(m => new { m.Usuario, FechaHora = m.FechaHora.ToString("yyyy-MM-dd HH:mm:ss"), m.Mensaje }));
        }
    }
}
