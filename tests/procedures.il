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
	ldc.i4 14
	stloc x
	ldc.i4 25
	stloc y
	ldloc x
	call void [mscorlib]System.Console::Write(int32)
	call void functioncall()
	ret
}

}

.method static void functioncall() cil managed
{
	ldstr "Hello World"
	call void print()
	ret
}
