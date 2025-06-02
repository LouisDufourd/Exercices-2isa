//on affiche une demande à l'utilisateur
Console.Write("Entrez un charactère : ");
//on récupère ce que tape l'utilisateur et le met dans la variable charactère
char charactère = Console.ReadKey().KeyChar;
Console.WriteLine();

//on fait un switch case sur le charactère
switch (charactère)
{
    //dans le cas ou le charactère est o ou O
    case 'o':
    case 'O':
        Console.WriteLine("Affirmatif");
        break;
    //dans le cas ou le charactère est n ou N
    case 'n':
    case 'N':
        Console.WriteLine("Négatif");
        break;
    //dans les autres cas
    default:
        Console.WriteLine("???");
        break;
}