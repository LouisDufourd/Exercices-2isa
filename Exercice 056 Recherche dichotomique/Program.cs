static void ClearCurrentConsoleLine()
{
    Console.SetCursorPosition(0, Console.CursorTop - 1);
    int currentLineCursor = Console.CursorTop;
    Console.SetCursorPosition(0, Console.CursorTop);
    Console.Write(new string(' ', Console.WindowWidth));
    Console.SetCursorPosition(0, currentLineCursor);
}

static bool AskInt(string question, out int number)
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

int[] numbers = [-6, -2, 4, 7, 22, 76, 123, 456, 789, 1032];
int min = 0;
int max = numbers.Length;
int numberToFind;
bool isFound = false, isThereAnError = false;

while (!AskInt("Tapez un nombre à trouvez dans le tableau: ", out numberToFind))
{
    isThereAnError = true;
    ClearCurrentConsoleLine();
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("Veuillez entrez un nombre entier");
    Console.ForegroundColor = ConsoleColor.White;
}

ClearCurrentConsoleLine();
if (isThereAnError) ClearCurrentConsoleLine();

int resultIndex = -1;
int previousMin = -1;
int previousMax = -1;

while (min != max && !isFound && previousMin != min && previousMax != max)
{
    int choosedIndex = min + (min + max) / 2;

    int choosedNumber = numbers[choosedIndex];

    if (choosedNumber < numberToFind)
    {
        previousMin = min;
        min = choosedIndex;
    }
    else if (choosedNumber > numberToFind)
    {
        previousMax = max;
        max = choosedIndex;
    }

    isFound = choosedNumber == numberToFind;

    if (isFound) resultIndex = choosedIndex;
}

Console.WriteLine(resultIndex == -1 ?
    $"Le nombre {numberToFind} n'a pas été trouvé dans le tableau" :
    $"Le nombre {numberToFind} a été trouvé à l'index {resultIndex}");