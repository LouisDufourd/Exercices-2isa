//on définie une variable age et on l'initialise avec 0
uint age = 0;
//on définie une variable anneePermis et on l'initialise avec 0
uint anneePermis = 0;
//on définie une variable nombreAccidents et on l'initialise avec 0
uint nombreAccidents = 0;
//on définie une variable anneeAnciente et on l'initialise avec 0
uint anneeAnciente = 0;

//on définie une variable success et on l'initialise avec faux
bool success = false;
bool successAge = false;
bool successAnneePermis = false;
bool successNombreAccidents = false;
bool successAnneeAnciente = false;

//on boucle tant que success est faux
while (!success)
{
    if(!successAge)
    {
        successAge = AskUInt("Age : ", out age);
    }

    if(!successAnneePermis)
    {
        successAnneePermis = AskUInt("Années de permis : ", out anneePermis);
    }

    if(!successNombreAccidents)
    {
        successNombreAccidents = AskUInt("Nombre d'accidents : ", out nombreAccidents);
    }

    if(!successAnneeAnciente)
    {
        successAnneeAnciente = AskUInt("Années d'ancienneté : ", out anneeAnciente);
    }

    success = successAge && successAnneeAnciente && successAnneePermis && successNombreAccidents;
}

string tarif;

if(age <= 25)
{
    if(anneePermis <= 2)
    {
        switch (nombreAccidents)
        {
            case 0:
                tarif = "Rouge";
                break;
            default:
                tarif = "Non assurable";
                break;
        }
    } 
    else
    {
        switch(nombreAccidents)
        {
            case 0:
                tarif = "Orange";
                break;
            case 1:
                tarif = "Rouge";
                break;
            default:
                tarif = "Non assurable";
                break;
        }
    }
}
else
{
    if (anneePermis <= 2)
    {
        switch(nombreAccidents)
        {
            case 0:
                tarif = "Orange";
                break;
            case 1:
                tarif = "Rouge";
                break;
            default:
                tarif = "Non assurable";
                break;
        }
    }
    else
    {
        switch(nombreAccidents)
        {
            case 0:
                tarif = "Vert";
                break;
            case 1:
                tarif = "Orange";
                break;
            case 2:
                tarif = "Rouge";
                break;
            default:
                tarif = "Non assurable assurable";
                break;
        }
    }
}

if(anneeAnciente > 5)
{
    switch(tarif)
    {
        case "Vert":
            tarif = "Bleu";
            break;
        case "Orange":
            tarif = "Vert";
            break;
        case "Rouge":
            tarif = "Orange";
            break;
    }
}

Console.WriteLine(tarif);

static bool AskInt(string question, out int age)
{
    Console.Write(question);
    string? asked = Console.ReadLine();

    if (asked == null)
    {
        age = 0;
        return false;
    }

    return int.TryParse(asked, out age);
}

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