class ConsoleAsk
{
    public static bool AskUInt(string question, out uint number)
    {
        Console.WriteLine(question);
        string? asked = Console.ReadLine();
        if (asked == null)
        {
            number = 0;
            return false;
        }
        return uint.TryParse(asked, out number);
    }

    public static bool AskInt(string question, out int number)
    {
        Console.WriteLine(question);
        string? asked = Console.ReadLine();
        if (asked == null)
        {
            number = 0;
            return false;
        }
        return int.TryParse(asked, out number);
    }

    public static bool AskDouble(string question, out double number)
    {
        Console.WriteLine(question);
        string? asked = Console.ReadLine();
        if (asked == null)
        {
            number = 0;
            return false;
        }
        return double.TryParse(asked, out number);
    }

    public static bool AskFloat(string question, out float number)
    {
        Console.WriteLine(question);
        string? asked = Console.ReadLine();
        if (asked == null)
        {
            number = 0;
            return false;
        }
        return float.TryParse(asked, out number);
    }
}
