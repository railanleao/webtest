using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using webtest.Connection;
using webtest.Models;

namespace webtest.Controllers
{
    public class HomeController : Controller
    {
        private readonly EFContext _context;
        private readonly IConfiguration _configuration;

        private readonly ILogger<HomeController> _logger;

        public HomeController(EFContext context,IConfiguration configuration, ILogger<HomeController> logger)
        {
            _context = context;
            _configuration = configuration;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var context = new EFContext();

            var optionsBuilder = new DbContextOptionsBuilder<EFContext>();
            
            string connString = _configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseNpgsql(connString);
            //Cria a nova base de acordo com as configurações
            var efcontext = new EFContext(optionsBuilder.Options);
            efcontext.Database.EnsureCreated();

            ////return View(await _context.Clientes.ToListAsync());
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}