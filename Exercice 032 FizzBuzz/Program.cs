for (int i = 1; i <= 100; i++)
{
    bool divisableBy3 = i % 3 == 0;
    bool divisableBy5 = i % 5 == 0;
    if (divisableBy3)
    {
        Console.Write("Fizz");
    }
    
    if (divisableBy5)
    {
        Console.Write("Buzz");
    }
    
    if(!divisableBy3 && ! divisableBy5)
    {
        Console.Write(i);
    }
    Console.WriteLine();
}