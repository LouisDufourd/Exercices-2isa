string Compress(string? input)
{
    if(input == null) return "";
    string compressed = "";
    Dictionary<char, int> characters = new Dictionary<char, int>();

    for(int i = 0; i < input.Length; i++)
    {
        if (characters.TryGetValue(input[i], out int value))
        {
            characters[input[i]] = ++value;
        } else
        {
            characters.Add(input[i], 1);
        }
    }

    foreach (var item in characters)
    {
        if(item.Value > 1)
        {
            compressed += $"{item.Value}{item.Key}";
        } 
        else
        {
            compressed += item.Key;
        }
    }

    return compressed;
}

Console.Write("Rentrez un chaine de charactère à compresser : ");
string? text = Console.ReadLine();
Console.WriteLine($"Version compressez: {Compress(text)}");