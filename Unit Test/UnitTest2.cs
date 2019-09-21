using System;
using Market.Data;
using Market.Entities.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Unit_Test
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void TestMethod1()
        {
          
                using (var session = NhibernateHelper.OpenSession())
                {
                    using (var transaction = session.BeginTransaction())
                    {

                        SaleOrder so1 = new SaleOrder {CreationDate = DateTime.Now , Title = "sale1" };
                        //var item1 = GetItem();
                        Item i1 = new Item { Name = "pen" };
                        SaleOrderItem soi1 = new SaleOrderItem{Quantity = 12, NetPrice = 1, Item = i1, TotalPrice = 12, UnitPrice = 1};
                        

                        //RackItemLevel ril = new RackItemLevel { CurrentQuantity = 80, Item = item, Rack = rack1, InQuantity = 23, OutQuantity = 23 };
                        session.Save(i1);
                        so1.SaleOrderItem.Add(soi1);
                        session.Save(so1);
                        //session.SaveOrUpdate(soi1);
                        transaction.Commit(); 
                        //var soi2 = session.Get<>();
                        // Assert.AreEqual(soi1,soi2);
                    } 
                }
            
        }
    }
}
