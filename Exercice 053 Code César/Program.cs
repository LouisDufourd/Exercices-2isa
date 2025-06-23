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

string ask = "";

while(!AskString("Entrez une chaine de charactère à crypté: ", out ask))
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("Veuillez entrez une chaine de charactère non null");
    Console.ForegroundColor = ConsoleColor.White;
}

var builder = new StringBuilder(ask);

for (int i = 0; i < builder.Length; i++)
{
    if (builder[i] == 'z') builder[i] = 'c';
    else if (builder[i] == 'y') builder[i] = 'b';
    else if (builder[i] == 'x') builder[i] = 'a';
    else if (builder[i] == 'Z') builder[i] = 'C';
    else if (builder[i] == 'Y') builder[i] = 'B';
    else if (builder[i] == 'X') builder[i] = 'A';
    else if ((builder[i] >= 'a' && builder[i] <= 'w') || (builder[i] >= 'A' && builder[i] <= 'W')) builder[i] += (char) 3;
}

Console.WriteLine(builder.ToString());