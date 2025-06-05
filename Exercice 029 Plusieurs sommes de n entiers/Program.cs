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

bool successNombre = false;
bool breakFlag = false;

while(!breakFlag)
{
    successNombre = AskUInt("Rentrez un nombre entier : ", out uint nombre);
    if (!successNombre) continue;

    int somme = 0;
    for (int i = 0; i <= nombre; i++)
    {
        somme += i;
    }

    Console.WriteLine($"La somme des {nombre} premimer nombre entiers est égale à : {somme}");
    Console.WriteLine("Souhaitez vouis calculer une nouvelle somme des N premiers entier (Oui/Non)");
    string? asked = Console.ReadLine();
    
    if (asked == null) continue;

    if (string.Equals(asked, "non", StringComparison.OrdinalIgnoreCase)) breakFlag = true;
}