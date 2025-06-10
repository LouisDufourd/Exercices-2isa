

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

        internal static int Solve(string reversePolishNotation)
        {
            throw new NotImplementedException();
        }
    }
}
