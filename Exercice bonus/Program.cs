using System.Text.Json;
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
                string asked = Console.ReadLine();

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
                    string reversePolishNotation = ReversePolishNotation(asked);
                    IsValidOperation(reversePolishNotation);
                    Console.WriteLine("Opération valide");
                    Console.WriteLine(reversePolishNotation);
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
                //si le caaractère est + ou - ou * ou / on retourne true
                case '+' or '-' or '*' or '/': return true;
                //sinon on retourne false;
                default: return false;
            }
        }

        public static bool IsDiviseOrMultiply(char character)
        {
            //on retourne true si le charactère est * ou / sinon on retourne false
            return character == '*' || character == '/';
        }


        public static void IsValidOperation(string reversePolishNotation)
        {
            string[] rpn = reversePolishNotation.Split(" ");
            foreach(string item in rpn)
            {
                if(IsInteger(item))
                {
                    continue;
                }
                if(item.Length != 1)
                {
                    throw new InvalidOperationException($"L'item \"{item}\" n'est ni un nombre ni un opérateur");
                }
                if (!IsAnOperator(item[0]))
                {
                    throw new InvalidOperationException($"L'item \"{item}\" n'est pas une opération valide");
                }
            }
        }

        //reformat l'operation sous la forme du reverse parsing notation
        public static string ReversePolishNotation(string operation)
        {
            Stack<char> stack = new Stack<char>();
            string rpn = "";
            string number = "";

            //bool for parenthesis
            bool isParenthesisOpen = false;
            //bool for formating
            bool isFirstNumber = true;
            
            for (int i = 0; i < operation.Length; i++)
            {
                if (IsAnOperator(operation[i]))
                {
                    //the ifs here are just for formating
                    if(!isFirstNumber && number != "")
                    {
                        number = ' ' + number;
                    }

                    if (isFirstNumber && number != "")
                    {
                        isFirstNumber = false;
                    }

                    //add the number on the reverse polish notation
                    rpn += number;
                    //assign empty to number
                    number = "";

                    //check if it's an open parentesis
                    if (operation[i] == '(')
                    {
                        isParenthesisOpen = true;
                    }

                    do
                    {
                        //if the stack is empty we push the operator to the stack
                        if(stack.Count == 0)
                        {
                            stack.Push(operation[i]);
                            break;
                        }

                        //if the parenthesis is open we check if we see a close parentesis
                        if(isParenthesisOpen)
                        {
                            //if we do we empty the stack until the open prenthesis
                            //else if the previous one in the stack is an open parentesis we push in the stack
                            //else if the operator is prioritar then we push it to the stack
                            //else we pop the stack until we are at the open prenthesis then we push the operation in the stack
                            if (operation[i] == ')')
                            {
                                while(stack.Count > 0)
                                {
                                    if(stack.Peek() == '(')
                                    {
                                        stack.Pop();
                                    }
                                    else
                                    {
                                        rpn += " " + stack.Pop();
                                    }
                                }
                            }
                            else if(stack.Peek() == '(')
                                {
                                stack.Push(operation[i]);
                                break;
                            }
                            else if (PIMDAS(operation[i], stack.Peek()))
                            {
                                stack.Push(operation[i]);
                            }
                            else
                            {
                                while (stack.Peek() != '(')
                                {
                                    rpn += " " + stack.Pop();
                                }
                                stack.Push(operation[i]);
                            }
                            //we break out of the do while
                            break;
                        }

                        //if the operation as priority in we push it ot the stakc else we pop the operation of the stack util the stack is empty or if the operation has the priority
                        if (PIMDAS(operation[i], stack.Peek()))
                        {
                            stack.Push(operation[i]);
                            //we break out of the do while
                            break;
                        }
                        
                        rpn += " " + stack.Pop();
                    } while (stack.Count >= 0);
                }
                //to recreate the number on mulitple loop
                else
                {
                    number += operation[i];
                }
            }
            //add a space to the number for formating
            rpn += ' ' + number;
            //we empty the stack in the rpn
            while (stack.Count > 0)
            {
                rpn += " " + stack.Pop();
            }

            //we have now the reverse polish notation
            return rpn;
        }

        //si le premier opérateur est prioritaire on retourne vrai sinon faux
        public static bool PIMDAS(char firstOperator, char secondOperator)
        {
            switch(secondOperator)
            {
                case '(': return false;
                case '^': 
                    switch(firstOperator)
                    {
                        case '(': return true;
                        default: return false;
                    } 
                case '*': 
                    switch(firstOperator)
                    {
                        case '(' or '^' or '/': return true;
                        default: return false;
                    }
                case '/':
                    switch(firstOperator)
                    {
                        case '(' or '^' or '*': return true;
                        default: return false;
                    }
                case '+':
                    switch (firstOperator)
                    {
                        case '(' or '^' or '*' or '/' or '-': return true;
                        default: return false;
                    }
                default:
                    switch (firstOperator)
                    {
                        case '(' or '^' or '*' or '/' or '+': return true;
                        default: return false;
                    }
            }
        }
    }
}