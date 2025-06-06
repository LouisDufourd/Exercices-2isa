using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Exercice_bonus
{
    class Utils
    {
        /**
         * La première section du regex s'assure que la presence d'un signe soit quand même un match "(-|\+)?" on dit si il y a - ou + 0 ou 1 fois
         * La deuxième partie correspond à la partie entier "[0-9]+" ici on dit que si la chaine à un charactère entre 0 et 9 et que ce charactère peut se répéte 1 ou plusieure fois
         * ça ne matcheras pas si il n'y a pas de chiffre
         * La troisième partie est pour la partie décimal du nombre "((\,|.)[0-9]+)?" ici on dit que si il y a un . ou une , on attent un ou plusieur charactère entre 0 et 9
         * ensuit on dit que ça peux exister 0 ou 1 fois (ex : .89 match avec cette dernier partie, .89.9 ne match pas avec cette dernier partie)
         **/
        private static readonly Regex isNumberRegex = new Regex("(-|\\+)?[0-9]+((\\,|.)[0-9]+)?");

        public static bool IsAPranthesis(char character)
        {
            return character == '(' || character == ')';
        }

        public static bool IsNumber(string value) => isNumberRegex.IsMatch(value);

        public static bool IsAnOperator(char character)
        {
            switch (character)
            {
                //si le caaractère est + ou - ou * ou / on retourne true
                case '+' or '-' or '*' or '/' or '%' or '^': return true;
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
            foreach (string item in rpn)
            {
                if (IsNumber(item))
                {
                    continue;
                }
                if (item.Length != 1)
                {
                    throw new InvalidOperationException($"L'item \"{item}\" n'est ni un nombre ni un opérateur");
                }
                if (!IsAnOperator(item[0]))
                {
                    throw new InvalidOperationException($"L'item \"{item}\" n'est pas une opération valide");
                }
            }
        }

        public static void GetOperandAndOperator(string reversePolishNotaion, out List<string> operands, out List<char> operators)
        {
            operands = new List<string>();
            operators = new List<char>();
            string[] rpn = reversePolishNotaion.Split(" ");

            foreach (var item in rpn)
            {
                if (Utils.IsNumber(item))
                {
                    operands.Add(item);
                }
                else if (item.Length == 1)
                {
                    operators.Add(item[0]);
                }
            }
        }
    }
}
