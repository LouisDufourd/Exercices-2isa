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
    Console.WriteLine();

    if (asked.KeyChar != '>' && asked.KeyChar != '<')
    {
        character = (char)0x0;
        return false;
    }


    character = asked.KeyChar;
    return true;
}

string CaesarOffset(string origin, bool direction, int offset)
{
    var builder = new StringBuilder(origin);

    for (int i = 0; i < builder.Length; i++)
    {
        if (builder[i] >= 'A' && builder[i] <= 'Z')
        {
            int index = builder[i] - 'A';

            if (direction)
            {
                index = (index + offset) % 26;
                builder[i] = (char)('A' + index);
                continue;
            }

            index = (index - offset + 26) % 26;
            builder[i] = (char)('A' + index);
        }
        else if (builder[i] >= 'a' && builder[i] <= 'z')
        {
            int index = builder[i] - 'a';

            if (direction)
            {
                index = (index + offset % 26) % 26;
                builder[i] = (char)('a' + index);
                continue;
            }

            index = (index - offset % 26 + 26) % 26;
            builder[i] = (char)('a' + index);
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