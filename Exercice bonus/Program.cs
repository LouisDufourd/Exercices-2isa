using Exercice_bonus;
using System.Text.RegularExpressions;

namespace ExerciceBonus
{
    class Program
    {
        private static readonly Regex sWhitespace = new Regex(@"\s+");

        public static void Main(string[] args)
        {
            //on crée un falg pour sortir de la boucle quand le programme est terminer
            bool breakFlag = false;

            //on boucle à l'infinie
            while (!breakFlag)
            {
                //on demande à l'utilisateur d'entrée une opération
                Console.Write("Entrez une operation (type exit or quit to exit): ");

                //on enregistre ce que tape l'utilisateur dans une variable asked
                string? asked = Console.ReadLine();

                //on s'assure que l'utilisateur n'as pas entrée une valeur null
                if (asked == null)
                {
                    //on affiche à l'utilisateur qu'il faut taper une opération
                    Console.WriteLine("Merci de taper une opération");

                    // on sort de la boucle
                    breakFlag = true;
                    continue;
                }

                //on mets asked en minuscule pour éviter les problèmes de casse
                switch (asked.ToLower())
                {
                    case "exit" or "quit" or "e" or "q":
                        //si la variable asked contient exit, quit, e, q on sort de la boucle
                        breakFlag = true;
                        continue;
                }

                //on affecte à asked sa valeur sans les charactère invisible
                asked = sWhitespace.Replace(asked, "");

                try
                {
                    //on verifie que l'opération est valide
                    string reversePolishNotation = ReversePolishNotationConverter.ReversePolishNotation(asked);
                    //Console.WriteLine(reversePolishNotation);
                    string result = ReversePolishNotationConverter.Solve(reversePolishNotation);
                    Console.WriteLine(result);
                }
                //on attrape les erreur qui sont des opération invalide
                catch (Exception e)
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

        public static string Analyse(string reversePolishNotation)
        {
            string analyse = "";
            string[] rpn = reversePolishNotation.Split(" ");
            List<string> operands;
            List<char> operators;

            Utils.GetOperandAndOperator(reversePolishNotation, out operands, out operators);

            for (int i = 0; i < operands.Count; i++)
            {
                if (operands.Count > i + 1)
                {
                    string firstNumber = operands[i];
                    string secondNumber = operands[i + 1];
                    char currentOperator = operators[0];
                    operators.RemoveAt(0);

                    if (i == 0)
                    {
                        switch (currentOperator)
                        {
                            case '+':
                                analyse += $"On addition {firstNumber} par {secondNumber}";
                                break;
                            case '-':
                                analyse += $"On soustrait {firstNumber} par {secondNumber}";
                                break;
                            case '/':
                                analyse += $"On divise {firstNumber} par {secondNumber}";
                                break;
                            case '*':
                                analyse += $"On multiplie {firstNumber} par {secondNumber}";
                                break;
                        }
                        i++;
                    }
                    else
                    {
                        switch (currentOperator)
                        {
                            case '+':
                                analyse += $"Puis on addition par {firstNumber}";
                                break;
                            case '-':
                                analyse += $"Puis on soustrait par {firstNumber}";
                                break;
                            case '/':
                                analyse += $"Puis on divise par {firstNumber}";
                                break;
                            case '*':
                                analyse += $"Puis on multiplie par {firstNumber}";
                                break;
                        }
                    }
                    analyse += "\n";
                    continue;
                }
                else
                {
                    string firstNumber = operands[i];
                    char currentOperator = operators[0];
                    switch (currentOperator)
                    {
                        case '+':
                            analyse += $"Puis on addition par {firstNumber}";
                            break;
                        case '-':
                            analyse += $"Puis on soustrait par {firstNumber}";
                            break;
                        case '/':
                            analyse += $"Puis on divise par {firstNumber}";
                            break;
                        case '*':
                            analyse += $"Puis on multiplie par {firstNumber}";
                            break;
                    }
                }
            }
            return analyse;
        }
    }
}