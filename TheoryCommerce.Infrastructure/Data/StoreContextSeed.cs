using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TheoryCommerce.Core.Entities;

namespace TheoryCommerce.Infrastructure.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext context)
        {
            if(!context.ProductBrands.Any())
            {
                var brandsData = File.ReadAllText("../TheoryCommerce.Infrastructure/Data/SeedData/brands.json");
                var brands = JsonSerializer.Deserialize<IEnumerable<ProductBrand>>(brandsData);
                await context.ProductBrands.AddRangeAsync(brands);
            }

            if (!context.ProductBrands.Any())
            {
                var typesData = File.ReadAllText("../TheoryCommerce.Infrastructure/Data/SeedData/types.json");
                var types = JsonSerializer.Deserialize<IEnumerable<ProductType>>(typesData);
                await context.ProductTypes.AddRangeAsync(types);
            }

            if (!context.ProductBrands.Any())
            {
                var productsData = File.ReadAllText("../TheoryCommerce.Infrastructure/Data/SeedData/products.json");
                var products = JsonSerializer.Deserialize<IEnumerable<Product>>(productsData);
                await context.Products.AddRangeAsync(products);
            }

            if(context.ChangeTracker.HasChanges())
            {
                await context.SaveChangesAsync();
            }
        }
    }
}
