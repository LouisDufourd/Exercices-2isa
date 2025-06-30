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

int[] unSortedArray = new int[50];

Random rd = new();

for (int i = 0; i < unSortedArray.Length; i++)
{
    unSortedArray[i] = rd.Next(0, 101);
}

Console.Write("Liste non triée: ");
ShowArray(unSortedArray);

for (int i = 0; i < unSortedArray.Length; i++)
{
    for (int j = 0; j < unSortedArray.Length - 1; j++)
    {
        if (unSortedArray[i] < unSortedArray[j])
        {
            int temp = unSortedArray[i];
            unSortedArray[i] = unSortedArray[j];
            unSortedArray[j] = temp;
        }
    }
}

Console.Write("Liste triée: ");
ShowArray(unSortedArray);