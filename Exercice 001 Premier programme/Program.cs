Console.WriteLine("Bonjour");

int Divise(int a, int b, out int remainder)
{
    remainder = a % b;
    return a / b;
}