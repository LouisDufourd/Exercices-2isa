static string ask(string question)
{
    string? answer = "";
    bool success = false;
    while(!success)
    {
        Console.Write(question);
        answer = Console.ReadLine();
        switch (answer?.ToLower())
        {
            case "oui" or "non":
                success = true;
                break;
            default:
                success = false;
                break;
        }
    }

    return answer!;
}

Console.WriteLine(ask("Es tu content ? "));