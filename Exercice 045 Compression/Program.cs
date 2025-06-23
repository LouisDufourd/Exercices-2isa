string Compress(string? input)
{
    if(input == null) return "";

    string compressed = "";
    char currentChar = (char)0;
    int quantity = 1;

    foreach (var character in input)
    {
        if (currentChar != character)
        {
            compressed += (quantity > 1 ? $"{quantity}" : "") + currentChar;
            currentChar = character;
            quantity = 1;
        }
        else quantity++;
    }

    compressed += (quantity > 1 ? $"{quantity}" : "") + currentChar;

    return compressed;
}

Console.Write("Rentrez un chaine de charactère à compresser : ");
string? text = Console.ReadLine();
Console.WriteLine($"Version compressez: {Compress(text)}");