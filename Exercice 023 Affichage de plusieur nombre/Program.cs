using System.Collections;
using System.Collections.Generic;

static void printRangeNumberWhile(int start, int stop, int pas = 1)
{
    Console.WriteLine("While :");
    while (start <= stop)
    {
        Console.WriteLine(start);
        start += pas;
    }
}

static void printRangeNumberDoWhile(int start, int stop, int pas = 1)
{
    Console.WriteLine("Do ... While :");
    do
    {
        Console.WriteLine(start);
        start += pas;
    } while (start <= stop);
}

static void printRangeNumberFor(int start, int stop, int pas = 1)
{
    Console.WriteLine("For :");
    for (;start<=stop; start += pas)
    {
        Console.WriteLine(start);
    }
    Console.WriteLine();
}

Console.WriteLine("Affichage de tous les nombres de 1 à 20 :");
Console.WriteLine();

printRangeNumberWhile(1,20);
printRangeNumberDoWhile(1,20);
printRangeNumberFor(1,20); 
Console.WriteLine("Affichage de tous les nombres de 5 à 25 :");
Console.WriteLine();
printRangeNumberWhile(5, 25, 2);
printRangeNumberDoWhile(5, 25, 2);
printRangeNumberFor(5, 25, 2);
Console.WriteLine("Affichage de tous les nombres de 0 à -20 :");
Console.WriteLine();
int index = 0;
Console.WriteLine("While :");
while (index >= -20)
{
    Console.WriteLine(index);
    index--;
}
Console.WriteLine();
index = 0; 
Console.WriteLine("Do ... While :");
do
{
    Console.WriteLine(index);
    index--;
} while (index >= -20);
Console.WriteLine();
index = 0;
Console.WriteLine("For :");
for (; index >= -20; index--)
{
    Console.WriteLine(index);
}
Console.WriteLine();