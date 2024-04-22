using System.Threading.Channels;
using CaffeSanGiorgio.Application.Category.Common;
using CaffeSanGiorgio.Application.Customer.Commands.Create;
using CaffeSanGiorgio.Application.Dish.Queries.GetByCategory;
using CaffeSanGiorgio.Application.Manager.Interface;
using CaffeSanGiorgio.Application.Order.Common;
using CaffeSanGiorgio.Application.OrderItem.Common;

namespace CaffeSanGiorgio.Presentation;

public abstract class Ui
{
    public static async Task Interface(ISanGiorgioManager manager)
    {
        while (true)
        {
            Menu();

            var option = Convert.ToString(Console.ReadLine());

            switch (option.ToLower())
            {
                case "y":
                    var categories = await manager.GetAllCategories();
                    var choice = CategoryMenu(categories);
                    var dishes = await manager.GetAllDishesByCategory(choice!);
                    var itemOrderList = DishesMenu(dishes, choice);
                    var orderDetailsDto = await manager.AddOrderDetails(itemOrderList);
                    var createDetailsDto = CustomerDetails(orderDetailsDto);
                    var order = await manager.CreateOrderAsync(createDetailsDto);
                    YourOrderDetails(order);

                    if (!ContinueOrExit())
                    {
                        return;
                    }
                    break;

                case "n":
                    PrintInGreen(() => Console.WriteLine("Tanks for visiting, till the next time..."));
                    return;
                default:
                    PrintInRed(() => Console.WriteLine("Please review your action and try again!"));
                    break;
            }
        }
    }

    private static void YourOrderDetails(OrderDto order)
    {
        if (order == null)
        {
            PrintInRed(() => Console.WriteLine("The order is null."));
            return;
        }

        Console.Clear();
        PrintInBlue(() => Console.WriteLine("------------------------------------------------------------"));
        PrintInBlue(() => Console.WriteLine("------------------  Y O U R  T I C K E T  ------------------"));
        PrintInBlue(() => Console.WriteLine("------------------------------------------------------------"));
        PrintInBlue(() => Console.WriteLine($"Order placed at: {order.OrderTime.ToString("g")}"));
        PrintInBlue(() => Console.WriteLine($"Customer ID: {order.CustomerId}"));
        PrintInBlue(() => Console.WriteLine($"Cook ID: {order.CookId}"));
        PrintInBlue(() => Console.WriteLine($"Table Number: {order.TableNumber}"));
        PrintInBlue(() => Console.WriteLine($"Estimated Waiting Time: {order.EstimatedWaitingTime} minutes"));

        if (order.Items == null || !order.Items.Any())
        {
            Console.WriteLine("The order has no items.");
            return;
        }

        PrintInBlue(() => Console.WriteLine("Order Items:"));
        foreach (var item in order.Items)
        {
            PrintInBlue(() => Console.WriteLine(
                $"- Title: {item.Title}, Quantity: {item.Quantity}, Subtotal: {item.Subtotal:C}"));
        }

        Console.WriteLine($"Total Price: {order.TotalPrice:C}");
        PrintInBlue(() => Console.WriteLine("------------------------------------------------------------"));
        PrintInBlue(() => Console.WriteLine("||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||"));
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        PrintInGreen(() => Console.WriteLine("------------------------------------------------------------"));
        PrintInGreen(() => Console.WriteLine("----------------- THANKS FOR YOUR PURCHASE -----------------"));
        PrintInGreen(() => Console.WriteLine("------------------------------------------------------------"));
    }

    private static OrderDetailsDto CustomerDetails(OrderDetailsDto detailsDto)
    {
        if (detailsDto is null)
        {
            Console.WriteLine("Lets Start again, Sir!");
            return null;
        }
        var customerDto = GetCustomerDetails();

        var tableNumber = GetIntUserInput("For the final step, please insert your Table Number: ");
        PrintInBlue(() => Console.WriteLine("------------------------------------------------------------"));
        Console.Clear();
        PrintInBlue(() => Console.WriteLine("------------------------------------------------------------"));
        PrintInBlue(() => Console.WriteLine("---------- PRESS ANY KEY TO CONFIRM THE PURCHASE -----------"));
        PrintInBlue(() => Console.WriteLine("------------------------------------------------------------"));
        Console.ReadKey();


        return new OrderDetailsDto
        {
            FullName = customerDto.FullName,
            Email = customerDto.Email,
            Items = detailsDto.Items,
            TableNumber = tableNumber
        };
    }

    private static CustomerDto GetCustomerDetails()
    {
        Console.Clear();
        PrintInBlue(() => Console.WriteLine("Let us be in contact with you"));
        PrintInBlue(() => Console.WriteLine("------------------------------"));
        var fullName = GetStringUserInput("Contact Name: ");
        var email = GetStringUserInput("Contact Email: ");
        PrintInBlue(() => Console.WriteLine("------------------------------"));

        return new CustomerDto
        {
            FullName = fullName,
            Email = email
        };
    }

    public static void Menu()
    {
        Lines();
        PrintInGreen(() => Console.WriteLine("Hi, Sir! Would you like to place an order? (Y/\u001b[31mN\u001b[37m)"));
        Lines();
    }

    private static void Lines()
    {
        int width = Console.WindowWidth;
        PrintInBlue(() => Console.WriteLine(new string('-', width)));
    }

    private static string CategoryMenu(IEnumerable<CategoryDto> categories)
    {
        string choice;

        while (true)
        {
            Console.Clear();
            PrintInBlue(() => Console.WriteLine("Select a Category:"));

            foreach (var category in categories)
            {
                PrintInBlue(() => Console.WriteLine($"  {category.Title}"));
            }

            PrintInBlue(() => Console.WriteLine("-----------------"));

            choice = GetStringUserInput("Category Title: ");

            if (string.IsNullOrEmpty(choice) && string.IsNullOrWhiteSpace(choice))
            {
                PrintInRed(() => Console.WriteLine("Please select a category. For now pres any key to continue..."));
                Console.ReadKey();
            }
            else if (choice is not null)
            {
                break;
            }
        }

        return choice;
    }

    private static IEnumerable<ItemOrderDto> DishesMenu(IEnumerable<DishDto>? dishes, string category)
    {
        if (dishes is null)
        {
            PrintInRed(() => Console.WriteLine($"No dishes available for '{category}' category, try again latter..."));
            ContinueKey();
        }

        IEnumerable<ItemOrderDto> dto;

        do
        {
            Console.Clear();
            PrintInBlue(() => Console.WriteLine($"---> Dishes for the '{category}' Category:"));


            foreach (var dish in dishes)
            {
                PrintInBlue(() => Console.WriteLine($"""
                                                     ---------------------------------------------------------------------------------------------------------------------------------
                                                     Title: {dish.Title}
                                                     Description: {dish.Description}
                                                     Ingredients: {dish.IngredientNames}
                                                     WaitingTime: {dish.EstimatedCookingTime} minutes
                                                     Price: {dish.Price:C2}
                                                     ---------------------------------------------------------------------------------------------------------------------------------
                                                     """));
            }

            dto = SelectDishesAndQuantity();
        } while (dto == null);

        return dto;
    }

    private static IEnumerable<ItemOrderDto> SelectDishesAndQuantity()
    {
        var dto = new List<ItemOrderDto>();
        string actionResult;

        PrintInGreen(() => Console.WriteLine("It's time to place some orders!"));
        PrintInGreen(() => Console.WriteLine("----------------------------"));

        do
        {
            var title = GetStringUserInput("Dish Title: ");
            var quantity = GetIntUserInput("Dish Quantity: ");

            var item = new ItemOrderDto
            {
                Title = title,
                Quantity = quantity
            };
            dto.Add(item);

            actionResult = GetStringUserInput("Would you like something else, Sir? (Y/N)");
        } while (!actionResult.Equals("n", StringComparison.CurrentCultureIgnoreCase));

        return dto;
    }

    private static string GetStringUserInput(string requestMessage)
    {
        string? input;

        do
        {
            PrintInGreen(() => Console.Write(requestMessage));

            input = Console.ReadLine();

            if (string.IsNullOrEmpty(input))
            {
                PrintInRed(() => Console.WriteLine("Input cannot be empty. Please enter a string."));
                ContinueKey();
            }
        } while (string.IsNullOrEmpty(input));

        return input;
    }

    private static int GetIntUserInput(string requestMessage)
    {
        var number = 0;

        do
        {
            PrintInGreen(() => Console.Write(requestMessage));

            var input = Console.ReadLine();

            var isParsed = int.TryParse(input, out var result);

            if (isParsed) return result;

            PrintInRed(() => Console.WriteLine("Please enter a valid number!"));
            ContinueKey();
        } while (number == 0);

        return number;
    }

    public static void ContinueKey()
    {
        PrintInGreen(() => Console.Write("Press any key to continue ... "));
        Console.ReadKey();
    }

    static void PrintInMagenta(Action action)
    {
        var originalColor = Console.BackgroundColor;

        Console.BackgroundColor = ConsoleColor.Magenta;
        Console.ForegroundColor = ConsoleColor.Black;


        action.Invoke();

        Console.BackgroundColor = originalColor;
    }

    static void PrintInGreen(Action action)
    {
        var originalForegroundColor = Console.ForegroundColor;

        Console.ForegroundColor = ConsoleColor.Green;

        action.Invoke();

        Console.ForegroundColor = originalForegroundColor;
    }

    static void PrintInRed(Action action)
    {
        var originalForegroundColor = Console.ForegroundColor;

        Console.ForegroundColor = ConsoleColor.DarkRed;

        action.Invoke();

        Console.ForegroundColor = originalForegroundColor;
    }

    static void PrintInBlue(Action action)
    {
        var originalForegroundColor = Console.ForegroundColor;

        Console.ForegroundColor = ConsoleColor.Blue;

        action.Invoke();

        Console.ForegroundColor = originalForegroundColor;
    }
    
    static bool ContinueOrExit()
    {
        Console.WriteLine("Press any key to continue or 'n' to exit...");
        var key = Console.ReadKey(true);
        if (key.Key == ConsoleKey.N)
        {
            return false;
        }
        return true;
    }
}