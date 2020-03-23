using System;
using System.Linq;

namespace TSP5Lab
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("TEST SELF REFERENCES CASE");
            TestSelfReferenceCase();
            Console.WriteLine();

            Console.WriteLine("TEST PRODUCT CASE");
            TestProductCase();
            Console.WriteLine();

            Console.WriteLine("TEST PHOTOGRAPHS CASE");
            TestPhotographsCase();
            Console.WriteLine();

            Console.WriteLine("TEST BUSINESS CASE");
            TestBusinessCase();
            Console.WriteLine();

            Console.WriteLine("TEST EMPLOYEE CASE");
            TestEmployeeCase();
            Console.WriteLine();
        }

        private static void TestEmployeeCase()
        {
            using (var context = new EmployeeContext())
            {
                context.Employees.RemoveRange(context.Employees);

                var fte = new FullTimeEmployee
                {
                    FirstName = "Jane",
                    LastName = "Doe",
                    Salary = 71500M
                };

                context.Employees.Add(fte);

                fte = new FullTimeEmployee
                {
                    FirstName = "John",
                    LastName = "Smith",
                    Salary = 62500M
                };

                context.Employees.Add(fte);

                var hourly = new HourlyEmployee
                {
                    FirstName = "Tom",
                    LastName = "Jones",
                    Wage = 8.75M
                };

                context.Employees.Add(hourly);
                context.SaveChanges();
            }

            using (var context = new EmployeeContext())
            {
                Console.WriteLine("--- All Employees ---");
                foreach (var emp in context.Employees)
                {
                    bool fullTime = emp is HourlyEmployee ? false : true;
                    Console.WriteLine("{0} {1} ({2})", emp.FirstName, emp.LastName,
                    fullTime ? "Full Time" : "Hourly");
                }

                Console.WriteLine("--- Full Time ---");
                foreach (var fte in context.Employees.OfType<FullTimeEmployee>())
                {
                    Console.WriteLine("{0} {1}", fte.FirstName, fte.LastName);
                }

                Console.WriteLine("--- Hourly ---");
                foreach (var hourly in context.Employees.OfType<HourlyEmployee>())
                {
                    Console.WriteLine("{0} {1}", hourly.FirstName,
                    hourly.LastName);
                }
            }
        }

        private static void TestBusinessCase()
        {
            using (var context = new BusinessDbContext())
            {
                context.bussiness.RemoveRange(context.bussiness);

                var business = new Business
                {
                    Name = "Corner Dry Cleaning",
                    LicenseNumber = "100x1"
                };

                context.bussiness.Add(business);

                var retail = new Retail
                {
                    Name = "Shop and Save",
                    LicenseNumber =
                "200C",
                    Address = "101 Main",
                    City = "Anytown",
                    State = "TX",
                    ZIPCode = "76106"
                };

                context.bussiness.Add(retail);

                var web = new eCommerce
                {
                    Name = "BuyNow.com",
                    LicenseNumber =
                "300AB",
                    URL = "www.buynow.com"
                };

                context.bussiness.Add(web);
                context.SaveChanges();
            }

            using (var context = new BusinessDbContext())
            {
                Console.WriteLine("\n--- All Businesses ---");

                foreach (var b in context.bussiness)
                {
                    Console.WriteLine("{0} (#{1})", b.Name, b.LicenseNumber);
                }

                Console.WriteLine("\n--- Retail Businesses ---");
                foreach (var r in context.bussiness.OfType<Retail>())
                {
                    Console.WriteLine("{0} (#{1})", r.Name, r.LicenseNumber);
                    Console.WriteLine("{0}", r.Address);
                    Console.WriteLine("{0}, {1} {2}", r.City, r.State, r.ZIPCode);
                }

                Console.WriteLine("\n--- eCommerce Businesses ---");
                foreach (var e in context.bussiness.OfType<eCommerce>())
                {
                    Console.WriteLine("{0} (#{1})", e.Name, e.LicenseNumber);
                    Console.WriteLine("Online address is: {0}", e.URL);
                }
            }
        }

        private static void TestPhotographsCase()
        {
            byte[] thumbBits = new byte[100];
            byte[] fullBits = new byte[2000];

            using (var context = new PhotographDbContext())
            {
                context.Photographs.RemoveRange(context.Photographs);
                context.PhotographFullImages.RemoveRange(context.PhotographFullImages);

                var photo = new Photograph
                {
                    Title = "My Dog",
                    ThumbnailBits = thumbBits
                };

                var fullImage = new PhotographFullImage
                {
                    HighResolutionBits = fullBits
                };

                photo.PhotographFullImage = fullImage;
                context.Photographs.Add(photo);
                context.SaveChanges();
            }

            using (var context = new PhotographDbContext())
            {
                foreach (var photo in context.Photographs)
                {
                    Console.WriteLine("Photo: {0}, ThumbnailSize {1} bytes", photo.Title, photo.ThumbnailBits.Length);

                    context.Entry(photo).Reference(p => p.PhotographFullImage).Load();

                    Console.WriteLine("Full Image Size: {0} bytes", photo.PhotographFullImage.HighResolutionBits.Length);
                }
            }
        }

        private static void TestSelfReferenceCase()
        {
            AddSelfReferenceToDatabase();
            ShowSelfReferenceDataBase();
        }

        static void AddSelfReferenceToDatabase()
        {
            using (ModelSelfRefrences modelSelfRefrences = new ModelSelfRefrences())
            {
                modelSelfRefrences.SelfReferences.RemoveRange(modelSelfRefrences.SelfReferences);

                SelfReference parent = new SelfReference();

                parent.Name = "Parent";

                for (int i = 0; i < 5; ++i)
                {
                    SelfReference child = new SelfReference();

                    child.Name = "Child " + i.ToString();
                    child.ParentSelfReference = parent;

                    parent.References.Add(child);
                }

                modelSelfRefrences.SelfReferences.Add(parent);
                modelSelfRefrences.SaveChanges();
            }
        }

        static void ShowSelfReferenceDataBase()
        {
            using (ModelSelfRefrences modelSelfRefrences = new ModelSelfRefrences())
            {
                foreach (SelfReference parent in modelSelfRefrences.SelfReferences)
                {
                    Console.WriteLine(parent.Name);

                    foreach (SelfReference child in parent.References)
                        Console.WriteLine(child.Name);

                    Console.WriteLine();
                }
            }
        }

        static void TestProductCase()
        {
            using (var context = new EF6RecipesContext())
            {
                context.Products.RemoveRange(context.Products);

                var product = new Product
                {
                    SKU = 147,
                    Description = "Expandable Hydration Pack",
                    Price = 19.97M,
                    ImageURL = "/pack147.jpg"
                };

                context.Products.Add(product);

                product = new Product
                {
                    SKU = 178,
                    Description = "Rugged Ranger Duffel Bag",
                    Price = 39.97M,
                    ImageURL = "/pack178.jpg"
                };

                context.Products.Add(product);

                product = new Product
                {
                    SKU = 186,
                    Description = "Range Field Pack",
                    Price = 98.97M,
                    ImageURL = "/noimage.jp"
                };

                context.Products.Add(product);

                product = new Product
                {
                    SKU = 202,
                    Description = "Small Deployment Back Pack",
                    Price = 29.97M,
                    ImageURL = "/pack202.jpg"
                };

                context.Products.Add(product);
                context.SaveChanges();
            }

            using (var context = new EF6RecipesContext())
            {
                foreach (var p in context.Products)
                {
                    Console.WriteLine("{0} {1} {2} {3}", p.SKU, p.Description,
                    p.Price.ToString("C"), p.ImageURL);
                }
            }
        }
    }
}
