static bool AskInt(string question, out int number)
{
    Console.Write(question);
    string? asked = Console.ReadLine();
    if (asked == null)
    {
        number = 0;
        return false;
    }
    return int.TryParse(asked, out number);
}

static void ShowArray(List<int> arr)
{
    Console.Write("[");
    for (int i = 0; i < arr.Count(); i++)
    {
        var value = arr.ElementAt(i);
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

        if (i < arr.Count() - 1)
        {
            Console.Write(", ");
        }
    }

    Console.WriteLine("]");
}

List<int> ints = new List<int>();
ConsoleKey keyPressed = ConsoleKey.None;

while(!keyPressed.Equals(ConsoleKey.Q))
{
    int number;

    while (!AskInt("Entrez un nombre entier: ", out number))
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Veuillez entrez un nombre entier!");
        Console.ForegroundColor = ConsoleColor.White;
    }

    ints.Add(number);

    Console.WriteLine("Tapez q pour quittez la saisie");
    keyPressed = Console.ReadKey().Key;
    Console.WriteLine();
}

List<int> positives = [.. ints
    .Where(i => i >= 0)
    .Select(i => i)];

List<int> negatives = [.. ints
    .Where(i => i < 0)
    .Select(i => i)];

Console.Write("Positives : ");
ShowArray(positives);
Console.Write("Négatives : ");
ShowArray(negatives);