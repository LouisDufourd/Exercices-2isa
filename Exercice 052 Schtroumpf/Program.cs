int[] firstArray = [4,8,7,12];
int[] secondArray = [3,6];
List<int> resultArray = new();

string operation = "";

for (int i = 0; i < secondArray.Length; i++)
{
    int firstNumber = secondArray[i];
    for (int j = 0; j < firstArray.Length; j++)
    {
        var secondNumber = firstArray[j];
        int factor = firstNumber * secondNumber;
        resultArray.Add(factor);

        operation += $"{firstNumber} * {secondNumber} = {factor}\n";
    }
}

while(resultArray.Count > 1)
{
    List<int> temp = [];
    for (int i = 0; i < resultArray.Count - 1; i += 2)
    {
        int result = resultArray[i] + resultArray[i + 1];

        temp.Add(result);

        operation += $"{resultArray[i]} + {resultArray[i + 1]} = {result}\n";
    }

    resultArray = temp;
} 

Console.Write(operation);