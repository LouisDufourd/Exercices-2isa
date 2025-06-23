using System.Text;

static bool AskDouble(string question, out double number)
{
    Console.Write(question);
    string? asked = Console.ReadLine();

    if (asked == null)
    {
        number = 0;
        return false;
    }

    asked = asked.Replace('.', ',');

    return double.TryParse(asked, out number);
}

static bool AskUInt(string question, out uint number)
{
    Console.Write(question);
    string? asked = Console.ReadLine();
    if (asked == null)
    {
        number = 0;
        return false;
    }
    return uint.TryParse(asked, out number);
}

static void ShowArray(Array arr)
{
    Console.Write("[");
    for (int i = 0; i < arr.Length; i++)
    {
        var value = arr.GetValue(i);
        switch (Type.GetTypeCode(value.GetType()))
        {
            case TypeCode.Char:
                Console.Write("'");
                Console.Write($"{value}");
                Console.Write("'");
                break;
            case TypeCode.String:
                Console.Write("\"");
                Console.Write($"{value}");
                Console.Write("\"");
                break;
            default:
                Console.Write($"{value}".Replace(',', '.'));
                break;
        }

        if (i < arr.Length - 1)
        {
            Console.Write(", ");
        }
    }

    Console.WriteLine("]");
}

Console.OutputEncoding = Encoding.UTF8;

uint size;

while(!AskUInt("Entrez le nombre de prix que vous voulez renseignez: ", out size))
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("Veuillez tapez un nombre entier positif!");
    Console.ForegroundColor = ConsoleColor.White;
}

double[] prices = new double[size];

for (int i = 0; i < prices.Length; i++)
{
    double price;
    while(!AskDouble("Entrez un nombre réel: ", out price))
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Veuillez tapez un nombre decimal!");
        Console.ForegroundColor = ConsoleColor.White;
    }

    prices[i] = price;
}

Console.Write("Les prix: ");
ShowArray(prices);

double moyenne = prices.Sum() / prices.Length;

Console.WriteLine($"Moyenne: {String.Format("{0:0.00}", moyenne)}€");
Console.WriteLine($"Total: {String.Format("{0:0.00}", prices.Sum())}€");