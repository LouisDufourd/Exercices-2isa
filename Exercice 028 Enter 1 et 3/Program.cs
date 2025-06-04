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

bool success = false;

while (!success)
{
    AskUInt("Rentrez un nombre entier : ", out nombre);
    if(nombre >= 1 && nombre <= 3)
    {
        success = true;
    }
}

Console.WriteLine("Bravo!");