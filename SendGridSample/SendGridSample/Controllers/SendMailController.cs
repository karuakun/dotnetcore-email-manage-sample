using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SendGridSample.Models;

namespace SendGridSample.Controllers
{
    public class SendMailController : Controller
    {
        private readonly Services.ISmtpClient _client;
        public SendMailController(Services.ISmtpClient client)
        {
            _client = client;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(new SendMailViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Index(SendMailViewModel viewModel)
        {
            await _client.SendMail(
                viewModel.FromAddress,
                new [] {
                    viewModel.ToAddress
                }, 
                viewModel.Message);
            return View(nameof(Index));
        }

    }
}