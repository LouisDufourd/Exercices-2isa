static bool isPrimeNumber(int number, out int divisable)
{
    divisable = -1;

    int sqrt = (int)Math.Round(Math.Sqrt(number));

    for (int i = 2; i <= sqrt; i++)
    {
        int reste = number % i;
        if (reste == 0)
        {
            divisable = i;
            break;
        }
    }

    return divisable == -1;
}

for (int i = 2; i <= 100; i++)
{
    if(isPrimeNumber(i, out int _))
    {
        Console.WriteLine(i);
    }
}