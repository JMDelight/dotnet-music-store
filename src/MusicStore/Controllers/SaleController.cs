using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MusicStore.Models;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

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
        public IActionResult UserSales()
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            List<Sale> userSales = saleRepo.Sales.Where(s => s.UserId == userId).Include(s => s.Item).ToList();
            ViewBag.UserSales = userSales;
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
        [HttpPost]
        public IActionResult Return(int saleId)
        {
            Sale foundSale = saleRepo.Sales.FirstOrDefault(s => s.SaleId == saleId);
            saleRepo.Remove(foundSale);
            return RedirectToAction("Index", "Item");
        }
    }
}
