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
uint second = 0;

//on définie des variables success et on les initialises avec faux
bool success = false;
bool successHeure = false;
bool successMinute = false;
bool successSecond = false;

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

    if(!successSecond)
    {
        successSecond = AskUInt("Secondes : ", out second);
    }

    success = successHeure && successMinute && successSecond;
}

second++;
if(second >= 60)
{
    second %= 60;
    minute++;
}

if(minute >= 60)
{
    minute %= 60;
    heure++;
}

if(heure >= 24)
{
    heure %= 24;
}

Console.WriteLine($"Dans une seconde, il sera {heure} heure(s), {minute} minute(s) et {second} seconde(s)");