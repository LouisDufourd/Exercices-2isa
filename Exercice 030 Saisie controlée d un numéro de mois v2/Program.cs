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

uint mois = 0;
bool success = false;

while (!success)
{
    success = AskUInt("Entrez un mois : ", out mois);
    if (!success) continue;
    if (mois < 1 || mois > 12)
    {
        success = false;
        Console.WriteLine("Erreur, saisir un numéro de mois entre 1 et 12");
    }
}

Console.WriteLine($"Bravo, vous avez saisi {mois}");