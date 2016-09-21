using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MusicStore.Models;
using System.Security.Claims;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MusicStore.Controllers
{
    public class SaleController : Controller
    {
        private ISaleRepository saleRepo;

        public SaleController(ISaleRepository thisRepo = null)
        {
            if (thisRepo == null)
            {
                this.saleRepo = new EFSaleRepository();
            }
            else
            {
                this.saleRepo = thisRepo;
            }
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public  IActionResult Create(int itemId)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            Sale newSale = new Sale(itemId, userId);
            saleRepo.Save(newSale);
            return RedirectToAction("Index", "Item");
        }
    }
}
