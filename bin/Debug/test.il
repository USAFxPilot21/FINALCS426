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
	ldc.i4 5
	ldc.i4 5
	add
	stloc x
	ldstr "xIsLoadedWith"
	call void [mscorlib]System.Console::Write(string)
	ldloc x
	ldc.i4 6
	add
	call void [mscorlib]System.Console::Write(int32)
	ldstr "\n"
	call void [mscorlib]System.Console::Write(string)
	ldstr "yIsLoadedWith"
	call void [mscorlib]System.Console::Write(string)
	ret
}
}
