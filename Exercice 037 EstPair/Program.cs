static bool IsEven(uint number)
{
    return number % 2 == 0;
}

static bool AskUInt(string question, out uint number)
{
    Console.Write(question);
    string? asked = Console.ReadLine();
    if (asked == null)
    {
        number = 0;
        return false;
    }
    return uint.TryParse(asked, out number);
}

uint nombre = 0;

do{} while (!AskUInt("Rentrez un nombre: ", out nombre));

if(IsEven(nombre))
{
    Console.WriteLine("Le nombre est pair");
}
else
{
    Console.WriteLine("Le nombre est pair");
}

