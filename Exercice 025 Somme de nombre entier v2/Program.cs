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
uint somme = 0;

bool success = false;

while(!success)
{
    success = AskUInt("Rentrez un nombre entier : ", out nombre);
}

for(uint i = 0; i <= nombre; i++)
{
    somme += i;
}

Console.WriteLine($"La somme des {nombre} premier nombre entier est égale à {somme}");
