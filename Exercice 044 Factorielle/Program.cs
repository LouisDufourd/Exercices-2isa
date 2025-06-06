static bool AskInt(string question, out int nombre)
{
    Console.Write(question);
    string? asked = Console.ReadLine();

    if (asked == null)
    {
        nombre = 0;
        return false;
    }

    return int.TryParse(asked, out nombre);
}

static int Factorial(int number)
{
    int factorial = 1;
    for (int i = 1; i <= number; i++)
    {
        factorial *= i;
    }

    return factorial;
}

int nombre = 0;

bool success = false;

while (!success)
{
    success = AskInt("Rentrez un nombre entier : ", out nombre);
}

Console.WriteLine($"La somme des {nombre} premier nombre entier est égale à {Factorial(nombre)}");