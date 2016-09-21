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
    public class ItemsControllerTest : IDisposable
    {
        Mock<IItemRepository> mock = new Mock<IItemRepository>();
        EFItemRepository db = new EFItemRepository(new TestDbContext());
        private void DbSetup()
        {
            mock.Setup(m => m.Items).Returns(new Item[]
            {
                new Item {ItemId = 1, ItemName = "Wash the dog", Stock = 2, BuyPrice = 3, SalePrice = 4  },
                new Item {ItemId = 2, ItemName = "Do the dishes", Stock = 2, BuyPrice = 3, SalePrice = 4  },
                new Item {ItemId = 3, ItemName = "Sweep the floor", Stock = 2, BuyPrice = 3, SalePrice = 4  }
            }.AsQueryable());
        }
        [Fact]
        public void Mock_GetViewResultIndex_Test()
        {
            //Arrange
            DbSetup();
            ItemController controller = new ItemController(mock.Object);
            //Act
            var result = controller.Index();
            

            //Assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Mock_FindEntryInCollection_Test()
        {
            //Arrange
            DbSetup();
            ItemController controller = new ItemController(mock.Object);
            Item item = new Item { ItemId = 1, ItemName = "Wash the dog", Stock = 2, BuyPrice = 3, SalePrice = 4 };
            //Act
            var view = controller.Index() as ViewResult;
            var collection = view.ViewData.Model as IEnumerable<Item>;
            //Assert
            Assert.Contains(item, collection);
        }
        [Fact]
        public void Db_CreateNewItem_Test()
        {
            //Arrange
            DbSetup();
            ItemController controller = new ItemController(db);
            //Act
            Item testItem = new Item("Bob's Timpano", 10, 16, 5);
            controller.Create(testItem);
            var view = controller.Index() as ViewResult;
            var collection = view.ViewData.Model as IEnumerable<Item>;

            //Assert
            Assert.Contains<Item>(testItem, collection);
        }
        [Fact]
        public void Db_EditItem_Test()
        {
            //Arrange
            DbSetup();
            ItemController controller = new ItemController(db);
            Item testItem = new Item("Bob's Timpano", 10, 16, 5);
            controller.Create(testItem);

            //Act
            testItem.ItemName = "Bill's Timpano";
            EFItemRepository newDb = new EFItemRepository(new TestDbContext());
            controller.Edit(testItem);
            var collection = newDb.Items.ToList(); 
            //Assert
            Assert.Contains<Item>(testItem, collection);
        }

        public void Dispose()
        {
            db.DeleteAll();
        }
    }
}
