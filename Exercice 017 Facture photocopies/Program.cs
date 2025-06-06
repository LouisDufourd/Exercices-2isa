//on dit à la console d'écrire en l'utf-8 au lieu de l'ascii
Console.OutputEncoding = System.Text.Encoding.UTF8;
//on définie une variable nombresPhotocopies et on l'initialise avec 0
int nombresPhotocopies = 0;
//on definie une variable prix qui contiendras le prix total des photocopie
double prix = 0;
//on définie une variable success et on l'initialise avec faux
bool success = false;

//on boucle tant que success est faux
while (!success)
{
    //on demande à l'utilisateur d'entrée un nombre entier
    Console.Write("Veuillez rentrez le nombres de photocopies voulues : ");
    //on déclare une variable et on y assigne la valeur entrée par l'utilisateur
    string? asked = Console.ReadLine();

    //on s'assure que l'utilisateur n'as pas entrée une valeur null dans asked
    if (asked == null)
    {
        //on recomance la boucle du début quand asked est null
        continue;
    }

    //on essaye de convertir ce que l'utilisateur à taper en un nombre entier
    //success = true si la convertions est réussi et false si ça à échoué
    success = int.TryParse(asked, out nombresPhotocopies);
}

bool breakFlag = false;

for (int i = 0; nombresPhotocopies > 0 && !breakFlag; i++)
{
    switch(i)
    {
        case 0:
            prix += Math.Min(10, nombresPhotocopies) * .1;
            nombresPhotocopies -= 10;
            break;
        case 1:
            prix += Math.Min(20, nombresPhotocopies) * .09;
            nombresPhotocopies -= 20;
            break;
        default:
            prix += nombresPhotocopies * .08;
            breakFlag = true;
            break;
    }
}

Console.WriteLine($"Facture : {prix.ToString("F2")}€");