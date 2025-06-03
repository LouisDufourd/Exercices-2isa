//on définie une variable premierNombre et on l'initialise avec 0
int age = 0;

char sexe = ' ';

//on définie une variable firstInputSuccess et on l'initialise avec faux
bool firstInputSuccess = false;

//on définie une variable secondInputSuccess et on l'initialise avec faux
bool secondInputSuccess = false;

//on définie le message que nous afficherons à l'utitilisateur
string message;

//on boucle tant que firstInputSuccess est faux et secondInputSuccess
while (!(firstInputSuccess && secondInputSuccess))
{
    //on regarde si le premier input à été convertie avec succéss pour ne pas redemander à l'utilisateur de l'entrée de nouveau
    if (!firstInputSuccess)
    {
        //on demande à l'utilisateur d'entrée son age
        Console.Write("Age : ");

        //on déclare une variable firstInput et on y assigne la valeur entrée par l'utilisateur
        string firstInput = Console.ReadLine();

        //on s'assure que l'utilisateur n'as pas entrée une valeur null dans firstInput
        if (firstInput == null)
        {
            //on recomance la boucle du début quand firstInput  est null
            continue;
        }

        //on essaye de convertir ce que l'utilisateur à taper en un nombre
        //firstInputSuccess = true si la convertions est réussi et false si ça à échoué
        firstInputSuccess = int.TryParse(firstInput, out age);
    }

    //on regarde si le deuxième nombre à été convertie avec succéss pour ne pas redemander à l'utilisateur de l'entrée de nouveau
    if (!secondInputSuccess)
    {
        //on demande à l'utilisateur d'entrée un deuxième nombre entier
        Console.Write("Sexe (H/F) : ");

        //on déclare une variable secondInput et on y assigne la valeur entrée par l'utilisateur
        sexe = Console.ReadKey().KeyChar;
        Console.WriteLine();

        switch (sexe)
        {
            //si le charactère taper est h ou f ou H ou F on met second input success
            case 'h' or 'f' or 'H' or 'F':
                //on mets secondInputSuccess à vrai
                secondInputSuccess = true;
                break;
        }
    }
}

switch(sexe)
{
    case 'h' or 'H':
        if(age > 20)
        {
            message = "Paye l'impôt";
        } 
        else
        {
            message = "Ne paie pas l'impôt";
        }
        break;
    case 'f' or 'F':
        if(age > 18 && age < 35)
        {
            message = "Paye l'impôt";
        } 
        else
        {
            message = "Ne paie pas l'impôt";
        }
        break;
    default:
        message = "Ne paie pas l'impôt";
        break;
}

Console.WriteLine(message);