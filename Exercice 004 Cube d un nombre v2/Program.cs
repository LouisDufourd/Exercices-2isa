//initialisé et déclaré le nombre que l'on demandera à l'utilisateur
double number = .0;
//intialise et déclarela variable success avec false
bool success = false;

//si la conversion à échoué on recomance tous sinon on continue
while (!success)
{
    //affiche à l'utilisateur la demande d'un nombre réel
    Console.Write("Rentrez un nombre réel : ");
    //demande et stock ce que l'utilisateur à rentrer 
    String asked = Console.ReadLine();
    //Verifie que l'utilisateur n'as pas rentrer une chaine null
    if (asked == null) continue;

    //essaye de convertir ce que l'utilisateur rentre est un nombre
    //assigne true ou false à success en fonction de si la conversion réussi ou pas
    success = double.TryParse(asked, out number );
}

//affiche le cube du nombre entrée par l'utilisateur
Console.WriteLine($"Le cuve de {number} est égal à {Math.Pow(number,3)}");