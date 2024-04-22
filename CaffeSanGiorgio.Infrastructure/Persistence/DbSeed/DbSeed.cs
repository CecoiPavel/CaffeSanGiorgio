using CaffeSanGiorgio.Domain.Category;
using CaffeSanGiorgio.Domain.Common;
using CaffeSanGiorgio.Domain.Cook;
using CaffeSanGiorgio.Domain.Customer;
using CaffeSanGiorgio.Domain.Dish;
using CaffeSanGiorgio.Domain.Ingredient;

namespace CaffeSanGiorgio.Infrastructure.Persistence.DbSeed;

public class DbSeed
{
    public static bool Initialize(SanGiorgioContext context)
    {
        context.Database.EnsureCreated();

        if (context.Dishes.Any())
        {
            return false;
        }

        // Seed data 
        #region SeedData

        var categories = new List<CategoryEntity>
        {
            new()
            {
                Id = "HotDrinksId",
                Title = "HotDrinks",
                CreatedByUserId = "seed",
                LastModifiedByUserId = "seed",
                DeletedByUserId = "",
                IsDeleted = false,
                LastModificationTime = DateTimeOffset.UtcNow,
                DeletedOnDateTime = null
            },
            new()
            {
                Id = "ColdDrinksId",
                Title = "ColdDrinks",
                CreatedByUserId = "seed",
                LastModifiedByUserId = "seed",
                DeletedByUserId = "",
                IsDeleted = false,
                LastModificationTime = DateTimeOffset.UtcNow,
                DeletedOnDateTime = null
            },
            new()
            {
                Id = "CookiesId",
                Title = "Cookies",
                CreatedByUserId = "seed",
                LastModifiedByUserId = "seed",
                DeletedByUserId = "",
                IsDeleted = false,
                LastModificationTime = DateTimeOffset.UtcNow,
                DeletedOnDateTime = null
            }
        };

        var cookers = new List<CookEntity>
        {
            new()
            {
                Id = "JohnDoeId",
                FullName = "John Doe",
                Rating = 5,
                DishesToCook = 0,
                LastModifiedByUserId = "system",
                CreatedByUserId = "system",
                DeletedByUserId = "",
                IsDeleted = false,
                LastModificationTime = DateTimeOffset.UtcNow
            },
            new()
            {
                Id = "JaneSmithId",
                FullName = "Jane Smith",
                Rating = 4,
                DishesToCook = 0,
                LastModifiedByUserId = "system",
                CreatedByUserId = "system",
                DeletedByUserId = "",
                IsDeleted = false,
                LastModificationTime = DateTimeOffset.UtcNow
            },
            new()
            {
                Id = "AlexJohnsonId",
                FullName = "Alex Johnson",
                Rating = 5,
                DishesToCook = 0,
                LastModifiedByUserId = "system",
                CreatedByUserId = "system",
                DeletedByUserId = "",
                IsDeleted = false,
                LastModificationTime = DateTimeOffset.UtcNow
            }
        };

        var customers = new List<CustomerEntity>
        {
            new()
            {
                Id = Guid.NewGuid().ToString(),
                FullName = "Alice Green",
                Email = "alice.green@example.com",
                LastModifiedByUserId = "system",
                CreatedByUserId = "system",
                DeletedByUserId = "",
                IsDeleted = false,
                LastModificationTime = DateTimeOffset.UtcNow
            },
            new()
            {
                Id = Guid.NewGuid().ToString(),
                FullName = "Bob Brown",
                Email = "bob.brown@example.com",
                LastModifiedByUserId = "system",
                CreatedByUserId = "system",
                DeletedByUserId = "",
                IsDeleted = false,
                LastModificationTime = DateTimeOffset.UtcNow
            },
            new()
            {
                Id = Guid.NewGuid().ToString(),
                FullName = "Charlie Davis",
                Email = "charlie.davis@example.com",
                LastModifiedByUserId = "system",
                CreatedByUserId = "system",
                DeletedByUserId = "",
                IsDeleted = false,
                LastModificationTime = DateTimeOffset.UtcNow
            }
        };

        var ingredients = new List<IngredientEntity>
        {
            new()
            {
                Id = "FlavorId",
                Name = "Flavor",
                Price = 3.50m,
                LastModifiedByUserId = "system",
                CreatedByUserId = "system",
                DeletedByUserId = "",
                IsDeleted = false,
                LastModificationTime = DateTimeOffset.UtcNow
            },
            new()
            {
                Id = "MilkId",
                Name = "Milk",
                Price = 1.50m,
                LastModifiedByUserId = "system",
                CreatedByUserId = "system",
                DeletedByUserId = "",
                IsDeleted = false,
                LastModificationTime = DateTimeOffset.UtcNow
            },
            new()
            {
                Id = "CreamId",
                Name = "Cream",
                Price = 3.50m,
                LastModifiedByUserId = "system",
                CreatedByUserId = "system",
                DeletedByUserId = "",
                IsDeleted = false,
                LastModificationTime = DateTimeOffset.UtcNow
            },
            new()
            {
                Id = "FlourId",
                Name = "Flour",
                Price = 1.50m,
                LastModifiedByUserId = "system",
                CreatedByUserId = "system",
                DeletedByUserId = "",
                IsDeleted = false,
                LastModificationTime = DateTimeOffset.UtcNow
            },
            new()
            {
                Id = "CinnamonId",
                Name = "Cinnamon",
                Price = 2.50m,
                LastModifiedByUserId = "system",
                CreatedByUserId = "system",
                DeletedByUserId = "",
                IsDeleted = false,
                LastModificationTime = DateTimeOffset.UtcNow
            },
            new()
            {
                Id = "IceId",
                Name = "Ice",
                Price = 1.50m,
                LastModifiedByUserId = "system",
                CreatedByUserId = "system",
                DeletedByUserId = "",
                IsDeleted = false,
                LastModificationTime = DateTimeOffset.UtcNow
            },
            new()
            {
                Id = "SugarId",
                Name = "Sugar",
                Price = 0.80m,
                LastModifiedByUserId = "system",
                CreatedByUserId = "system",
                DeletedByUserId = "",
                IsDeleted = false,
                LastModificationTime = DateTimeOffset.UtcNow
            },
            new()
            {
                Id = "EggsId",
                Name = "Eggs",
                Price = 2.00m,
                LastModifiedByUserId = "system",
                CreatedByUserId = "system",
                DeletedByUserId = "",
                IsDeleted = false,
                LastModificationTime = DateTimeOffset.UtcNow
            }
        };

        var coldDrinks = new List<DishEntity>
        {
            new()
            {
                Id = "IcedLemonTeaId",
                Title = "Iced Lemon Tea",
                Description = "Refreshing iced tea infused with zesty lemon flavor.",
                Price = 2.99m,
                EstimatedCookingTime = 5,
                LastModificationTime = DateTimeOffset.Now,
                LastModifiedByUserId = "Seed",
                CreatedByUserId = "Seed",
                DeletedByUserId = "",
                IsDeleted = false,
                DeletedOnDateTime = null,
                CategoryId = "ColdDrinksId"
            },
            new()
            {
                Id = "WatermelonMintCoolerId",
                Title = "Watermelon Mint Cooler",
                Description = "A delightful blend of fresh watermelon juice with a hint of mint, served chilled.",
                Price = 3.49m,
                EstimatedCookingTime = 7,
                LastModificationTime = DateTimeOffset.Now,
                LastModifiedByUserId = "Seed",
                CreatedByUserId = "Seed",
                DeletedByUserId = "",
                IsDeleted = false,
                DeletedOnDateTime = null,
                CategoryId = "ColdDrinksId"
            }
        };

        var hotDrinks = new List<DishEntity>
        {
            new()
            {
                Id = "ClassicHotChocolateId",
                Title = "Classic Hot Chocolate",
                Description = "Rich and creamy hot chocolate topped with marshmallows.",
                Price = 4.99m,
                EstimatedCookingTime = 8,
                LastModificationTime = DateTimeOffset.Now,
                LastModifiedByUserId = "seed",
                CreatedByUserId = "Seed",
                DeletedByUserId = "",
                IsDeleted = false,
                DeletedOnDateTime = null,
                CategoryId = "HotDrinksId"
            },
            new()
            {
                Id = "SpicedChaiLatteId",
                Title = "Spiced Chai Latte",
                Description =
                    "A comforting blend of black tea, spices, and steamed milk, infused with aromatic flavors.",
                Price = 3.99m,
                EstimatedCookingTime = 6,
                LastModificationTime = DateTimeOffset.Now,
                LastModifiedByUserId = "Seed",
                CreatedByUserId = "Seed",
                DeletedByUserId = "",
                IsDeleted = false,
                DeletedOnDateTime = null,
                CategoryId = "HotDrinksId"
            }
        };

        var cookies = new List<DishEntity>
        {
            new()
            {
                Id = "ChocolateChipCookiesId",
                Title = "Chocolate Chip Cookies",
                Description = "Soft and chewy cookies filled with chunks of rich chocolate.",
                Price = 1.99m,
                EstimatedCookingTime = 10,
                LastModificationTime = DateTimeOffset.Now,
                LastModifiedByUserId = "Seed",
                CreatedByUserId = "Seed",
                DeletedByUserId = "",
                IsDeleted = false,
                DeletedOnDateTime = null,
                CategoryId = "CookiesId"
            },
            new()
            {
                Id = "OatmealRaisinCookiesId",
                Title = "Oatmeal Raisin Cookies",
                Description = "Hearty cookies made with rolled oats and sweet raisins, perfect for a wholesome snack.",
                Price = 2.49m,
                EstimatedCookingTime = 12,
                LastModificationTime = null,
                LastModifiedByUserId = "Seed",
                CreatedByUserId = "Seed",
                DeletedByUserId = "",
                IsDeleted = false,
                DeletedOnDateTime = null,
                CategoryId = "CookiesId"
            }
        };

        var dishIngredients = new List<DishIngredientEntity>
        {
            // DishIngredients for Iced Lemon Tea
            new()
            {
                Id = Guid.NewGuid().ToString(),
                DishId = "IcedLemonTeaId",
                IngredientId = "FlavorId",
                LastModificationTime = DateTimeOffset.Now,
                LastModifiedByUserId = "Seed",
                CreatedByUserId = "Seed",
                DeletedByUserId = "",
                IsDeleted = false,
                DeletedOnDateTime = null
            },
            new()
            {
                Id = Guid.NewGuid().ToString(),
                DishId = "IcedLemonTeaId",
                IngredientId = "IceId",
                LastModificationTime = DateTimeOffset.Now,
                LastModifiedByUserId = "Seed",
                CreatedByUserId = "Seed",
                DeletedByUserId = "",
                IsDeleted = false,
                DeletedOnDateTime = null
            },
            new()
            {
                Id = Guid.NewGuid().ToString(),
                DishId = "IcedLemonTeaId",
                IngredientId = "SugarId",
                LastModificationTime = DateTimeOffset.Now,
                LastModifiedByUserId = "Seed",
                CreatedByUserId = "Seed",
                DeletedByUserId = "",
                IsDeleted = false,
                DeletedOnDateTime = null
            },

            // DishIngredients for Watermelon Mint Cooler
            new()
            {
                Id = Guid.NewGuid().ToString(),
                DishId = "WatermelonMintCoolerId",
                IngredientId = "FlavorId",
                LastModificationTime = DateTimeOffset.Now,
                LastModifiedByUserId = "Seed",
                CreatedByUserId = "Seed",
                DeletedByUserId = "",
                IsDeleted = false,
                DeletedOnDateTime = null
            },
            new()
            {
                Id = Guid.NewGuid().ToString(),
                DishId = "WatermelonMintCoolerId",
                IngredientId = "IceId",
                LastModificationTime = DateTimeOffset.Now,
                LastModifiedByUserId = "Seed",
                CreatedByUserId = "Seed",
                DeletedByUserId = "",
                IsDeleted = false,
                DeletedOnDateTime = null
            },
            new()
            {
                Id = Guid.NewGuid().ToString(),
                DishId = "WatermelonMintCoolerId",
                IngredientId = "SugarId",
                LastModificationTime = DateTimeOffset.Now,
                LastModifiedByUserId = "Seed",
                CreatedByUserId = "Seed",
                DeletedByUserId = "",
                IsDeleted = false,
                DeletedOnDateTime = null
            },
            
            // DishIngredients for Classic Hot Chocolate
            new()
            {
                Id = Guid.NewGuid().ToString(),
                DishId = "ClassicHotChocolateId",
                IngredientId = "MilkId",
                LastModificationTime = DateTimeOffset.Now,
                LastModifiedByUserId = "Seed",
                CreatedByUserId = "Seed",
                DeletedByUserId = "",
                IsDeleted = false,
                DeletedOnDateTime = null
            },
            new()
            {
                Id = Guid.NewGuid().ToString(),
                DishId = "ClassicHotChocolateId",
                IngredientId = "CreamId",
                LastModificationTime = DateTimeOffset.Now,
                LastModifiedByUserId = "Seed",
                CreatedByUserId = "Seed",
                DeletedByUserId = "",
                IsDeleted = false,
                DeletedOnDateTime = null
            },
            new()
            {
                Id = Guid.NewGuid().ToString(),
                DishId = "ClassicHotChocolateId",
                IngredientId = "SugarId",
                LastModificationTime = DateTimeOffset.Now,
                LastModifiedByUserId = "Seed",
                CreatedByUserId = "Seed",
                DeletedByUserId = "",
                IsDeleted = false,
                DeletedOnDateTime = null
            },

            // DishIngredients for Spiced Chai Latte
            new()
            {
                Id = Guid.NewGuid().ToString(),
                DishId = "SpicedChaiLatteId",
                IngredientId = "MilkId",
                LastModificationTime = DateTimeOffset.Now,
                LastModifiedByUserId = "Seed",
                CreatedByUserId = "Seed",
                DeletedByUserId = "",
                IsDeleted = false,
                DeletedOnDateTime = null
            },
            new()
            {
                Id = Guid.NewGuid().ToString(),
                DishId = "SpicedChaiLatteId",
                IngredientId = "CinnamonId",
                LastModificationTime = DateTimeOffset.Now,
                LastModifiedByUserId = "Seed",
                CreatedByUserId = "Seed",
                DeletedByUserId = "",
                IsDeleted = false,
                DeletedOnDateTime = null
            },
            new()
            {
                Id = Guid.NewGuid().ToString(),
                DishId = "SpicedChaiLatteId",
                IngredientId = "SugarId",
                LastModificationTime = DateTimeOffset.Now,
                LastModifiedByUserId = "Seed",
                CreatedByUserId = "Seed",
                DeletedByUserId = "",
                IsDeleted = false,
                DeletedOnDateTime = null
            },

            // DishIngredients for Chocolate Chip Cookies
            new()
            {
                Id = Guid.NewGuid().ToString(),
                DishId = "ChocolateChipCookiesId",
                IngredientId = "FlourId",
                LastModificationTime = DateTimeOffset.Now,
                LastModifiedByUserId = "Seed",
                CreatedByUserId = "Seed",
                DeletedByUserId = "",
                IsDeleted = false,
                DeletedOnDateTime = null
            },
            new()
            {
                Id = Guid.NewGuid().ToString(),
                DishId = "ChocolateChipCookiesId",
                IngredientId = "SugarId",
                LastModificationTime = DateTimeOffset.Now,
                LastModifiedByUserId = "Seed",
                CreatedByUserId = "Seed",
                DeletedByUserId = "",
                IsDeleted = false,
                DeletedOnDateTime = null
            },
            new()
            {
                Id = Guid.NewGuid().ToString(),
                DishId = "ChocolateChipCookiesId",
                IngredientId = "EggsId",
                LastModificationTime = DateTimeOffset.Now,
                LastModifiedByUserId = "Seed",
                CreatedByUserId = "Seed",
                DeletedByUserId = "",
                IsDeleted = false,
                DeletedOnDateTime = null
            },

            // DishIngredients for Oatmeal Raisin Cookies
            new()
            {
                Id = Guid.NewGuid().ToString(),
                DishId = "OatmealRaisinCookiesId",
                IngredientId = "FlourId",
                LastModificationTime = DateTimeOffset.Now,
                LastModifiedByUserId = "Seed",
                CreatedByUserId = "Seed",
                DeletedByUserId = "",
                IsDeleted = false,
                DeletedOnDateTime = null
            },
            new()
            {
                Id = Guid.NewGuid().ToString(),
                DishId = "OatmealRaisinCookiesId",
                IngredientId = "SugarId",
                LastModificationTime = DateTimeOffset.Now,
                LastModifiedByUserId = "Seed",
                CreatedByUserId = "Seed",
                DeletedByUserId = "",
                IsDeleted = false,
                DeletedOnDateTime = null
            },
            new()
            {
                Id = Guid.NewGuid().ToString(),
                DishId = "OatmealRaisinCookiesId",
                IngredientId = "CinnamonId",
                LastModificationTime = DateTimeOffset.Now,
                LastModifiedByUserId = "Seed",
                CreatedByUserId = "Seed",
                DeletedByUserId = "",
                IsDeleted = false,
                DeletedOnDateTime = null
            }
        };

        #endregion

        //Add Seed data
        context.Categories.AddRange(categories);
        context.Cookers.AddRange(cookers);
        context.Customers.AddRange(customers);
        context.Ingredients.AddRange(ingredients);
        context.Dishes.AddRange(coldDrinks);
        context.Dishes.AddRange(hotDrinks);
        context.Dishes.AddRange(cookies);
        context.DishIngredients.AddRange(dishIngredients);
        
        //Save Changes
        context.SaveChanges();

        return true;
    }
}