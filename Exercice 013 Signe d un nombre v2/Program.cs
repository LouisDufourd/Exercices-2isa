//on définie une variable premierNombre et on l'initialise avec 0
using System.ComponentModel.DataAnnotations;

int premierNombre = 0;

//on définie une variable deuxiemeNombre et on l'initialise avec 0
int deuxiemeNombre = 0;

//on définie une variable firstNumberSuccess et on l'initialise avec faux
bool firstNumberSuccess = false;

//on définie une variable secondNumberSuccess et on l'initialise avec faux
bool secondNumberSuccess = false;

//on boucle tant que firstNumberSuccess est faux
while (!(firstNumberSuccess && secondNumberSuccess))
{
    //on regarde si le premier nombre à été convertie avec succéss pour ne pas redemander à l'utilisateur de l'entrée de nouveau
    if (!firstNumberSuccess)
    {
        //on demande à l'utilisateur d'entrée un premier nombre entier
        Console.Write("Rentrez un premier nombre entier : ");

        //on déclare une variable firstNumber et on y assigne la valeur entrée par l'utilisateur
        string firstNumber = Console.ReadLine();

        //on s'assure que l'utilisateur n'as pas entrée une valeur null dans firstNumber
        if (firstNumber == null)
        {
            //on recomance la boucle du début quand firstNumber  est null
            continue;
        }

        //on essaye de convertir ce que l'utilisateur à taper en un nombre
        //firstNumberSuccess = true si la convertions est réussi et false si ça à échoué
        firstNumberSuccess = int.TryParse(firstNumber, out premierNombre);
    }

    //on regarde si le deuxième nombre à été convertie avec succéss pour ne pas redemander à l'utilisateur de l'entrée de nouveau
    if (!secondNumberSuccess)
    {
        //on demande à l'utilisateur d'entrée un deuxième nombre entier
        Console.Write("Rentrez un deuxième nombre entier : ");

        //on déclare une variable firstNumber et on y assigne la valeur entrée par l'utilisateur
        string secondNumber = Console.ReadLine();

        //on s'assure que l'utilisateur n'as pas entrée une valeur null dans firstNumber
        if (secondNumber == null)
        {
            //on recomance la boucle du début quand firstNumber  est null
            continue;
        }

        //on essaye de convertir ce que l'utilisateur à taper en un nombre
        //firstNumberSuccess = true si la convertions est réussi et false si ça à échoué
        secondNumberSuccess = int.TryParse(secondNumber, out deuxiemeNombre);
    }
}

//on regarde si un seul des deux nombre est négatif
if ((premierNombre < 0 && deuxiemeNombre > 0) || (premierNombre > 0 && deuxiemeNombre < 0))
{
    Console.WriteLine("Le signe du produit est négatif");
}
//on regarde si l'un des deux nombre est null
else if (premierNombre == 0 || deuxiemeNombre == 0)
{
    Console.WriteLine("Le signe du produit est null");
}
//tous les autre cas son positif
else
{
    Console.WriteLine("Le signe du produit est positif");
}