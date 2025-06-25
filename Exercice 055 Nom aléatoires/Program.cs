using System.Xml.Linq;

static void ClearCurrentConsoleLine()
{
    if (Console.CursorTop == 0) return;
    Console.SetCursorPosition(0, Console.CursorTop - 1);
    int currentLineCursor = Console.CursorTop;
    Console.SetCursorPosition(0, Console.CursorTop);
    Console.Write(new string(' ', Console.WindowWidth));
    Console.SetCursorPosition(0, currentLineCursor);
}
static bool AskString(string question, out string chaine)
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

static bool Contains(string[] array, string str)
{
    if (array.Length == 0) return true;
    for (int i = 0; i < array.Length; i++)
    {
        if (array[i] == null) return false;
        if (array[i].Equals(str, StringComparison.OrdinalIgnoreCase)) return true;
    }

    return false;
}

uint size;
bool isThereAnError = false;

while (!AskUInt("Entrez le nombre de prénoms à entrées : ", out size))
{
    if (isThereAnError) ClearCurrentConsoleLine();
    isThereAnError = true;
    ClearCurrentConsoleLine();
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"Veuillez entrez un nombre entier positif");
    Console.ForegroundColor = ConsoleColor.White;
}

if (isThereAnError) ClearCurrentConsoleLine();
ClearCurrentConsoleLine();

string[] names = new string[size];
isThereAnError = false;

for (uint i = 0; i < size; )
{
    if(AskString("Entrez un nom : ", out string name) && !Contains(names, name))
    {
        names[i] = name;
        i++;
        if (isThereAnError)
        {
            isThereAnError = false;
            ClearCurrentConsoleLine();
        }
        ClearCurrentConsoleLine();
    }
    else
    {
        isThereAnError = true;
        ClearCurrentConsoleLine();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"Le nom que vous avez entrée à déjà été ajouter à la liste de prénoms");
        Console.ForegroundColor = ConsoleColor.White;

    }
}

if (isThereAnError) ClearCurrentConsoleLine();
ClearCurrentConsoleLine();

uint number;
isThereAnError = false;

while (!AskUInt($"Choisissez combiens de nom voulez-vous tirez au sort (vous avez {names.Length} noms) : ", out number) || number > names.Length)
{
    if (isThereAnError) ClearCurrentConsoleLine();
    isThereAnError = true;
    ClearCurrentConsoleLine();
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"Veuillez entrez un nombre entier positif et inférieure ou égale à {names.Length}");
    Console.ForegroundColor = ConsoleColor.White;
}

if (isThereAnError) ClearCurrentConsoleLine();
ClearCurrentConsoleLine();

isThereAnError = false;
Random rd = new();

string[] choosedNames = new string[number];

for (int i = 0; i < number;)
{
    int index = rd.Next(names.Length);
    string choosedName = names[index];
    if (Contains(choosedNames, choosedName)) continue;

    choosedNames[i] = choosedName;
    i++;
}

Console.WriteLine("Les noms tirez aux sorts sont : ");
foreach (var choosedName in choosedNames)
{
    Console.WriteLine($"\t- {choosedName}");
}