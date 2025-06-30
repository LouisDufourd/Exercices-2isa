using System.Globalization;
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

    chaine = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(asked);
    return true;
}

static bool AskTOEIC(string question, out uint number)
{
    Console.Write(question);
    string? asked = Console.ReadLine();
    if (asked == null)
    {
        number = 0;
        return false;
    }

    return uint.TryParse(asked, out number) && (number >= 10 && number <= 990);
}

static void ClearCurrentConsoleLine()
{
    Console.SetCursorPosition(0, Console.CursorTop - 1);
    int currentLineCursor = Console.CursorTop;
    Console.SetCursorPosition(0, Console.CursorTop);
    Console.Write(new string(' ', Console.WindowWidth));
    Console.SetCursorPosition(0, currentLineCursor);
}

static void PrintWelcomMessage(string userName, uint scoreTOEIC)
{
    Console.WriteLine("*****************");
    Console.WriteLine("** Bienvenue ! **");
    Console.WriteLine("*****************");

    Console.WriteLine($"Bonjour {userName}.");
    Console.WriteLine("Nous sommes ravies de t'acceuillir parmis nous.");

    string message;

    if (scoreTOEIC > 850) message = $"Incroyable ! Félicitations pour votre score de {scoreTOEIC} au TOIEC ☻";
    else if (scoreTOEIC > 650) message = $"Félicitations pour votre score de {scoreTOEIC} au TOIEC ☻";
    else message = "Ne vous découragez pas le TOEIC est une épreuve qui nécessite de la ténacité !";
    
    Console.WriteLine(message);
}

Console.OutputEncoding = Encoding.UTF8;

bool isThereAnError = false;

string nom;
uint score;

while (!AskString("Veuillez saisir votre nom : ", out nom))
{
    if (isThereAnError) ClearCurrentConsoleLine();
    ClearCurrentConsoleLine();
    isThereAnError = true;
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("Le nom que vous avez entrée ne peut être null");
    Console.ForegroundColor = ConsoleColor.White;
}

if (isThereAnError) ClearCurrentConsoleLine();
ClearCurrentConsoleLine();

isThereAnError = false;

while (!AskTOEIC("Veuillez saisir votre score au TOEIC : ", out score))
{
    if (isThereAnError) ClearCurrentConsoleLine();
    ClearCurrentConsoleLine();
    isThereAnError = true;
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("Vous devez entrée un nombre entier positif entre 10 et 990 (10 ≥ n ≤ 990)");
    Console.ForegroundColor = ConsoleColor.White;
}

if (isThereAnError) ClearCurrentConsoleLine();
ClearCurrentConsoleLine();

PrintWelcomMessage(nom, score);