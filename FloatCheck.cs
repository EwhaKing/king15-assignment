using System;

class FloatCheck
{
    public static void PrintFloating()
    {
        Console.WriteLine("");
        Console.WriteLine("Floating point types:");
        //32bit
        Console.WriteLine($"float  : {float.MinValue} to {float.MaxValue} (with ~6-9 digits of precision)");
        //64bit
        Console.WriteLine($"double : {double.MinValue} to {double.MaxValue} (with ~15-17 digits of precision)");
        //128bit
        Console.WriteLine($"decimal: {decimal.MinValue} to {decimal.MaxValue} (with 28-29 digits of precision)");


    }
}

