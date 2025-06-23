static int[] SumOfTwoArray(int[] firstArray, int[] secondArray)
{
    if (firstArray.Length != secondArray.Length) throw new Exception("The two array need to be of same size");

    var result = new int[firstArray.Length];

    for (int i = 0; i < result.Length; i++)
    {
        result[i] = firstArray[i] + secondArray[i];
    }

    return result;
}

static void ShowArray(Array arr)
{
    Console.Write("[");
    for (int i = 0; i < arr.Length; i++)
    {
        var value = arr.GetValue(i);
        switch (Type.GetTypeCode(value.GetType()))
        {
            case TypeCode.Char:
                Console.Write("'");
                Console.Write($"{value}");
                Console.Write("'");
                break;
            case TypeCode.String:
                Console.Write("\"");
                Console.Write($"{value}");
                Console.Write("\"");
                break;
            default:
                Console.Write($"{value}".Replace(',', '.'));
                break;
        }

        if (i < arr.Length - 1)
        {
            Console.Write(", ");
        }
    }

    Console.WriteLine("]");
}

int[] firstArray = [4,8,7,9,1,5,4,6];
int[] secondArray = [7,6,5,2,1,3,7,4];

var result = SumOfTwoArray(firstArray, secondArray);

Console.Write("Premier tableau: ");
ShowArray(firstArray);
Console.Write("Deuxième tableau: ");
ShowArray(secondArray);
Console.Write("Somme des deux tableaux: ");
ShowArray(result);
