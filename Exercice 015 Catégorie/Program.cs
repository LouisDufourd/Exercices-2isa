//on définie une variable age et on l'initialise avec 0
int age = 0;
//on définie une variable success et on l'initialise avec faux
bool success = false;
//on définit une variable categorie
string categorie;

//on boucle tant que success est faux
while (!success)
{
    //on demande à l'utilisateur d'entrée l'age de l'enfant
    Console.Write("Age de l'enfant : ");
    //on déclare une variable asked et on y assigne la valeur entrée par l'utilisateur
    string asked = Console.ReadLine();

    //on s'assure que l'utilisateur n'as pas entrée une valeur null dans asked
    if (asked == null)
    {
        //on recomance la boucle du début quand asked est null
        continue;
    }

    //on essaye de convertir ce que l'utilisateur à taper en un nombre
    //success = true si la convertions est réussi et false si ça à échoué
    success = int.TryParse(asked, out age);
}

if(age >= 12)
{
    categorie = "Cadet";
} 
else if (age >= 10)
{
    categorie = "Minime";
} 
else if (age >= 8)
{
    categorie = "Pupille";
}
else if (age >= 6)
{
    categorie = "Poussin";
} 
else 
{
    categorie = "Aucune catégorie";
}

    Console.WriteLine($"La catégorie d'un enfant agé de {age} est : {categorie}");