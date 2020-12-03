.assembly extern mscorlib {}
.assembly Test
{
	.ver 1:0:1:0
}
.class OuterClass
{
.method static void main() cil managed
{
	.maxstack 128
	.entrypoint
	.locals init(int32 x)
	.locals init(int32 y)
	.locals init(int32 z)
	.locals init(int32 w)
	ldc.i4 7
	stloc x
	ldc.i4 8
	stloc y
	ldc.i4 3
	stloc z
	ldc.i4 7
	ldc.i4 5
	add
	stloc w
	ldloc x
	ldloc y
	ldloc z
	mul
	add
	stloc w
	ldstr "ExpectedOutputIs"
	call void [mscorlib]System.Console::Write(string)
	ldstr "\n"
	call void [mscorlib]System.Console::Write(string)
	ldloc w
	call void [mscorlib]System.Console::Write(int32)
	ldstr "\n"
	call void [mscorlib]System.Console::Write(string)
	ldstr "OutputtingAFloat"
	call void [mscorlib]System.Console::Write(string)
	ldstr "\n"
	call void [mscorlib]System.Console::Write(string)
	ldstr "\n"
	call void [mscorlib]System.Console::Write(string)
	ldstr "EndOfTest"
	call void [mscorlib]System.Console::Write(string)
	ldstr "\n"
	call void [mscorlib]System.Console::Write(string)
	ret
}
}
