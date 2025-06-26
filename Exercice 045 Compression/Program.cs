//la fonction prend en paramètre une chaine de charactère input et retourne la chaine comprésser
string Compress(string? input)
{
    //si la chaine de charactère est null on retourne une chaine vide
    if(input == null) return "";

    //on crée une chaine de charactère comprésser qui serviras à contenir l'input comprésser
    string compressed = "";
    //on assigne le charactère précédent au charactère NULL
    char currentChar = (char)0;
    //on initialise une quantité à 1
    int quantity = 1;

    //on parcours la chaine de charactère et on crée une variable qui stockera le charactère séléctionné
    foreach (char character in input)
    {
        //on regarde si le précédent charactère est différent du charactère actuelle si il est différent on ajoute le précédent charactère avec sa quantité à compressed
        if (currentChar != character)
        {
            //on ajoute à compressed la quantity si elle est supérieur à 1 sinon on met ajoute une chaine vide puis on ajoute le précédent charactère
            compressed += (quantity > 1 ? $"{quantity}" : "") + currentChar;
            //on assigne le précédent character avec le caractère actuelle
            currentChar = character;
            //on met la quantité à 1
            quantity = 1;
        }
        //on incrémente la quantité
        else quantity++;
    }

    // ? : est un if else avec une retour ex : condition ? si true : si false
    compressed += (quantity > 1 ? $"{quantity}" : "") + currentChar;

    //on retourne compresser
    return compressed;
}

//on affiche à l'utilisateur une demande d'entrée de chaine de charactère
Console.Write("Rentrez un chaine de charactère à compresser : ");

//on écrit dans text ce que l'utilisateur à taper
string? text = Console.ReadLine();

//on affiche la chane de charactère compresser
Console.WriteLine($"Version compressez: {Compress(text)}");