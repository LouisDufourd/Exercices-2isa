string GetInverse(string text)
{
    string inverse = "";
    for (int i = text.Length-1; i >= 0; i--)
    {
        inverse += text[i];
    }

    return inverse;
}

bool IsPlaindrome(string text)
{
    return string.Equals(text, GetInverse(text), StringComparison.OrdinalIgnoreCase);
}

Console.WriteLine($"WINDOWS : {IsPlaindrome("windows")}");
Console.WriteLine($"KAYAK : {IsPlaindrome("kayak")}");