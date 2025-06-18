string Compress(string? input)
{
    if(input == null) return "";

    string compressed = "";
    char currentChar = (char)0;
    int quantity = 1;

    for (int i = 0; i < input.Length; i++)
    {
        if(currentChar != input[i]) 
        {
            compressed += (quantity > 1 ? $"{quantity}" : "") + currentChar;
            currentChar = input[i];
            quantity = 1;
            continue;
        }
        quantity++;
    }

    compressed += (quantity > 1 ? $"{quantity}" : "") + currentChar;

    return compressed;
}

Console.Write("Rentrez un chaine de charactère à compresser : ");
string? text = Console.ReadLine();
Console.WriteLine($"Version compressez: {Compress(text)}");