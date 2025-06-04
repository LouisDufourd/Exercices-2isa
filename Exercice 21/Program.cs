static bool AskDouble(string question, out double nombre)
{
    Console.Write(question);
    string? asked = Console.ReadLine();

    if (asked == null)
    {
        nombre = 0;
        return false;
    }

    return double.TryParse(asked, out nombre);
}

//on definie des variable double et on les initialises avec 0
double firstCandidat = 0;
double secondCandidat = 0;
double thirdCandidat = 0;
double fourthCandidat = 0;

//on définie des variables success et on les initialises avec faux
bool success = false;
bool successFirst = false;
bool successSecond = false;
bool successThird = false;
bool successFourth = false;

//on boucle tant que success est faux
while (!success)
{
    if (!successFirst)
    {
        successFirst = AskDouble("Candidat 1 : ", out firstCandidat);
    }

    if (!successSecond)
    {
        successSecond = AskDouble("Candidat 2 : ", out secondCandidat);
    }

    if (!successThird)
    {
        successThird = AskDouble("Candidat 3 : ", out thirdCandidat);
    }

    if (!successFourth)
    {
        successFourth = AskDouble("Candidat 4 : ", out fourthCandidat);
    }

    success = successFirst && successSecond && successThird && successFourth;
    if(success && firstCandidat + secondCandidat + thirdCandidat + fourthCandidat != 100)
    {
        success = false;
        successFirst = false;
        successSecond = false;
        successThird = false;
        successFourth = false;

        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("le total des 4 canditat n'est pas 100");
        Console.ForegroundColor = ConsoleColor.White;
    }
}

string message;

if(firstCandidat >= 50)
{
    message = "élu au premier tour";
} 
else if (firstCandidat >= 12.5)
{
    double[] candidats = { firstCandidat, secondCandidat, thirdCandidat, fourthCandidat };
    Array.Sort(candidats);
    if(candidats.Last() == firstCandidat)
    {
        message = "ballottage favorable";
    } 
    else
    {
        message = "ballottage défavorable";
    }
}
else
{
    message = "éliminé au premier tour";
}

Console.WriteLine($"Candidat 1 : {message}");