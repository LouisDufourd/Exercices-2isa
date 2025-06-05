static double Distance(double xA, double xB, double yA, double yB)
{
    return Math.Sqrt(Math.Pow(xB - xA, 2) + Math.Pow(yB - yA, 2));
}

static bool AskDouble(string question, out double number)
{
    Console.Write(question);
    string? asked = Console.ReadLine();
    if (asked == null)
    {
        number = 0;
        return false;
    }
    return double.TryParse(asked, out number);
}

double xA = .0;
double yA = .0;
double xB = .0;
double yB = .0;

bool success = false;
bool successXA = false;
bool successYA = false;
bool successXB = false;
bool successYB = false;

while(!success)
{
    if(!successXA)
    {
        successXA = AskDouble("Entrée la coordonée x du point A : ", out xA);
    }
    if (!successYA)
    {
        successYA = AskDouble("Entrée la coordonée y du point A : ", out yA);
    }
    if (!successXB)
    {
        successXB = AskDouble("Entrée la coordonée x du point B : ", out xB);
    }
    
    if(!successYB)
    {
        successYB = AskDouble("Entrée la coordonée y du point B : ", out yB);
    }

    success = successXA && successYA && successXB && successYB;
}

Console.WriteLine($"La distance entre le point A et B est égale à : {Distance(xA, xB, yA, yB)}");