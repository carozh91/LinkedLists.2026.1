using DoubleList;

var list = new DoubleLinkedList<string>();
var option = string.Empty;
var value = string.Empty;

do
{
    option = Menu();

    switch (option)
    {
        case "1":
            Console.Write("Enter a value: ");
            value = Console.ReadLine() ?? string.Empty;
            list.InsertOrdered(value);
            break;

        case "2":
            Console.WriteLine(list.ToString());
            break;

        case "3":
            Console.WriteLine(list.ToStringReverse());
            break;

        case "4":
            list.Sort();
            Console.WriteLine(list.ToString());
            break;

        case "5":
            list.ShowModes();
            break;

        case "6":
            list.ShowGraph();
            break;

        case "7":
            Console.Write("Enter a value: ");
            value = Console.ReadLine() ?? string.Empty;

            if (list.Contains(value))
            {
                Console.WriteLine($"Value '{value}' found in the list.");
            }
            else
            {
                Console.WriteLine($"Value '{value}' not found in the list.");
            }
            break;

        case "8":
            Console.Write("Enter a value: ");
            value = Console.ReadLine() ?? string.Empty;
            list.Remove(value);
            break;

        case "9":
            Console.Write("Enter a value: ");
            value = Console.ReadLine() ?? string.Empty;
            list.RemoveAll(value);
            break;

        case "0":
            Console.WriteLine("Exiting...");
            break;

        default:
            Console.WriteLine("Invalid option. Please try again.");
            break;
    }

} while (option != "0");

string Menu()
{
    Console.WriteLine("1. Add");
    Console.WriteLine("2. Show forward");
    Console.WriteLine("3. Show backward");
    Console.WriteLine("4. Order descending");
    Console.WriteLine("5. Show mode");
    Console.WriteLine("6. Show graph");
    Console.WriteLine("7. Contains");
    Console.WriteLine("8. Remove one occurrence");
    Console.WriteLine("9. Remove all occurrences");
    Console.WriteLine("0. Exit");
    Console.Write("Enter your option: ");
    return Console.ReadLine() ?? string.Empty;
}
