using System;
using System.Collections.Generic;
using Market.Data;
using Market.Entities.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Unit_Test
{
    [TestClass]
    public class UnitTest4
    {
        [TestMethod]
        public void TestMethod1()
        {
            using (var session = NhibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    Movie m1 = new Movie
                    {
                        name = "vertigo"
                    };
                    Movie m2 = new Movie
                    {
                        name = "psycho"
                    };
                    Producer p1 = new Producer
                    {
                        Name = "alfred-hitchcock"
                    };
                    Producer p2 = new Producer
                    {
                        Name = "john-brady"
                    };
                    Producer p3 = new Producer
                    {
                        Name = "domenech-decocko"
                    };
                    m1.Producers.Add(p1);
                    m1.Producers.Add(p2);
                    m1.Producers.Add(p3);
                    m2.Producers.Add(p1);
                    m2.Producers.Add(p2);
                    m2.Producers.Add(p3);
                    session.Save(m1);
                    session.Save(m2);
                    transaction.Commit();
                }
            }
        }
    }
}
