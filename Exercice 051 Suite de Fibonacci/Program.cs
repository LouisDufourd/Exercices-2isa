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

var fibonacci = new int[20];

fibonacci[0] = 0;
fibonacci[1] = 1;

for (int i = 2; i < fibonacci.Length; i++)
{
    fibonacci[i] = fibonacci[i - 1] + fibonacci[i - 2];
}

ShowArray(fibonacci);