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
	ldc.i4 4
	ldc.i4 2
	sub
	stloc x
	.locals init(int32 y)
	ldc.i4 5
	ldc.i4 9
	mul
	stloc y
	ldloc y
	ldc.i4 12
	mul
	ldc.i4 4
	div
	stloc x
	.locals init(float32 z)
	ldc.i4 4
	ldc.i4 9
	add
	ldc.i4 12
	mul
	stloc z
	ldloc z
	ldc.i4 3
	div
	stloc z
	ret
}

}

