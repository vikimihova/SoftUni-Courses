int nthFibonacciPosition = int.Parse(Console.ReadLine());
int nthFibonacciNumber = GetFibonacci(nthFibonacciPosition);

Console.WriteLine(nthFibonacciNumber);

static int GetFibonacci(int n)
{
    if (n == 2 || n == 1)
    {
        return 1;
    }

    return GetFibonacci(n - 1) + GetFibonacci(n - 2);
}