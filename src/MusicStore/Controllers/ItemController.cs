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
    public class ItemController : Controller
    {
        private IItemRepository itemRepo;
        private ISaleRepository saleRepo;

        public ItemController(IItemRepository thisRepo = null, ISaleRepository thisSaleRepo = null)
        {
            if (thisRepo == null) this.itemRepo = new EFItemRepository();
            else this.itemRepo = thisRepo;

            if (thisSaleRepo == null) this.saleRepo = new EFSaleRepository();
            else this.saleRepo = thisSaleRepo;
        }


       
        public IActionResult Index()
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            List<Sale> userSales = saleRepo.Sales.Where(s => s.UserId == userId).Include(s => s.Item).ToList();
            ViewBag.UserSales = userSales;
            return View(itemRepo.Items.ToList());
        }
        public IActionResult Inventory()
        {
            return View(itemRepo.Items.ToList());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Item item)
        {
            itemRepo.Save(item);
            return RedirectToAction("Inventory");
        }
        public IActionResult Edit(int id)
        {
            Item thisItem = itemRepo.Items.FirstOrDefault(x => x.ItemId == id);
            return View(thisItem);
        }

        [HttpPost]
        public IActionResult Edit(Item item)
        {
            itemRepo.Edit(item);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            Item thisItem = itemRepo.Items.FirstOrDefault(x => x.ItemId == id);
            return View(thisItem);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            Item thisItem = itemRepo.Items.FirstOrDefault(x => x.ItemId == id);
            itemRepo.Remove(thisItem);
            return RedirectToAction("Index");
        }
    }
}
