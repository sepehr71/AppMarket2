using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Market.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Market.Entities;
using Market.Entities.Entity;
using NHibernate.Linq;

namespace Unit_Test
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void ItemTest()
        {
            using (var session = NhibernateHelper.OpenSession())
            {
                var itemId = GetItemId();
                Item item = session.Get<Item>(itemId);

                var res = session.Get<Item>(item.Id);
                Assert.AreEqual(item.Name, res.Name);
            }
        }
        private Guid GetItemId()
        {
            using (var session = NhibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    Item item = new Item
                    {
                        Name = "Pen",
                        Unit = Unit.Number
                    };

                    session.Save(item);
                    transaction.Commit();

                    item = session.Get<Item>(item.Id);
                    return item.Id;
                }
            }
        }

        [TestMethod]
        public void RackTest()
        {
            using (var session = NhibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var rack = new Rack
                    {
                        Name = "First",
                        Code = 10,
                        Limit = 700,
                        Location = "First Flat"
                    };

                    session.Save(rack);
                    transaction.Commit();

                    var res = session.Get<Rack>(rack.Id);
                    Assert.AreEqual(rack.Limit, res.Limit);
                }
            }
        }
        private Guid GetRackId()
        {
            using (var session = NhibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var rack = new Rack
                    {
                        Name = "First",
                        Code = 10,
                        Limit = 700,
                        Location = "First Flat"
                    };

                    session.Save(rack);
                    transaction.Commit();

                    rack = session.Get<Rack>(rack.Id);
                    return rack.Id;
                }
            }
        }


        [TestMethod]
        public void PurchaseOrderItemTest()
        {
            using (var session = NhibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var itemId = GetItemId();
                    Item item = session.Get<Item>(itemId);

                    var racckId = GetRackId();
                    Rack rack = session.Get<Rack>(racckId);


                    PurchaseOrder po = new PurchaseOrder { CreationDate = DateTime.Now, Title = "purchase1" };
                    PurchaseOrderItem purchaseOrderItem = new PurchaseOrderItem
                    {
                        NetPrice = 30,
                        UnitPrice = 50,
                        Quantity = 900,
                        Item = item,
                        Rack = rack
                    };

                    po.PurchaseOrderItem.Add(purchaseOrderItem);
                    session.Save(po);
                    transaction.Commit();

                    var res = session.Get<PurchaseOrderItem>(purchaseOrderItem.Id);
                    Assert.AreEqual(purchaseOrderItem.NetPrice, res.NetPrice);
                }
            }
        }
    }
}
