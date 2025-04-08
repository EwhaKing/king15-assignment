using System;

class VariableDef
{
    public static void PrintDefining()
    {
        //Define storage variable: data here is null ref
        //Make instance of int ary: new here adjusts size of ary
        //Reduce the final representation
        int[] data = new int[3];

        //val type(int)
        int val_A = 2;
        int val_B = val_A;
        val_B = 5;

        Console.WriteLine("");
        Console.WriteLine("--Value Types--");
        Console.WriteLine($"val_A: {val_A}");
        Console.WriteLine($"val_B: {val_B}");

        //ref type(ary)
        int[] ref_A= new int[1];
        ref_A[0] = 2;
        int[] ref_B = ref_A;
        ref_B[0] = 5;

        Console.WriteLine("");
        Console.WriteLine("--Reference Types--");
        Console.WriteLine($"ref_A[0]: {ref_A[0]}");
        Console.WriteLine($"ref_B[0]: {ref_B[0]}");

        //Basic data union
        //int: most integral
        //decimal: financial number
        //bool: true or false
        //string: char ary

        //Complex data union
        //byte: incoded data or char union
        //double: geometrical use
        //System.DateTime: specific time or date
        //System.Timespan: time gap or amount



    }
}
