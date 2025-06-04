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

uint jour = 0;
uint mois = 0;
uint annees = 0;

bool success = false;
bool successJour = false;
bool successMois = false;
bool successAnnees= false;

bool anneeBissextile = false;
bool anneeValide = false;

string message;

while(!success)
{
    if(!successJour)
    {
        successJour = AskUInt("Jour : ", out jour);
    }

    if (!successMois)
    {
        successMois = AskUInt("Mois : ", out mois);
    }

    if (!successAnnees)
    {
        successAnnees = AskUInt("Année : ", out annees);
    }

    success = successJour && successMois && successAnnees;
}

//les année bissextile sont toujours divisible par 4
if(annees%4 == 0)
{
    //les année divisible par 100 mais pas par 400 ne sont pas bissextile
    if(annees%100 == 0 && annees%400 != 0)
    {
        anneeBissextile = false;
    } 
    else 
    {
        anneeBissextile = true;
    }
} 
else
{
    anneeBissextile = false;
}

//en fonction du mois on demande un nombre de jour différent
switch(mois)
{
    case 1:
        anneeValide = jour <= 31;
        break;
    case 2:
        if(anneeBissextile)
        {
            anneeValide = jour <= 29;
        }
        else
        {
            anneeValide = jour <= 28;
        }
            break;
    case 3:
        anneeValide = jour <= 31;
        break;
    case 4:
        anneeValide = jour <= 30;
        break;
    case 5:
        anneeValide = jour <= 31;
        break;
    case 6:
        anneeValide = jour <= 30;
        break;
    case 7:
        anneeValide = jour <= 31;
        break;
    case 8:
        anneeValide = jour <= 31;
        break;
    case 9:
        anneeValide = jour <= 30;
        break;
    case 10:
        anneeValide = jour <= 31;
        break;
    case 11:
        anneeValide = jour <= 30;
        break;
    case 12:
        anneeValide = jour <= 31;
        break;
}

if(anneeValide)
{
    message = "";
}
else
{
    message = "non ";
}

Console.WriteLine($"Date {message}valide");