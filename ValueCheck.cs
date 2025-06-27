//Output: min and MAX of integral types
Console.WriteLine("Signed integral types:");

//Signed 8bit integral
Console.WriteLine($"sbyte  : {sbyte.MinValue} to {sbyte.MaxValue}");
//Signed 16bit integral
Console.WriteLine($"short  : {short.MinValue} to {short.MaxValue}");
//Signed 32bit integral
Console.WriteLine($"int    : {int.MinValue} to {int.MaxValue}");
//Signed 64bit integral
Console.WriteLine($"long   : {long.MinValue} to {long.MaxValue}");

Console.WriteLine("");
Console.WriteLine("Unsigned integral types:");

//Unsigned 8bit integral
//Especially byte represents data's byte value
//Needed: data incoding and decoding
Console.WriteLine($"byte   : {byte.MinValue} to {byte.MaxValue}");
//Unsigned 16bit integral
Console.WriteLine($"ushort : {ushort.MinValue} to {ushort.MaxValue}");
//Unsigned 32bit integral
Console.WriteLine($"uint   : {uint.MinValue} to {uint.MaxValue}");
//Unsigned 64bit integral
Console.WriteLine($"ulong  : {ulong.MinValue} to {ulong.MaxValue}");

FloatCheck.PrintFloating();
VariableDef.PrintDefining();