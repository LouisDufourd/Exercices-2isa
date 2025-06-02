//déclare la premier, deuxieme chaine de charactère et une chaine de charactère temporaire
string firstString, secondString, temp;

//intialise firstString avec une chaine vide
firstString = "";

//intialise secondString avec une chaine vide
secondString = "";

//déclare et initalise une variable de succés
bool success = false;

//tant que la variable success n'est pas true on redemande à l'utilisateur
while(!success)
{
    //Affiche à l'utilisateur une demande de première chaine de charactère
    Console.Write("Rentrez une première chaine de caractères : ");

    //Initialise la variable firstString avec ce que tape l'utilisateur
    firstString = Console.ReadLine();

    //verifie que l'utilisateur n'entre pas une chaine de charactère null
    if (firstString == null) continue;

    //Affiche à l'utilisateur une demande de deuxième chaine de charactère
    Console.Write("Rentrez une deuxième chaine de caractères : ");

    //Initialise la variable secondString avec ce que tape l'utilisateur
    secondString = Console.ReadLine();

    //verifie que l'utilisateur n'entre pas une chaine de charactère null
    if (firstString == null) continue;

    //si aucune des chaine est null ou vide affecte à la variable success true
    success = firstString != "" && secondString != "";
}

//affiche les 2 première chaine avant permutation à l'utilisateur
Console.WriteLine($"Avant la permutation :\nChaîne 1 : {firstString}\nChaîne2: {secondString}");

//assigne la varaible firstString à la variable temp
temp = firstString;

//assigne à la variable firstString la varaible secondString
firstString = secondString;

//assigne à la variable secondString la varaible temp
secondString = temp;

//affiche les 2 première chaine après permutation à l'utilisateur
Console.WriteLine($"Après la permutation :\nChaîne 1 : {firstString}\nChaîne2: {secondString}");