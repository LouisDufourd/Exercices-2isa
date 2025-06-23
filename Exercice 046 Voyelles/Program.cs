static void ShowArray(Array arr)
{
    Console.Write("[");
    for (int i = 0; i < arr.Length; i++)
    {
        Console.Write($"'{arr.GetValue(i)}'");

        if (i < arr.Length - 1)
        {
            Console.Write(", ");
        }
    }

    Console.WriteLine("]");
}

char[] voyelles = ['a', 'e', 'i', 'o', 'u', 'y'];

ShowArray(voyelles);