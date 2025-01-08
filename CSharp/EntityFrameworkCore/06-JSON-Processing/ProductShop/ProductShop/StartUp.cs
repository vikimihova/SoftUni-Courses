using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ProductShop.Data;
using ProductShop.DTOs.Export;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main()
        {
            // IMPORTANT: SoftUni-provided skeleton with pre-written code deliberately excluded from solution

            ProductShopContext context = new ProductShopContext();

            string usersText = File.ReadAllText("../../../Datasets/users.json");
            string productsText = File.ReadAllText("../../../Datasets/products.json");
            string categoriesText = File.ReadAllText("../../../Datasets/categories.json");
            string categoriesProductsText = File.ReadAllText("../../../Datasets/categories-products.json");

            //Console.WriteLine(ImportUsers(context, usersText));
            //Console.WriteLine(ImportProducts(context, productsText));
            //Console.WriteLine(ImportCategories(context, categoriesText));
            //Console.WriteLine(ImportCategoryProducts(context, categoriesProductsText));

            Console.WriteLine(GetCategoriesByProductsCount(context));
        }

        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            var users = JsonConvert.DeserializeObject<List<User>>(inputJson);

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count}";
        }

        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            var products = JsonConvert.DeserializeObject<List<Product>>(inputJson);

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count}";
        }

        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            var categories = JsonConvert.DeserializeObject<List<Category>>(inputJson);

            categories.RemoveAll(c => c.Name == null);

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count}";
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            var categoryProducts = JsonConvert.DeserializeObject<List<CategoryProduct>>(inputJson);

            context.CategoriesProducts.AddRange(categoryProducts);
            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Count}";
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .Select(p => new ExportProductDto()
                {
                    Name = p.Name,
                    Price = p.Price,                    
                    Seller = $"{p.Seller.FirstName} {p.Seller.LastName}",
                })
                .ToList();

            var settings = new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                Formatting = Formatting.Indented,
            };

            return JsonConvert.SerializeObject(products, settings);
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            var sellers = context.Users
                .Where(u => u.ProductsSold.Any(p => p.BuyerId != null))
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Select(u => new
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    soldProducts = u.ProductsSold
                        .Select(p => new
                        {
                            p.Name,
                            p.Price,
                            BuyerFirstName = p.Buyer.FirstName,
                            BuyerLastName = p.Buyer.LastName,
                        })
                        .ToList()
                })
                .ToList();

            var settings = new JsonSerializerSettings()
            {                
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                Formatting = Formatting.Indented,
            };

            return JsonConvert.SerializeObject(sellers, settings);
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                .OrderByDescending(c => c.CategoriesProducts.Count)
                .Select(c => new
                {
                    Category = c.Name,
                    ProductsCount = c.CategoriesProducts.Count,
                    AveragePrice = $"{c.CategoriesProducts.Average(cp => cp.Product.Price):f2}",
                    TotalRevenue = $"{c.CategoriesProducts.Sum(cp => cp.Product.Price):f2}"
                })
                .ToList();

            var settings = new JsonSerializerSettings()
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                Formatting = Formatting.Indented,
            };

            return JsonConvert.SerializeObject(categories, settings);
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(u => u.ProductsSold.Any(p => p.BuyerId != null))                
                .Select(u => new
                {
                    u.FirstName,
                    u.LastName,
                    u.Age,
                    SoldProducts = u.ProductsSold
                        .Where(p => p.BuyerId != null)
                        .Select(p => new
                        {
                            p.Name,
                            p.Price
                        })
                        .ToList()
                })
                .OrderByDescending(u => u.SoldProducts.Count)
                .ToList();


            var output = new
            {
                UsersCount = users.Count,
                Users = users.Select(u => new
                {
                    u.FirstName,
                    u.LastName,
                    u.Age,
                    SoldProducts = new
                    {
                        Count = u.SoldProducts.Count,
                        Products = u.SoldProducts
                    }
                })
            };

            var settings = new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                Formatting = Formatting.Indented,
            };

            return JsonConvert.SerializeObject(output, settings);
        }
    }
}