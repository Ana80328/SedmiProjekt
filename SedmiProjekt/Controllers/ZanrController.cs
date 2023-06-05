using Microsoft.AspNetCore.Mvc;
using SedmiProjekt.Models;

namespace SedmiProjekt.Controllers
{
    public class ZanrController : Controller
    {
        private readonly IRepozitorijUpiti _repozitorij;
            public ZanrController(IRepozitorijUpiti repozitorij)
            {
                _repozitorij= repozitorij;
            }

            public IActionResult Index()
            {
                return View(_repozitorij.PopisZanrova());
            }

            public IActionResult Create()
            {

                int sljedeciId = _repozitorij.ZanrSljedeciId(); // ova metoda je dodana i u repozitorij, zaboravio na nju
                Zanr zanr = new Zanr() { Id = sljedeciId };
                return View(zanr);
            }

            [HttpPost]
            [ValidateAntiForgeryToken]
            public IActionResult Create([Bind("Id,Naziv")] Zanr zanr)
            {
                ModelState.Remove("Albums");//uklanjanje veze

                if (ModelState.IsValid)
                {
                    _repozitorij.Create(zanr);
                    return RedirectToAction("Index"); // ako je sve ok, tu završava metoda 
                }
                //ako je doslo do greške sljedeci dio se izvrsava
                return View(zanr);

            }

            [HttpGet]
            public IActionResult Update(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }
                var zanr = _repozitorij.DohvatiZanrSaIdom(Convert.ToInt32(id));
                if (zanr == null)
                {
                    return NotFound();
                }
                return View(zanr);
            }

            [HttpPost]
            [ValidateAntiForgeryToken]
            public IActionResult Update(int id, [Bind("Id,Naziv")] Zanr zanr)
            {
                if (id != zanr.Id)
                {
                    return NotFound();
                }

                ModelState.Remove("Albums");//uklanjanje veze

                if (ModelState.IsValid)
                {
                    _repozitorij.Update(zanr);
                    return RedirectToAction("Index");
                }
                return View(zanr);
            }

            [HttpGet]
            public IActionResult Delete(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }
                var zanr = _repozitorij.DohvatiZanrSaIdom(Convert.ToInt32(id));
                if (zanr == null)
                {
                    return NotFound();
                }
                return View(zanr);
            }


            [HttpPost]
            public IActionResult Delete(int id)
            {
                var zanr = _repozitorij.DohvatiZanrSaIdom(Convert.ToInt32(id));
                _repozitorij.Delete(zanr);
                return RedirectToAction("Index");
            }
        }
    }
