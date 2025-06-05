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

Random rand = new Random();
int choosedNumber = rand.Next(1, 100);
bool success = false;
while(!success)
{
    success = AskUInt("Entrer un nombre : ", out uint nombre);
    if (!success) continue;

    if(nombre < choosedNumber)
    {
        Console.WriteLine("Trop petit");
        success = false;
    }
    else if (nombre > choosedNumber)
    {
        Console.WriteLine("Trop grand");
        success = false;
    }
    else
    {
        Console.WriteLine("Voulez vous rejouez (O)?");
        char answer = Console.ReadKey().KeyChar;
        switch(answer)
        {
            case 'O' or 'o':
                success = false;
                choosedNumber = rand.Next(1, 100);
                Console.WriteLine();
                break;
        }
    }
}