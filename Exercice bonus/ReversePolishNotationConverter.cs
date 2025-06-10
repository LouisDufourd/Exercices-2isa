

using System.Data;

namespace Exercice_bonus
{
    public class ReversePolishNotationConverter
    {
        //reformat l'operation sous la forme du reverse parsing notation
        public static string ReversePolishNotation(string operation)
        {
            Stack<char> stack = new Stack<char>();
            string rpn = "";
            string number = "";

            //bool for parenthesis
            int numberOfParenthesisOpen = 0;
            //bool for formating
            bool isFirstNumber = true;

            for (int i = 0; i < operation.Length; i++)
            {
                //current selected char
                char currentChar = operation[i];
                //currentOperator
                char currentOperator;
                //is the stack empty
                bool isStackEmpty = stack.TryPeek(out currentOperator);
                
                //if the PEMDAS is less than 0 then it's not an operator and we assume it's a number
                if(PEMDAS(currentChar) < 0)
                {
                    number += currentChar;
                    continue;
                }

                rpn = AddToRPN(rpn, number);
                if(number != "")
                {
                    rpn = AddToRPN(rpn, " ");
                }
                number = "";
                rpn = AddToRPN(rpn, AddToStack(stack, currentChar));
            }

            if(number != "")
            {
                rpn = AddToRPN(rpn, number);
                rpn += " ";
            }

            rpn = AddToRPN(rpn, emptyStack(stack, -1));

            //we have now the reverse polish notation
            return rpn;
        }

        public static int PEMDAS(char current_operator)
        {
            switch (current_operator)
            {
                case '(' or ')':
                    return 4;
                case '^':
                    return 3;
                case '*' or '/' or '%':
                    return 2;
                case '+' or '-':
                    return 1;
                default:
                    return -1;
            }
        }

        private static string AddToRPN(string rpn, string toAdd)
        {
            rpn += toAdd;
            return rpn;
        }

        private static string AddToRPN(string rpn, char toAdd)
        {
            return AddToRPN(rpn, $"{toAdd}");
        }

        private static string AddToStack(Stack<char> stack, char toAdd)
        {
            string removedCharacters = "";

            char currentOperator;

            bool isNotEmpty = stack.TryPeek(out currentOperator);

            int toAddPemdas;
            int currentOperatorPemdas;

            if(!isNotEmpty)
            {
                stack.Push(toAdd);
                return removedCharacters;
            }

            toAddPemdas = PEMDAS(toAdd);
            currentOperatorPemdas = PEMDAS(stack.Peek());

            if (toAddPemdas < currentOperatorPemdas)
            {
                removedCharacters = emptyStack(stack, toAddPemdas);
            }
            else if (toAddPemdas == currentOperatorPemdas)
            {
                if(toAdd != '^')
                {
                    removedCharacters = emptyStack(stack, toAddPemdas);
                }
            }
            else if (toAdd == ')')
            {
                removedCharacters = emptyStack(stack, -1);
                stack.Pop();
                return removedCharacters;
            }

            stack.Push(toAdd);

            return removedCharacters;
        }
        
        private static string emptyStack(Stack<char> stack, int toAddPemdas)
        {
            string removedCharacters = "";

            char currentOperator;

            bool isNotEmpty = stack.TryPeek(out currentOperator);

            int currentOperatorPemdas = PEMDAS(currentOperator);

            while (isNotEmpty)
            {
                isNotEmpty = stack.TryPeek(out currentOperator);

                currentOperatorPemdas = PEMDAS(currentOperator);

                if (!isNotEmpty) break;
                if (currentOperator == '(') break;
                if (toAddPemdas > currentOperatorPemdas) break;

                removedCharacters = AddToRPN(removedCharacters, stack.Pop());
                removedCharacters += " ";
            }

            return removedCharacters;
        }

        public static string Solve(string reversePolishNotation)
        {
            string result = "";
            string[] rpn = reversePolishNotation.Split(' ');
            Stack<string> operands = new Stack<string>();
            foreach(string item in rpn)
            {
                if(!Utils.IsAnOperator(item))
                {
                    operands.Push(item);
                    continue;
                }

                if (operands.Count == 1)
                {
                    string temp = operands.Pop();
                    switch (item)
                    {
                        case "^" or "*" or "/" or "%":
                            operands.Push("1");
                            operands.Push(temp);
                            break;
                        case "+" or "-":
                            operands.Push("0");
                            operands.Push(temp);
                            break;
                    }
                }

                if (operands.Count < 2)
                {
                    throw new InvalidOperationException($"Il n'y a pas assez d'opérande pour faire un calcul");
                }

                string first = operands.Pop();
                string second = operands.Pop();
                result = Operate(first, second, item);
                operands.Push(result);

                Console.WriteLine($"{second} {item} {first} = {result}");
            }

            return result;
        }

        public static string Operate(string firstNumber, string secondNumber, string op)
        {
            string result = "";

            if(!Utils.IsNumber(firstNumber))
            {
                throw new InvalidOperationException($"The number {firstNumber} is not a valid number");
            }

            if (!Utils.IsNumber(firstNumber))
            {
                throw new InvalidOperationException($"The number {secondNumber} is not a valid number");
            }

            double intFirstNumber = double.Parse(firstNumber);
            double intSecondNumber = double.Parse(secondNumber);

            switch(op)
            {
                case "+":
                    result = $"{intSecondNumber + intFirstNumber}";
                    break;
                case "-":
                    result = $"{intSecondNumber - intFirstNumber}";
                    break;
                case "*":
                    result = $"{intSecondNumber * intFirstNumber}";
                    break;
                case "/":
                    result = $"{intSecondNumber / intFirstNumber}";
                    break;
                case "%":
                    result = $"{intSecondNumber % intFirstNumber}";
                    break;
                case "^":
                    result = $"{Math.Pow(intSecondNumber, intFirstNumber)}";
                    break;
            }

            return result;
        }
    }
}
