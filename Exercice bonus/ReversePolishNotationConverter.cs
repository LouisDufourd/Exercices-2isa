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
                char currentChar = operation[i];
                if (Utils.IsAnOperator(currentChar) || Utils.IsAPranthesis(currentChar))
                {
                    //the ifs here are just for formating
                    if (!isFirstNumber && number != "")
                    {
                        number = " " + number;
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
                    if (currentChar == '(')
                    {
                        numberOfParenthesisOpen++;
                    }
                    //if the stack is empty we push the operator to the stack
                    if (stack.Count == 0)
                    {
                        stack.Push(operation[i]);
                        continue;
                    }

                    //if the parenthesis is open we check if we see a close parentesis
                    if (numberOfParenthesisOpen > 0)
                    {
                        //if we see a close prentesis we empty the stack until the open prenthesis
                        if (currentChar == ')')
                        {
                            bool breakFlag = false;
                            while(!breakFlag)
                            {
                                if(stack.Peek() == '(')
                                {
                                    stack.Pop();
                                    breakFlag = true;
                                    continue;
                                }

                                rpn += " " + stack.Peek();
                                numberOfParenthesisOpen--;
                            }
                        }
                        //else if the previous one in the stack is an open parentesis we push in the stack
                        //else if the operator as a higher priority than the one in the stack we push it in the stack
                        else if (PIMDAS(currentChar) > PIMDAS(stack.Peek()))
                        {
                            stack.Push(currentChar);
                        }
                        //else if the operator as a lower priority we pop the stack until we are at the open prenthesis then we push the operator in the stack
                        else if (PIMDAS(currentChar) < PIMDAS(stack.Peek()))
                        {
                            while(PIMDAS(currentChar) < PIMDAS(stack.Peek()))
                            {
                                rpn += " " + stack.Pop();
                            }
                            stack.Push(currentChar);
                        }
                        //else the operator as the same priority than the one in the stack so the one in the stack is priority
                        else
                        {
                            while (PIMDAS(currentChar) == PIMDAS(stack.Peek()) && (currentChar != '*' || currentChar != '+'))
                            {
                                rpn += " " + stack.Pop();
                            }
                            stack.Push(currentChar);
                        }
                    }
                    else {
                        //si la stack est vide
                        if(stack.Count == 0)
                        {
                            //on push l'operateur dans la stack
                            stack.Push(currentChar);
                        }
                        //else if the operator has an higher priority than the previous one
                        else if (PIMDAS(currentChar) > PIMDAS(stack.Peek()))
                        {
                            //we push it in the stack
                            stack.Push(currentChar);
                        }
                        //else if the operator as a lower priority we pop the stack until we are at the open prenthesis then we push the operator in the stack
                        else if (PIMDAS(currentChar) < PIMDAS(stack.Peek()))
                        {
                            while (stack.TryPeek(out char op) || currentChar < PIMDAS(op))
                            {
                                rpn += " " + stack.Pop();
                            }
                            stack.Push(currentChar);
                        }
                        //else the operator as the same priority than the one in the stack so the one in the stack is priority
                        else
                        {
                            while (stack.TryPeek(out char op) || currentChar == PIMDAS(op))
                            {
                                rpn += " " + stack.Pop();
                            }
                            stack.Push(currentChar);
                        }
                    }
                }
                //to recreate the number on mulitple loop
                else
                {
                    number += currentChar;
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

        public static int PIMDAS(char current_operator)
        {
            switch (current_operator)
            {
                case '(' or ')':
                    return 0;
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
    }
}
