using System.Text.Json;
using System.Text.RegularExpressions;

namespace ExerciceBonus
{
    class Program
    {
        private static readonly Regex sWhitespace = new Regex(@"\s+");

        public static void Main(string[] args)
        {
            //on déclare et initialise une variable opération qui contiendra ce que l'utilisateur taperas sous forme de tableau
            LinkedList<String> operations = new LinkedList<string>();

            //on boucle à l'infinie
            while (true)
            {
                //on demande à l'utilisateur d'entrée une opération
                Console.Write("Entrez une operation (type exit or quit to exit): ");

                //on enregistre ce que tape l'utilisateur dans une variable asked
                string asked = Console.ReadLine();

                //on s'assure que l'utilisateur n'as pas entrée une valeur null
                if (asked == null)
                {
                    //on affiche à l'utilisateur qu'il faut taper une opération
                    Console.WriteLine("Merci de taper une opération");

                    // on ferme le programme
                    return;
                }

                //on mets asked en minuscule pour éviter les problèmes de casse
                switch (asked.ToLower())
                {
                    case "exit" or "quit" or "e" or "q":
                        //si la variable asked contient exit, quit, e, q on ferme le programme
                        return;
                }

                //on affecte à asked sa valeur sans les charactère invisible
                asked = sWhitespace.Replace(asked, "");

                try
                {
                    //on verifie que l'opération est valide
                    IsValidOperation(asked, out operations);
                    Console.WriteLine(JsonSerializer.Serialize(operations));
                }
                //on attrape les erreur qui sont des opération invalide
                catch (InvalidOperationException e)
                {
                    //dis à la console d'écrire en rouge
                    Console.ForegroundColor = ConsoleColor.Red;
                    //écrit le message d'erreur dans la console
                    Console.WriteLine(e.Message);
                    //dis à la console d'écrire en blanc
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
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

        public static string AddToList(LinkedList<string> operations, string temp, char operation)
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

        public static void IsValidOperation(string operation, out LinkedList<string> operations)
        {
            //on initialise la variable operations
            operations = new LinkedList<string>();

            //on déclare et assigne une variable temporaire appeler currentNumber
            string currentNumber = "";

            //on boucle sur tous les charactère de la chaine contenue dans variable
            for (int i = 0; i < operation.Length; i++)
            {
                //on regarde si le charactère n'est pas un opérateur ou un charactère invisible
                if (!IsAnOperator(operation[i]) && !IsAPranthesis(operation[i]))
                {
                    //on mets dans asked le charactère qui n'est pas une opération ou une parenthèse
                    currentNumber += operation[i];

                    //on s'assure que le nombre est bien un nombre
                    if (!IsInteger(currentNumber))
                    {
                        //on lance une erreur
                        throw new InvalidOperationException($"L'opération ne peux pas contenir autre chose que des chiffres, des opérateur ou des parenthèse: {currentNumber}");
                    }

                    //on regarde si c'est la dernier boucle
                    if (i + 1 == operation.Length)
                    {
                        //on ajoute le numéro à la liste
                        operations.AddLast(currentNumber);
                    }

                    //on continue la boucle sans faire les instructions suivantes
                    continue;
                }

                //si currentNumber n'est pas vide et si currentNumber n'est pas un nombre entier
                if (currentNumber != "" && !IsInteger(currentNumber))
                {
                    //on lance une erreur
                    throw new InvalidOperationException($"L'opération ne peux pas contenir autre chose que des chiffres, des opérateur ou des parenthèse: {currentNumber}");
                }

                try
                {
                    //on regarde si l'utilisateur n'as pas taper deux fois un opérateur
                    if (IsAnOperator(operation[i - 1]) && IsAnOperator(operation[i]))
                    {
                        //on lance une erreur
                        throw new InvalidOperationException("Il ne peux pas y avoir deux fois un opérateur à la suite des autres");
                    }

                    //on regarde si le charactère précédent est une parenthèse et que l'opérateur est une multiplication ou une division
                    if (operation[i - 1] == '(' && IsDiviseOrMultiply(operation[i]))
                    {
                        //on lance une erreur
                        throw new InvalidOperationException("L'opérateur après une parenthèse ne peux être une multiplisation ou division");
                    }
                }
                catch (IndexOutOfRangeException) { }

                //on ajoute à la liste l'opérateur et le chiffre actuelle
                currentNumber = AddToList(operations, currentNumber, operation[i]);
            }
        }
    }
}