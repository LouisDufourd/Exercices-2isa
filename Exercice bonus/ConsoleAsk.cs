class ConsoleAsk
{
    public bool AskString(string question, out string chaine)
    {
        Console.Write(question);
        string? asked = Console.ReadLine();

        if (asked == null)
        {
            chaine = "";
            return false;
        }

        chaine = asked;
        return true;
    }

    public static bool AskUInt(string question, out uint number)
    {
        Console.Write(question);
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
        Console.Write(question);
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
        Console.Write(question);
        string? asked = Console.ReadLine();
        
        if (asked == null)
        {
            number = 0;
            return false;
        }

        asked = asked.Replace('.', ',');

        return double.TryParse(asked, out number);
    }

    public static bool AskFloat(string question, out float number)
    {
        Console.Write(question);
        string? asked = Console.ReadLine();
        if (asked == null)
        {
            number = 0;
            return false;
        }

        asked = asked.Replace('.', ',');

        return float.TryParse(asked, out number);
    }

    public bool AskLetter(string question, out char character)
    {
        Console.Write(question);
        ConsoleKeyInfo asked = Console.ReadKey();

        if (!char.IsAsciiLetter(asked.KeyChar))
        {
            character = (char) 0x0;
            return false;
        }

        character = asked.KeyChar;
        return true;
    }

    public static void ClearCurrentConsoleLine()
    {
        Console.SetCursorPosition(0, Console.CursorTop - 1);
        int currentLineCursor = Console.CursorTop;
        Console.SetCursorPosition(0, Console.CursorTop);
        Console.Write(new string(' ', Console.WindowWidth));
        Console.SetCursorPosition(0, currentLineCursor);
    }
}
