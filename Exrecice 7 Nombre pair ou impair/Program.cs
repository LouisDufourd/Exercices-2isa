//on définie une variable nombre et on l'initialise avec 0
int nombre = 0;
//on définie une variable success et on l'initialise avec faux
bool success = false;

//on boucle tant que success est faux
while (!success)
{
    //on demande à l'utilisateur d'entrée un nombre entier
    Console.Write("Rentrez un nombre entier : ");
    //on déclare une variable et on y assigne la valeur entrée par l'utilisateur
    string asked = Console.ReadLine();

    //on s'assure que l'utilisateur n'as pas entrée une valeur null dans asked
    if(asked == null)
    {
        //on recomance la boucle du début quand asked  est null
        continue;
    }

    //on essaye de convertir ce que l'utilisateur à taper en un nombre
    //success = true si la convertions est réussi et false si ça à échoué
    success = int.TryParse(asked, out nombre);
}

//on fait nombre modulo 2 qui retournera 0 quand le nombre est pair et 1 quand impair
if(nombre%2 == 0)
{
    //on écrit à l'utilisateur que le nombre est pair
    Console.WriteLine("Le nombre que vous avez rentré est un nombre pair");
}