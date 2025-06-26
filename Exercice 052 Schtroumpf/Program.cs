int[] firstArray = [4,8,7,12];
int[] secondArray = [3,6];
int[] resultArray = new int[firstArray.Length *  secondArray.Length];

string operation = "";

int k = 0;

for (int i = 0; i < secondArray.Length; i++)
{
    int firstNumber = secondArray[i];
    
    for (int j = 0; j < firstArray.Length; j++)
    {
        int secondNumber = firstArray[j];
        int factor = firstNumber * secondNumber;
        resultArray[k] = factor;
        operation += $"{firstNumber} * {secondNumber} = {factor}\n";
        k++;
    }
}

while(resultArray.Length > 1)
{
    int[] temp = new int[resultArray.Length / 2];
    for (int i = 0; i < resultArray.Length - 1; i += 2)
    {
        int result = resultArray[i] + resultArray[i + 1];

        temp[i / 2] = result;

        operation += $"{resultArray[i]} + {resultArray[i + 1]} = {result}\n";
    }

    resultArray = new int[temp.Length];
    resultArray = temp;
} 

Console.Write(operation);