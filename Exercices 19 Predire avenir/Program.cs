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

//on definie des variable uint et on les initialises avec 0
uint heure = 0;
uint minute = 0;

//on définie des variables success et on les initialises avec faux
bool success = false;
bool successHeure = false;
bool successMinute = false;

//on boucle tant que success est faux
while (!success)
{
    if (!successHeure)
    {
        successHeure = AskUInt("Heures : ", out heure);
    }

    if (!successMinute)
    {
        successMinute = AskUInt("Minutes : ", out minute);
    }

    success = successHeure && successMinute;
}

minute++;
if (minute >= 60)
{
    minute %= 60;
    heure++;
}

if(heure >= 24)
{
    heure %= 24;
}

Console.WriteLine($"Dans une minute il seras {heure.ToString("D2")}:{minute.ToString("D2")}");