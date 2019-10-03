using MVCAppOne.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCAppOne.Controllers
{
    public class StoreController : Controller
    {
        // GET: Store
        StoreContext db = new StoreContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            var albumdetails = db.Albums.Find(id);

            return View(albumdetails);
        }

        public ActionResult List(string genrename, string searchQuery = null)
        {
            // pobierz gatunek i wszystkie albumy powiazane z nim
            var genre = db.Genres.Include("Albums").Where(g => g.Name.ToUpper() == genrename.ToUpper()).Single();
            var albums = genre.Albums.Where(a => (searchQuery == null ||
                                                  a.AlbumTitle.ToLower().Contains(searchQuery.ToLower()) ||
                                                  a.ArtistName.ToLower().Contains(searchQuery.ToLower())) &&
                                                  !a.IsHidden);

            if (Request.IsAjaxRequest())
            {
                return PartialView("_ProductList", albums);
            }

            return View(albums);
        }

        [ChildActionOnly] // nie mozna sie dostac bezposrednio do tej akcji, jedynie wywolana z "podrzadania" w jakims widoku
        [OutputCache(Duration = 80000)]
        //[OutputCache(Location = System.Web.UI.OutputCacheLocation.Any/Client/Server/)] - ustawienie lokalizacji gdzie cachujemy pliki, domyslnie Any
        public ActionResult GenresMenu()
        {          
            var genres = db.Genres.ToList();

            return PartialView("_GenresMenu", genres);
        }

        public ActionResult AlbumsSuggestions(string term)
        {
            var albums = this.db.Albums.Where(a => !a.IsHidden && a.AlbumTitle.ToLower().Contains(term.ToLower()))
                .Take(5).Select(a => new { label = a.AlbumTitle });

            return Json(albums, JsonRequestBehavior.AllowGet);
        }
    }
}