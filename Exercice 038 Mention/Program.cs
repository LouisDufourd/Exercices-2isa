static string Mention(uint note)
{
    string mention;
    if(note >= 16)
    {
        mention = "Très Bien";
    } 
    else if(note >= 14)
    {
        mention = "Bien";
    }
    else if (note >= 12)
    {
        mention = "Assez Bien";
    }
    else if (note >= 10)
    {
        mention = "Passable";
    }
    else
    {
        mention = "Echec";
    }
    return mention;
}

static bool AskUInt(string question, out uint number)
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

uint note = 0;

do { } while (!AskUInt("Rentrez la note: ", out note));

Console.WriteLine(Mention(note));