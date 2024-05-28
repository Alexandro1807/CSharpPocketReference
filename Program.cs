using System;
Console.WriteLine(MultiplyBy12(30));

int MultiplyBy12(int mult)
{
    return mult * 12;
}

static int Factorial(int x)
{
    if (x == 0) return 1;
    return x * Factorial(x);
}










//Пауза перед завершением консоли
Thread.Sleep(3 * 1000);