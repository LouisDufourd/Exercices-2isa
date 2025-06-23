static void ClearCurrentConsoleLine()
{
    Console.SetCursorPosition(0, Console.CursorTop - 1);
    int currentLineCursor = Console.CursorTop;
    Console.SetCursorPosition(0, Console.CursorTop);
    Console.Write(new string(' ', Console.WindowWidth));
    Console.SetCursorPosition(0, currentLineCursor);
}

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

List<string> names = new List<string>();

for (int i = 0; i < 12;)
{
    if(AskString("Entrez un nom (Tapez exit pour arreter de taper des noms) : ", out string name) && !names.Contains(name.ToLower()))
    {
        if (name == "exit")
        {
            ClearCurrentConsoleLine();
            break;
        }
        names.Add(name);
        i++;
    }
    ClearCurrentConsoleLine();
}

uint number = 0;
bool isThereAnError = false;

while (!AskUInt($"Choisissez combiens de nom voulez-vous tirez au sort (vous avez {names.Count} noms) : ", out number) || number > names.Count)
{
    if (isThereAnError) ClearCurrentConsoleLine();
    isThereAnError = true;
    ClearCurrentConsoleLine();
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"Veuillez entrez un nombre entier positif et inférieure ou égale à {names.Count}");
    Console.ForegroundColor = ConsoleColor.White;
}

if (isThereAnError) ClearCurrentConsoleLine();
ClearCurrentConsoleLine();

isThereAnError = false;
Random rd = new();

List<string> choosedNames = new();

for (int i = 0; i < number;)
{
    int index = rd.Next(names.Count);
    string choosedName = names[index];
    if (choosedNames.Contains(choosedName)) continue;

    choosedNames.Add(choosedName);
    i++;
}

Console.WriteLine("Les noms tirez aux sorts sont : ");
foreach (var choosedName in choosedNames)
{
    Console.WriteLine($"\t-{choosedName}");
}