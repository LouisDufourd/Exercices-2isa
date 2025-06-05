static bool AskUInt(string question, out uint nombre)
{
    Console.Write(question);
    string? asked = Console.ReadLine();

    if (asked == null)
    {
        nombre = 0;
        return false;
    }

    return uint.TryParse(asked, out nombre);
}

uint nombre = 0;
uint factorial = 1;

bool success = false;

while (!success)
{
    success = AskUInt("Rentrez un nombre entier : ", out nombre);
}

for (uint i = 1; i <= nombre; i++)
{
    factorial *= i;
}

Console.WriteLine($"La somme des {nombre} premier nombre entier est égale à {factorial}");
