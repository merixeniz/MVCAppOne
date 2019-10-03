using MVCAppOne.DAL;
using MVCAppOne.Infrastructure;
using MVCAppOne.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCAppOne.Controllers
{
    public class CartController : Controller
    {
        private ShoppingCartManager shoppingCartManager;

        private ISessionManager sessionManager { get; set; }

        private StoreContext db = new StoreContext(); // tu powinno byc depenedency injection :(

        public CartController()
        {
            this.sessionManager = new SessionManager(); // tu powinno byc depenedency injection :(

            this.shoppingCartManager = new ShoppingCartManager(sessionManager, this.db); // tu powinno byc depenedency injection :(
        }
        
        
        // GET: Cart
        public ActionResult Index()
        {
            var cartItems = shoppingCartManager.GetCart();
            var cartTotalPrice = shoppingCartManager.GetCartTotalPrice();

            CartViewModel cartVM = new CartViewModel() { CartItems = cartItems, TotalPrice = cartTotalPrice};

            return View(cartVM);
        }

        public ActionResult AddToCart(int id)
        {
            shoppingCartManager.AddToCart(id);

            return RedirectToAction("Index");
        }

        public int GetCartItemsCount()
        {
            return shoppingCartManager.GetCartItemsCount();
        }

        public ActionResult RemoveFromCart(int albumID)
        {
            int itemCount = shoppingCartManager.RemoveFromCart(albumID);
            int cartItemsCount = shoppingCartManager.GetCartItemsCount();
            decimal cartTotal = shoppingCartManager.GetCartTotalPrice();

            var result = new CartRemoveViewModel()
            {
                CartTotal = cartTotal,
                CartItemsCount = cartItemsCount,
                RemovedItemCount = itemCount,
                RemoveItemId = albumID
            };

            return Json(result);

        }
    }
}