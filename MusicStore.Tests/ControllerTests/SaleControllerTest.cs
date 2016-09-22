using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Moq;
using MusicStore.Controllers;
using MusicStore.Models;
using MusicStore.Tests.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace MusicStore.Tests.ControllerTests
{
    public class SaleControllerTest : IDisposable
    {
        Mock<ISaleRepository> saleMock = new Mock<ISaleRepository>();
        Mock<IItemRepository> itemMock = new Mock<IItemRepository>();
        EFSaleRepository saleRepo = new EFSaleRepository(new TestDbContext());
        EFItemRepository itemRepo = new EFItemRepository(new TestDbContext());

    //private void DbSetup()
    //{
    //    mock.Setup(m => m.Items).Returns(new Item[]
    //    {
    //        new Item {ItemId = 1, ItemName = "Wash the dog", Stock = 2, BuyPrice = 3, SalePrice = 4  },
    //        new Item {ItemId = 2, ItemName = "Do the dishes", Stock = 2, BuyPrice = 3, SalePrice = 4  },
    //        new Item {ItemId = 3, ItemName = "Sweep the floor", Stock = 2, BuyPrice = 3, SalePrice = 4  }
    //    }.AsQueryable());
    //}

    public void Dispose()
        {
            saleRepo.DeleteAll();
            itemRepo.DeleteAll();
        }

        [Fact]
        public void Db_CreateNewItem_Test()
        {
            //Arrange
            Item testItem = new Item("Bob's Timpano", 10, 16, 5);
            itemRepo.Save(testItem);
            //Act
            Sale newSale = new Sale(testItem.ItemId, null);
            saleRepo.Save(newSale);
            EFItemRepository refreshedItemRepo = new EFItemRepository(new TestDbContext());
            Item updatedItem = refreshedItemRepo.Items.FirstOrDefault(i => i.ItemId == testItem.ItemId);
            int expectedResult = 4;
            int result = updatedItem.Stock;
            //Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Db_ReverseSale_Test()
        {
            //Arrange
            Item testItem = new Item("Bob's Timpano", 10, 16, 5);
            itemRepo.Save(testItem);
            Sale newSale = new Sale(testItem.ItemId, null);
            saleRepo.Save(newSale);
            //Act
            saleRepo.Remove(newSale);
            EFItemRepository refreshedItemRepo = new EFItemRepository(new TestDbContext());
            Item updatedItem = refreshedItemRepo.Items.FirstOrDefault(i => i.ItemId == testItem.ItemId);
            int expectedResult = 5;
            int result = updatedItem.Stock;
            //Assert
            Assert.Equal(expectedResult, result);
        }


    }
}
