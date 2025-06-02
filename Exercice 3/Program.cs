//initialise et déclare le nombre, et le succés de la convertion
int number = 0;
bool success = false;
//demande à l'utilisateur un nombre jusqu'à ce qu'il en rentre un
while (!success)
{
    //afficher la demande à l'utisateur d'un chiffre
    Console.Write("Rentrez un nombre entier: ");
    //récupere ce que l'utilisateur à taper
    String asked = Console.ReadLine();
    //verifie que l'utisilateur n'entre pas null
    if (asked == null) {
        //si la chaine de charactère est null on n'essaye pas de parse en int et redemande à l'utilisateur
        continue;
    }
    
    //essaye de convertir la chaine de charactère
    success = int.TryParse(asked, out number);
}

//affiche à l'utilisateur le cube du nombre qui a été demander
Console.WriteLine($"Le cube de {number} est égale à {Math.Pow(number, 3)}");