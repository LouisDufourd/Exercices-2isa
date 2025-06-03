using System.Text.Json;
using System.Text.RegularExpressions;

namespace Exercice_bonus
{
    class Program
    {
        private static readonly Regex sWhitespace = new Regex(@"\s+");

        public static void Main(string[] args)
        {
            //on déclare une variable opération qui contiendra ce que l'utilisateur taperas sous forme de tableau
            LinkedList<String> operations = new LinkedList<string>();

            //on demande à l'utilisateur d'entrée une opération
            Console.Write("Entrez une operation: ");

            //on enregistre ce que tape l'utilisateur dans une variable asked
            string asked = Console.ReadLine();

            //on s'assure que l'utilisateur n'as pas entrée une valeur null
            if(asked == null)
            {
                //on affiche à l'utilisateur qu'il faut taper une opération
                Console.WriteLine("Merci de taper une opération");

                // on ferme le programme
                return;
            }

            //on affecte à asked sa valeur sans les charactère invisible
            asked = sWhitespace.Replace(asked, "");

            //on déclare et assigne une variable temporaire appeler currentNumber
            string currentNumber = "";

            //on boucle sur tous les charactère de la chaine contenue dans variable
            for (int i = 0; i < asked.Length;  i++)
            {
                //on regarde si le charactère n'est pas un opérateur ou un charactère invisible
                if (!IsAnOperator(asked[i]) && !IsAPranthesis(asked[i]))
                {
                    //on mets dans asked le charactère qui n'est pas une opération ou une parenthèse
                    currentNumber += asked[i];
                    //on continue la boucle sans faire les instructions suivantes
                    continue;
                }

                //si currentNumber n'est pas vide et si currentNumber n'est pas un nombre entier
                if (currentNumber != "" && !IsInteger(currentNumber))
                {
                    // on ferme le programme
                    return;
                }

                try
                {
                    //on regarde si l'utilisateur n'as pas taper deux fois un opérateur
                    if (IsAnOperator(asked[i - 1]) && IsAnOperator(asked[i]))
                    {
                        Console.WriteLine("Il ne peux pas y avoir deux fois un opérateur à la suite des autres");
                        //on ferme le programme
                        return;
                    }

                    //on regarde si le charactère précédent est une parenthèse et que l'opérateur est une multiplication ou une division
                    if (asked[i - 1] == '(' && IsDiviseOrMultiply(asked[i]))
                    {
                        Console.WriteLine("L'opérateur après une parenthèse ne peux être une multiplisation ou division");
                        //on ferme le programme
                        return;
                    }
                }
                catch (IndexOutOfRangeException) { }

                //on ajoute à la liste l'opérateur et le chiffre actuelle
                currentNumber = addToList(operations, currentNumber, asked[i]);
            }

            //si currentNumber n'est pas vide on mets dans opération sa valeur
            if(currentNumber != "")
            {
                if(!IsInteger(currentNumber))
                {
                    //on ferme le program
                    return;
                }
                operations.AddLast(currentNumber);
            }

            Console.WriteLine(JsonSerializer.Serialize(operations));
        }

        public static bool IsAPranthesis(char character)
        {
            if (character == '(' || character == ')') return true;
            return false;
        }

        public static bool IsInteger(string value)
        {
            //on essaye de convertir la chaine de charactère en un nombre entier et on stock dans une varible si ça à marcher
            bool success = int.TryParse(value, out int _);
            
            //on regarde si la conversion n'est pas réussie
            if(!success)
            {
                //on affiche à l'utilisateur que ce qu'il a entrée n'est pas valide
                Console.WriteLine($"L'opération ne peux pas contenir autre chose que des chiffres, des opérateur ou des parenthèse: {value}");
            }

            //on retourne si la convertion à fonctionner ou non
            return success;
        }

        public static bool IsAnOperator(char character)
        {
            switch(character)
            {
                case '+' or '-' or '*' or '/': return true;
                default: return false;
            }
        }

        public static bool IsDiviseOrMultiply(char character)
        {
            return character == '*' || character == '/';
        }

        public static string addToList(LinkedList<string> operations, string temp, char operation)
        {
            //on regarde si temp n'est pas vide
            if(temp != "")
            {
                //on ajoute le contenue de currentNumber dans operation
                operations.AddLast(temp);
            }

            //on regarde si le charactère est une soustraction
            if (operation == '-')
            {
                //on assigne le signe - à currentNumber
                return "-";
            }

            //on ajoute l'opérateur ou la parenthèse à la liste opérations
            operations.AddLast(operation.ToString());
            //on assigne une valeur vide à currentNumber
            return "";
        }
    }
}