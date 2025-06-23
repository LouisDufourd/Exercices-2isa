
using static System.Runtime.InteropServices.JavaScript.JSType;

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

static bool AskDouble(string question, out double number)
{
    Console.Write(question);
    string? asked = Console.ReadLine();

    if (asked == null)
    {
        number = 0;
        return false;
    }

    return double.TryParse(asked, out number);
}

bool AskString(string question, out string chaine)
{
    Console.Write(question);
    string? asked = Console.ReadLine();

    if (asked == null)
    {
        chaine = "";
        return false;
    }

    chaine = asked;
    return true;
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

int[] entiers = new int[8];
string[] chaines = new string[10];
double[] prix= new double[5];

for (int i = 0; i < entiers.Length; i++)
{
    int number;
    while (!AskInt("Entrez un nombre entiers: ", out number)) 
    { 
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Please type an integer number");
        Console.ForegroundColor = ConsoleColor.White;
    }
    entiers[i] = number;
}

for (int i = 0; i < chaines.Length; i++)
{
    string chaine;
    while (!AskString("Entrée une chaine de charactère: ", out chaine))
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Please type a non null string");
        Console.ForegroundColor = ConsoleColor.White;
    }
    chaines[i] = chaine;
}

for (int i = 0; i < prix.Length; i++)
{
    double number;

    while (!AskDouble("Entrez un nombre entiers: ", out number))
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Please type a decimal number");
        Console.ForegroundColor = ConsoleColor.White;
    }
    prix[i] = number;
}

Console.WriteLine("Entiers :");
ShowArray(entiers);
Console.WriteLine("Chaines :");
ShowArray(chaines);
Console.WriteLine("Prix :");
ShowArray(prix);