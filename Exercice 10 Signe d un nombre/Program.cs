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
    if (asked == null)
    {
        //on recomance la boucle du début quand asked  est null
        continue;
    }

    //on essaye de convertir ce que l'utilisateur à taper en un nombre
    //success = true si la convertions est réussi et false si ça à échoué
    success = int.TryParse(asked, out nombre);
}

//on regarde si le nombre est inférieur à 0
if(nombre < 0)
{
    Console.WriteLine("Ce nombre est négatif");

}
//on regarde si le nombre est supérieur à 0
else if (nombre > 0)
{
    Console.WriteLine("Ce nombre est positif");
}
//ici le nombre est 0
else
{
    Console.WriteLine("Ce nombre est null");
}