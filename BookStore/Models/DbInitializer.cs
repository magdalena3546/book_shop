using BookStore.Data;
using Microsoft.AspNetCore.Identity;

namespace BookStore.Models
{
    public static class DbInitializer
    {
        public static async Task Initialize(ApplicationDbContext context, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            try
            {
                if (!context.Categories.Any())
                {
                    var categories = new Category[]
                    {
                        new Category { Id = 1, Name = "Nowości" },
                        new Category { Id = 2, Name = "Bestsellery" },
                        new Category { Id = 3, Name = "Promocje" }
                    };

                    await context.Categories.AddRangeAsync(categories);
                    await context.SaveChangesAsync();
                    Console.WriteLine("Kategorie dodane do bazy danych!");
                }

                if (!context.Books.Any())
                {
                    var books = new Book[]
                    {
                       new Book { Id = 1, Title = "Zabić drozda", Author = "Harper Lee", Genre = "Literatura piękna", Price = 45.99m, CategoryId = 2, Stock = 10, Description = "Poruszająca powieść o rasizmie i niesprawiedliwości." },
                       new Book { Id = 2, Title = "Ojciec chrzestny", Author = "Mario Puzo", Genre = "Kryminał", Price = 59.99m, CategoryId = 2, Stock = 8, Description = "Klasyczna powieść o mafii i władzy w rodzinie Corleone." },
                       new Book { Id = 3, Title = "Harry Potter i Kamień Filozoficzny", Author = "J.K. Rowling", Genre = "Fantastyka", Price = 39.99m, CategoryId = 1, Stock = 15, Description = "Pierwsza część przygód młodego czarodzieja w Hogwarcie." },
                       new Book { Id = 4, Title = "Władca Pierścieni", Author = "J.R.R. Tolkien", Genre = "Fantastyka", Price = 89.99m, CategoryId = 2, Stock = 12, Description = "Epicka opowieść o walce dobra ze złem w Śródziemiu." },
                       new Book { Id = 5, Title = "Sherlock Holmes: Studium w szkarłacie", Author = "Arthur Conan Doyle", Genre = "Kryminał", Price = 29.99m, CategoryId = 3, Stock = 7, Description = "Pierwsza sprawa słynnego detektywa Sherlocka Holmesa." },
                       new Book { Id = 6, Title = "1984", Author = "George Orwell", Genre = "Dystopia", Price = 42.50m, CategoryId = 2, Stock = 5, Description = "Przerażająca wizja świata rządzonego przez Wielkiego Brata." },
                       new Book { Id = 7, Title = "Zbrodnia i kara", Author = "Fiodor Dostojewski", Genre = "Klasyka", Price = 55.00m, CategoryId = 3, Stock = 9, Description = "Historia studenta, który zmaga się z moralnymi konsekwencjami morderstwa." },
                       new Book { Id = 8, Title = "Duma i uprzedzenie", Author = "Jane Austen", Genre = "Romans", Price = 38.75m, CategoryId = 3, Stock = 11, Description = "Ponadczasowa opowieść o miłości i klasach społecznych." },
                       new Book { Id = 9, Title = "Sapiens. Od zwierząt do bogów", Author = "Yuval Noah Harari", Genre = "Historia", Price = 69.99m, CategoryId = 1, Stock = 6, Description = "Fascynująca podróż przez historię ludzkości." },
                       new Book { Id = 10, Title = "Mężczyźni, którzy nienawidzą kobiet", Author = "Stieg Larsson", Genre = "Thriller", Price = 49.99m, CategoryId = 2, Stock = 14, Description = "Pierwsza część serii Millennium, pełna napięcia i zagadek." }

                    };

                    await context.Books.AddRangeAsync(books);
                    await context.SaveChangesAsync();
                    Console.WriteLine("Książki dodane do bazy danych!");
                }

                if (!context.Orders.Any())
                {
                    var orders = new Order[]
                    {
                        new Order { Id = 1, CustomerName = "Jan Kowalski", CustomerEmail = "jan.kowalski@example.com", Status = "Pending" },
                        new Order { Id = 2, CustomerName = "Anna Nowak", CustomerEmail = "anna.nowak@example.com", Status = "Completed" },
                        new Order { Id = 3, CustomerName = "Michał Wiśniewski", CustomerEmail = "michal.w@example.com", Status = "Pending" },
                        new Order { Id = 4, CustomerName = "Karolina Zielińska", CustomerEmail = "karolina.z@example.com", Status = "Canceled" }
                    };

                    await context.Orders.AddRangeAsync(orders);
                    await context.SaveChangesAsync();
                    Console.WriteLine("Zamówienia dodane do bazy danych!");
                }

                if (!context.OrderDetails.Any())
                {
                    var orderDetails = new OrderDetail[]
                    {
                        new OrderDetail { Id = 1, OrderId = 1, BookId = 2, Quantity = 1, UnitPrice = 59.99m },
                        new OrderDetail { Id = 2, OrderId = 1, BookId = 6, Quantity = 2, UnitPrice = 42.50m },
                        new OrderDetail { Id = 3, OrderId = 2, BookId = 4, Quantity = 1, UnitPrice = 89.99m },
                        new OrderDetail { Id = 4, OrderId = 2, BookId = 7, Quantity = 1, UnitPrice = 55.00m },
                        new OrderDetail { Id = 5, OrderId = 3, BookId = 9, Quantity = 1, UnitPrice = 69.99m },
                        new OrderDetail { Id = 6, OrderId = 3, BookId = 10, Quantity = 2, UnitPrice = 49.99m },
                        new OrderDetail { Id = 7, OrderId = 4, BookId = 1, Quantity = 3, UnitPrice = 45.99m },
                        new OrderDetail { Id = 8, OrderId = 4, BookId = 5, Quantity = 2, UnitPrice = 29.99m }
                    };

                    await context.OrderDetails.AddRangeAsync(orderDetails);
                    await context.SaveChangesAsync();
                    Console.WriteLine("Szczegóły zamówień dodane do bazy danych!");
                }

                string[] roleNames = { "Admin", "User" };
                foreach (var roleName in roleNames)
                {
                    if (!await roleManager.RoleExistsAsync(roleName))
                    {
                        await roleManager.CreateAsync(new IdentityRole(roleName));
                        Console.WriteLine($"Rola '{roleName}' została utworzona!");
                    }
                }

                string adminEmail = "admin@bookstore.com";
                string adminPassword = "Admin123!";

                if (await userManager.FindByEmailAsync(adminEmail) == null)
                {
                    var adminUser = new IdentityUser
                    {
                        UserName = adminEmail,
                        Email = adminEmail,
                        EmailConfirmed = true
                    };

                    var result = await userManager.CreateAsync(adminUser, adminPassword);
                    if (result.Succeeded)
                    {
                        await userManager.AddToRoleAsync(adminUser, "Admin");
                        Console.WriteLine("Administrator został dodany!");
                    }
                    else
                    {
                        Console.WriteLine("Błąd podczas tworzenia konta administratora:");
                        foreach (var error in result.Errors)
                        {
                            Console.WriteLine($"- {error.Description}");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Administrator już istnieje.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Błąd podczas inicjalizacji bazy danych: {ex.Message}");
            }
        }
    }
}
