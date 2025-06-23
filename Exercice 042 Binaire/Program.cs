static string IntToBinary(int number)
{
    string binary = "";
    bool breakFlag = false;

    if (number < 0)
    {
        binary += "1";
        number *= -1;
    }
    else
    {
        binary += "0";
    }

    for (int i = 30; i >= 0; i--)
    {
        int power = (int)Math.Pow(2, i);
        if (power <= number)
        {
            number -= power;
            binary += "1";
        }
        else
        {
            binary += "0";
        }
    }

    while (binary[0] == '0')
    {
        if (binary[0] == '0')
        {
            binary = binary.Substring(1);
        }
    }

    return binary;
}

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

Console.WriteLine(Int32.MinValue);
Console.WriteLine(Int32.MaxValue);

int number = 0;

while(!AskInt("Entrez un nombre : ", out number))
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("Veuillez entrez un nombre entier entre -2^31 et 2^31 - 1");
    Console.ForegroundColor = ConsoleColor.White;
}

Console.WriteLine(IntToBinary(number));