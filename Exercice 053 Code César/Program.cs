using System.Text;

bool AskString(string question, out string chaine)
{
    Console.Write(question);
    string? asked = Console.ReadLine();

    if (asked == null)
    {
        chaine = "";
        return false;
    }

    chaine = asked;
    return true;
}

bool AskDirection(string question, out char character)
{
    Console.Write(question);
    ConsoleKeyInfo asked = Console.ReadKey();

    if (asked.KeyChar != '>' && asked.KeyChar != '<')
    {
        character = (char)0x0;
        return false;
    }

    Console.WriteLine();

    character = asked.KeyChar;
    return true;
}

string CaesarOffset(string origin, bool direction, int offset)
{
    var builder = new StringBuilder(origin);

    for (int i = 0; i < builder.Length; i++)
    {
        if (builder[i] >= 65 && builder[i] <= 90)
        {
            int index = builder[i] - 65;

            if (direction)
            {
                index = (index + offset) % 26;
                builder[i] = (char)(65 + index);
                continue;
            }

            index = (index - offset + 26) % 26;
            builder[i] = (char)(65 + index);
        }
        else if (builder[i] >= 97 && builder[i] <= 122)
        {
            int index = builder[i] - 97;

            if (direction)
            {
                index = (index + offset) % 26;
                builder[i] = (char)(97 + index);
                continue;
            }

            index = (index - offset + 26) % 26;
            builder[i] = (char)(97 + index);
        }
    }

    return builder.ToString();
}

string ask;
char direction;

while(!AskString("Entrez une chaine de charactère à crypté: ", out ask))
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("Veuillez entrez une chaine de charactère non null");
    Console.ForegroundColor = ConsoleColor.White;
}

while(!AskDirection("Choisissez une direction (< ou >): ", out direction))
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("Veuillez entrez un charactère '<' ou '>'");
    Console.ForegroundColor = ConsoleColor.White;
}

Console.WriteLine(CaesarOffset(ask, direction == '>', 3));