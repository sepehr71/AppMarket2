using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Market.Data;
using Market.Entities.Entity;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var session = NhibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    //var query = session.QueryOver<Movie>().Where(x => x.name == "alfred-hitchcock").SingleOrDefault();
                    //string s= query.name.ToString();
                    //Console.WriteLine(s);

                    
                   
                }
            }
        }
    }
}
