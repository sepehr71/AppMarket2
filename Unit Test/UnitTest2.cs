using System;
using Market.Entities.Contracts;
using Market.Entities.Entity;
using Market.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Unit = Market.Entities.Unit;

namespace Unit_Test
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void Test1()
        {

            ItemService itemService = new ItemService();
            ItemContract item = new ItemContract()
            {
                Code = 2323,
                Name = "pencil"
            };
            itemService.SaveCreateOrUpdate(item);
        }
    }
}
