//on définie une variable nombre et on l'initialise avec 0
double nombre = 0;
//on définie une variable success et on l'initialise avec faux
bool success = false;

//on boucle tant que success est faux
while (!success)
{
    //on demande à l'utilisateur d'entrée un nombre entier
    Console.Write("Rentrez un nombre réel : ");
    //on déclare une variable et on y assigne la valeur entrée par l'utilisateur
    string asked = Console.ReadLine();

    //on s'assure que l'utilisateur n'as pas entrée une valeur null dans asked
    if (asked == null)
    {
        //on recomance la boucle du début quand asked  est null
        continue;
    }

    //on essaye de convertir ce que l'utilisateur à taper en un nombre
    //success = true si la convertions est réussi et false si ça à échoué
    success = double.TryParse(asked, out nombre);
}

//on regarde si le nombre est supérieur ou égale à 10
if (nombre >= 10)
{
    Console.WriteLine("Admis");

}
//on regarde si le nombre est supérieur à 8
else if (nombre > 8)
{
    Console.WriteLine("Rattrapage");
}
//ici le nombre est inferieur à 8
else
{
    Console.WriteLine("Echec");
}