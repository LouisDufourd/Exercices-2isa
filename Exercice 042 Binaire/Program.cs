using System.Security.Principal;

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
            binary = binary.Substring(2);
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

int number = 0;
bool success = false;

while(!success)
{
    success = AskInt("Entrez un nombre : ", out number);
}

Console.WriteLine(IntToBinary(number));