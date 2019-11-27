using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DotNetCore2MVC.Models;
using Microsoft.Extensions.Localization;
using DotNetCore2MVC.Shared;

namespace DotNetCore2MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStringLocalizer<HomeController> _homeControllerCulture;
        private readonly IStringLocalizer<SharedResource> _sharedResourceCulture;

        //Inyectamos en el constructor el _stringLocalizer
        public HomeController(IStringLocalizer<HomeController> homeControllerCulture, IStringLocalizer<SharedResource> sharedResourceCulture)
        {
            _homeControllerCulture = homeControllerCulture;
            _sharedResourceCulture = sharedResourceCulture;
        }

        public IActionResult Index()
        {
            // Para poder visualizar la Cultura se puede enviar por parametro de la siguiente forma
            // https://localhost:44302/?culture=en-US

            string holaMundoCulture = _homeControllerCulture.GetString("HolaMundo");
            string sharedCulture = _sharedResourceCulture .GetString("RecursoCompartido");
            ViewBag.HolaMundo =  string.Format("{0} y {1}",holaMundoCulture, sharedCulture);
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
