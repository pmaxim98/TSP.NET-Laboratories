using Lab4TSP.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab4Console
{
    class Program
    {
        static void Main(string[] args)
        {
            TestPerson();
            TestOneToMany();
            TestManyToMany();
        }

        static void TestPerson()
        {
            string firstName = Console.ReadLine();
            string middleName = Console.ReadLine();
            string lastName = Console.ReadLine();
            string telephoneNumber = Console.ReadLine();

            using (ModelContext context = new ModelContext())
            {
                Person p = new Person()
                {
                    FirstName = firstName,
                    LastName = middleName,
                    MiddleName = lastName,
                    TelephoneNumber = telephoneNumber
                };

                context.People.Add(p);
                context.SaveChanges();
                var items = context.People;

                foreach (var x in items)
                    Console.WriteLine("{0} {1}", x.Id, x.FirstName);
            }
        }

        static void TestOneToMany()
        {
            Console.WriteLine("One to many association");

            string customerName = Console.ReadLine();
            string cityName = Console.ReadLine();

            using (ModelContext context = new ModelContext())
            {
                Customer c = new Customer()
                {
                    Name = customerName,
                    City = cityName
                };

                Order o1 = new Order()
                {
                    TotalValue = 200,
                    Date = DateTime.Now,
                    Customer = c
                };

                Order o2 = new Order()
                {
                    TotalValue = 300,
                    Date = DateTime.Now,
                    Customer = c
                };

                context.CustomerSet.Add(c);
                context.OrderSet.Add(o1);
                context.OrderSet.Add(o2);
                context.SaveChanges();

                var items = context.CustomerSet;

                foreach (var x in items)
                {
                    Console.WriteLine("Customer : {0}, {1}, {2}", x.CustomerId, x.Name, x.City);

                    foreach (var ox in x.Orders)
                        Console.WriteLine("\tOrders: {0}, {1}, {2}", ox.OrderId, ox.Date, ox.TotalValue);
                }
            }
        }

        static void TestManyToMany()
        {
            Console.WriteLine("Many to many association");

            using (ModelContext context = new ModelContext())
            {
                Console.WriteLine("Enter albums: ");

                int totalAlbums = int.Parse(Console.ReadLine());
                List<Album> albums = new List<Album>();

                for (int i = 0; i < totalAlbums; ++i)
                {
                    Console.Write("[" + i + "] Album Name: ");

                    albums.Add(new Album() { AlbumName = Console.ReadLine() });
                }

                Console.Write("Enter artists: ");

                int totalArtists = int.Parse(Console.ReadLine());
                List<Artist> artists = new List<Artist>();

                for (int i = 0; i < totalArtists; ++i)
                {
                    Artist artist = new Artist();

                    Console.Write(i + " Artist First Name: ");
                    artist.FirstName = Console.ReadLine();

                    Console.Write(i + " Artist Last Name: ");
                    artist.LastName = Console.ReadLine();

                    artists.Add(artist);

                    Console.WriteLine();
                }

                foreach (Artist artist in artists)
                {
                    context.ArtistSet.Add(artist);
                }

                context.SaveChanges();

                Console.WriteLine();
                Console.WriteLine("Everything: ");

                foreach (Artist x in context.ArtistSet.ToList())
                {
                    Console.WriteLine("Artist  : {0}, {1}, {2}", x.ArtistId, x.FirstName, x.LastName);
                }
            }
        }
    }
}
