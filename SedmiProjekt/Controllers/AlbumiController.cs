using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SedmiProjekt.Models;

namespace SedmiProjekt.Controllers
{
    public class AlbumiController : Controller
    {
        private readonly IRepozitorijUpiti _repozitorij;
        public AlbumiController(IRepozitorijUpiti repozitorij)
        {
            _repozitorij = repozitorij;
        }

        public IActionResult Index()
        {
            return View(_repozitorij.PopisAlbuma());
        }

        public IActionResult Create()
        {
            ViewData["ZanrId"] = new SelectList(_repozitorij.PopisZanrova(), "Id", "Naziv");
            int sljedeciId = _repozitorij.SljedeciId();
            Albumi albumi = new Albumi() { Id = sljedeciId };
            return View(albumi);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Izvodac, Album, Cijena, Datum, SlikaUrl, ZanrId")] Albumi albumi)
        {
            ModelState.Remove("Zanr");//uklanjanje veze

            if (ModelState.IsValid)
            {
                _repozitorij.Create(albumi);
                return RedirectToAction("Index"); // ako je sve ok, tu završava metoda 
            }
            //ako je doslo do greške sljedeci dio se izvrsava
            ViewData["ZanrId"] = new SelectList(_repozitorij.PopisZanrova(), "Id", "Naziv", albumi.ZanrId);
            return View(albumi);

        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            if (id < 1)
            {
                return NotFound();
            }

            Albumi albumi= _repozitorij.DohvatiAlbumSaIdom(id);

            if (albumi == null) { return NotFound(); }

            ViewData["ZanrId"] = new SelectList(_repozitorij.PopisZanrova(), "Id", "Naziv", albumi.ZanrId);
            return View(albumi);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, [Bind("Id, Izvodac, Album, Cijena, Datum, SlikaUrl, ZanrId")] Albumi albumi)
        {
            if (id != albumi.Id)
            {
                return NotFound();
            }

            ModelState.Remove("Zanr");

            if (ModelState.IsValid)
            {
                _repozitorij.Update(albumi);
                return RedirectToAction("Index");
            }
            //ako je doslo do greške sljedeci dio se izvrsava
            ViewData["ZanrId"] = new SelectList(_repozitorij.PopisZanrova(), "Id", "Naziv", albumi.ZanrId);
            return View(albumi);

        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id < 1)
            {
                return NotFound();
            }

            var albumi = _repozitorij.DohvatiAlbumSaIdom(Convert.ToInt16(id));

            if (albumi == null)
            {
                return NotFound();
            }

            return View(albumi);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var album = _repozitorij.DohvatiAlbumSaIdom(id);
            _repozitorij.Delete(album);
            return RedirectToAction("Index");

        }

        public ActionResult SearchIndex(string albumZanr, string searchString)
        {
            var zanr = new List<string>();

            var zanrUpit = _repozitorij.PopisZanrova();

            ViewData["albumZanr"] = new SelectList(_repozitorij.PopisZanrova(), "Naziv", "Naziv", zanrUpit);

            var albumi = _repozitorij.PopisAlbuma();

            if (!String.IsNullOrWhiteSpace(searchString))
            {
                albumi = albumi.Where(s => s.Album.Contains(searchString, StringComparison.OrdinalIgnoreCase)); // StringComparison.OrdinalIgnoreCase ignorira velika-mala slova 
            }

            if (string.IsNullOrWhiteSpace(albumZanr))
                return View(albumi);
            else
            {
                return View(albumi.Where(x => x.Zanr.Naziv == albumZanr));
            }

        }



    }
}
