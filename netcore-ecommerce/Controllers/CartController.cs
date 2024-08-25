using Microsoft.AspNetCore.Mvc;
using netcore_ecommerce.Data;
using netcore_ecommerce.DTO;
using netcore_ecommerce.Models;
using netcore_ecommerce.Session;

namespace netcore_ecommerce.Controllers {
    public class CartController: Controller {
        private readonly ApplicationDbContext _context;

        public CartController(ApplicationDbContext context) {
            _context = context;
        }

        // GET: CartController
        public ActionResult Index() {
            List<Cart> items = HttpContext.Session.GetJson<List<Cart>>("Cart") ?? new List<Cart>();
            CartViewModel cartVM = new() {Items = items, GrandTotal = items.Sum(x => x.Quantity * x.Price)};
            return View();
        }
    }
}