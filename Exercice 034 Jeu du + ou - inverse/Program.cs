int min = 1;
int max = 100;

int choosedNumber = new Random().Next(min, max);
bool found = false;

do
{
    Console.WriteLine("Choisisez un nombre entre {min} et {max}. (taper entrer pour continuer)");
} while (Console.ReadKey().Key != ConsoleKey.Enter);

Console.WriteLine("Tapez + si le nombre est plus petit que le nombre que vous avez choisis.");
Console.WriteLine("tapez - si le nombre est plus grand que le nombre que vous avez choisis.");
Console.WriteLine("tapez v si le nombre est le nombre que vous avez choisis.");
Console.WriteLine($"Est-ce-que le nombre est {choosedNumber} ?");

while (!found)
{
    ConsoleKeyInfo key = Console.ReadKey();
    Console.WriteLine();
    if (key.Key.Equals(ConsoleKey.Escape)) break;
    if (key.KeyChar != '+' && key.KeyChar != '-' && key.KeyChar != 'v') continue;

    switch (key.KeyChar)
    {
        case '+':
            min = choosedNumber;
            break;
        case '-':
            max = choosedNumber;
            break;
        case 'v':
            found = true;
            continue;
    }

    if (min == max)
    {
        Console.WriteLine("Impossible de trouver le nombre étes vous sur d'avoir choisi un nombre entre {min} et {max} ?");
        return;
    }

    choosedNumber = (min + max) / 2;

    Console.WriteLine("Tapez + si le nombre est plus petit que le nombre que vous avez choisi.");
    Console.WriteLine("Tapez - si le nombre est plus grand que le nombre que vous avez choisi.");
    Console.WriteLine("Tapez v si le nombre est le nombre que vous avez choisi.");
    Console.WriteLine($"Est-ce-que le nombre est {choosedNumber} ?");
}