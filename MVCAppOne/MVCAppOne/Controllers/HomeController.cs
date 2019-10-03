using MVCAppOne.DAL;
using MVCAppOne.Infrastructure;
using MVCAppOne.Models;
using MVCAppOne.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCAppOne.Controllers
{
    public class HomeController : Controller
    {
        private StoreContext db = new StoreContext();

        // GET: Home
        public ActionResult Index()
        {
            var genres = db.Genres.ToList();

            ICacheProvider cache = new DefaultCacheProvider();

            List<Album> newArrivals;

            if (cache.IsSet(Consts.NewItemsCacheKey))
            {
                newArrivals = cache.Get(Consts.NewItemsCacheKey) as List<Album>;
            }
            else
            {
                newArrivals = db.Albums.Where(a => !a.IsHidden).OrderByDescending(a => a.DateAdded).Take(3).ToList();

                cache.Set(Consts.NewItemsCacheKey, newArrivals, 15);
            }

            

            var bestsellers = db.Albums.Where(a => !a.IsHidden && a.IsBestseller).OrderBy(g => Guid.NewGuid()).Take(3).ToList();

            var vm = new HomeViewModel()
            {
                Bestsellers = bestsellers,
                Genres = genres,
                NewArrivals = newArrivals
            };

            //ViewBag.Albumy = vm; //mechanizm Viewbag, ktory nie jest silnie typowany



            return View(vm);
        }

        public ActionResult Download()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "Content/";
            byte[] fileBytes = System.IO.File.ReadAllBytes(path + "simplefile.pdf");
            string fileName = "simplefile.pdf";
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }

        public ActionResult StaticContent(string viewname)
        {
            return View(viewname);
        }
    }
}