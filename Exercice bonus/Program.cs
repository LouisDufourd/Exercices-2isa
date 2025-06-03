using System.ComponentModel;
using System.Text;
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

            //on déclare et assigne une variable temporaire appeler temp
            string temp = "";

            //on boucle sur tous les charactère de la chaine contenue dans variable
            for (int i = 0; i < asked.Length;  i++)
            {
                //on regarde si le charactère est un opérateur ou un charactère invisible
                if (IsAnOperator(asked[i]) || IsAPranthesis(asked[i]))
                {
                    //si temp n'est pas vide et si temp n'est pas un nombre entier
                    if (temp != "" && !IsInteger(temp))
                    {
                        // on ferme le programme
                        return;
                    }

                    //on ajoute le contenue de temp dans operation
                    operations.AddLast(temp);

                    //on regarde si i est supérieur à 0
                    if (i > 0)
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

                    //on assigne à temp une valeur vide
                    temp = "";

                    if (asked[i] == '-')
                    {
                        temp += "-";
                    } else
                    {
                        //on ajoute l'opérateur / la parenthèse à la liste opérations
                        operations.AddLast(asked[i].ToString());
                    }

                    //on continue la boucle sans finir les instruction
                    continue;
                }

                //on mets dans asked le charactère qui n'est pas une opération ou une parenthèse
                temp += asked[i];
            }

            //si temp n'est pas vide on mets dans opération sa valeur
            if(temp != "")
            {
                if(!IsInteger(temp))
                {
                    //on ferme le program
                    return;
                }
                operations.AddLast(temp);
            }

            Console.WriteLine(JsonSerializer.Serialize(operations));
        }

        public static bool IsAPranthesis(char character)
        {
            if (character == '(' || character == ')') return true;
            return false;
        }

        /**
         * <param  name="value">La chaine de charactère à verifier</param>
         * <returns>Si la chaine est un entier ou non</returns>
         **/
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
    }
}