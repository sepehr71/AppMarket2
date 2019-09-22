using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using FluentNHibernate;
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

                    Guid movie1Id = GetMovieId1();
                    Movie movie1 = session.Get<Movie>(movie1Id);

                    Guid movie2Id = GetMovieId2();
                    Movie movie2 = session.Get<Movie>(movie2Id);

                    Guid producer1Id = GetProducerId1();
                    Producer producer1 = session.Get<Producer>(producer1Id);

                    Guid producer2Id = GetProducerId2();
                    Producer producer2 = session.Get<Producer>(producer2Id);

                    Guid producer3Id = GetProducerId3();
                    Producer producer3 = session.Get<Producer>(producer3Id);


                    movie1.Producers.Add(producer1);
                    movie1.Producers.Add(producer2);
                    movie1.Producers.Add(producer3);

                    movie2.Producers.Add(producer1);
                    movie2.Producers.Add(producer2);
                    movie2.Producers.Add(producer3);

                    session.Save(movie1);
                    session.Save(movie2);
                    transaction.Commit();

                    //...........................................................
                    var query1 = session.QueryOver<Producer>().Where(x => x.Name == "alfred-hitchcock");

                    var result1 = session.Get<Producer>(producer1.Id);
                    Assert.AreEqual(producer1.Name, result1.Name);

                    var result2 = session.Get<Producer>(producer2.Id);
                    Assert.AreEqual(producer2.Name, result2.Name);

                    var result3 = session.Get<Producer>(producer3.Id);
                    Assert.AreEqual(producer3.Name ,result3.Name );
                    
                    var result4 = session.Get<Movie>(movie1.Id);
                    Assert.AreEqual(movie1.name,result4.name);

                    var result5 = session.Get<Movie>(movie2.Id);
                    Assert.AreEqual(movie2.name , result5.name);
                }
            }
        }

        private Guid GetMovieId1()
        {
            using (var session = NhibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var item = session.QueryOver<Item>().Where(x => x.Name == "pen");
                    Movie m1 = new Movie
                    {
                        name = "vertigo"
                    };
                    session.Save(m1);
                    transaction.Commit();

                    m1 = session.Get<Movie>(m1.Id);
                    return m1.Id;
                }
            }
        }

        private Guid GetMovieId2()
        {
            using (var session = NhibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    Movie m2 = new Movie
                    {
                        name = "psycho"
                    };
                    session.Save(m2);
                    transaction.Commit();

                    m2 = session.Get<Movie>(m2.Id);
                    return m2.Id;
                }
            }
        }

        private Guid GetProducerId1()
        {
            using (var session = NhibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    Producer p1 = new Producer
                    {
                        Name = "alfred-hitchcock"
                    };
                    session.Save(p1);
                    transaction.Commit();

                    p1 = session.Get<Producer>(p1.Id);
                    return p1.Id;
                }
            }
        }

        private Guid GetProducerId2()
        {
            using (var session = NhibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    Producer p2 = new Producer
                    {
                        Name = "john-brady"
                    };
                    session.Save(p2);
                    transaction.Commit();

                    p2 = session.Get<Producer>(p2.Id);
                    return p2.Id;
                }
            }
        }


        private Guid GetProducerId3()
        {
            using (var session = NhibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    Producer p3 = new Producer
                    {
                        Name = "domenech-decocko"
                    };
                    session.Save(p3);
                    transaction.Commit();

                    p3 = session.Get<Producer>(p3.Id);
                    return p3.Id;

                }
            }
        }
    }
}


