using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult about()
        {
            ViewBag.Name = "Anna";
            ViewBag.godzina = DateTime.Now.Hour;
            ViewBag.powitanie = ViewBag.godzina < 17 ? "Dzien Dobry" : "Dobry wieczor";

            Dane[] osoby =
            {
                new Dane{Name = "Przemo",Surname = "Kwiatek"},
                new Dane{Name = "Toemk",Surname = "Kwiatek"},
                new Dane{Name = "kasia",Surname = "nowak"},
                new Dane{Name = "basia",Surname = "grabki"},
            };
            return View(osoby);
        }

        public IActionResult UrodzinyForm()
        {
            return View();
        }

        public IActionResult Urodziny(Urodziny urodziny)
        {
            ViewBag.powitanie = $"Witaj {urodziny.Imie} {DateTime.Now.Year - urodziny.Rok}";
            return View();
        }

        public IActionResult CalcForm()
        {
            return View();
        }

        public IActionResult Calc(Inp inp)
        {
            switch (inp.wybor)
            {
                case "dodawanie":
                    ViewBag.wynik = $"Wynik dodawania {inp.x + inp.y}";
                    break;
                case "odejmowanie":
                        ViewBag.wynik = $"Wynik odejmowania {inp.x - inp.y}";
                    break;
                case "mnozenie":
                    ViewBag.wynik = $"Wynik dodawania {inp.x * inp.y}";
                    break;
                case "dzielenie":
                    if (inp.y != 0)
                    {
                        ViewBag.wynik = $"Wynik dodawania {inp.x / inp.y}";
                    }
                    else
                    {
                        ViewBag.wynik = $"Nie dzielimy przez 0";
                    }
                    break;
                default:
                    ViewBag.wynik = $"Error";
                    break;
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}