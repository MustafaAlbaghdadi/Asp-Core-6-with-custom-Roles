using System;
using aspcore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using aspcore.Models.Shared;
using Microsoft.Extensions.Logging;

namespace aspcore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger , IServiceProvider serviceProvider)
        {
            _logger = logger;

            //string userPWD = "Alpha@1Mega";
            //await userManager.CreateAsync(userAdmin, userPWD);
            //var user = await userManager.FindByNameAsync("TrueMan");
            //if (!(await userManager.IsInRoleAsync(user, "Admin")))
            //    await userManager.AddToRoleAsync(user, "Admin");

         //   Initializer.CreateRoles(serviceProvider).Wait();

        }

        [Authorize(Roles =UserType.Admin)]
        public IActionResult Index()
        {

           


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