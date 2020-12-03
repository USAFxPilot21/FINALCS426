.assembly output {}
.assembly extern mscorlib {}
.method static void Main()
{
     .entrypoint
     .maxstack 128
     ldc.i4 7
     .locals init (int32 x)
     stloc x 
     ldc.i4 8
     .locals init (int32 y)
     stloc y 
     ldc.i4 3
     .locals init (int32 z)
     stloc z 
     ldc.i4 7
     ldc.i4 5
     add
     .locals init (int32 w)
     stloc w
     ldloc x
     ldloc y
     add
     ldloc z
     mul
     stloc w
     ldloc w
     ldc.i4 7
     div
     stloc w
     ldstr "Test math equations:  expected output is 6"
     call void [mscorlib]System.Console::Write(string)
     ldstr ""
     call void [mscorlib]System.Console::WriteLine(string)
     ldloc w
     call void [mscorlib]System.Console::Write(int32)
     ldstr ""
     call void [mscorlib]System.Console::WriteLine(string)
     ldstr ""
     call void [mscorlib]System.Console::WriteLine(string)
     ldstr "Outputting a float 7.1"
     call void [mscorlib]System.Console::Write(string)
     ldstr ""
     call void [mscorlib]System.Console::WriteLine(string)
     ldc.r4 7.1
     call void [mscorlib]System.Console::Write(float32)
     ldstr ""
     call void [mscorlib]System.Console::WriteLine(string)
     ldstr ""
     call void [mscorlib]System.Console::WriteLine(string)
     ldstr "End of test"
     call void [mscorlib]System.Console::Write(string)
     ldstr ""
     call void [mscorlib]System.Console::WriteLine(string)
     ret
}
