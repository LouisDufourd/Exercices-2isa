//Déclarer et initalise le rayon que l'on demanderas à l'utilisateur
double rayon = 0;
//Déclare le périmètre que l'on calculeras avec le rayon demander à l'utilisateur
double perimeter;
//Déclare et initialize la variable qui contiendra le succés ou non de la convertion
bool success =  false;
//répéte tant que la variable success est faux
while (!success)
{
    //affiche à l'utilisateur la demande de la value du rayon d'un cercle
    Console.Write("Rentrez la valeur du rayon du cercle : ");
    //Déclare la variable qui contiendra la réponse de l'utilisateur
    String asked;
    //initialise la variable asked à ce que l'utilisateur à taper
    asked = Console.ReadLine();
    //verifie que l'utilisateur n'as pas taper null si il a taper null on redemande
    if (asked == null) continue;

    //assigne à success si la conversion est réuissi et assigne à rayon la value de la conversion
    success = double.TryParse(asked, out rayon);
}

//calcule le périmètre d'un cercle avec la variable rayon et stock le résultat dans la variable perimeter
perimeter = Math.PI * 2 * rayon;
//affiche le périmètre du cercle à l'utilisateur
Console.WriteLine($"Le cercle de {rayon} à un périmètre égale à {perimeter}.");