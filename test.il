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
	ldc.i4 15
	stloc x
	ldc.i4 8
	ldloc x
	bgt L0
	ldc.i4 0
	br L2
L0:
	ldc.i4 1
L1:
	ldc.i4 1
	beq L2
	ldloc x
	ldc.i4 1
	sub
	stloc x
	ldc.i4 8
	ldloc x
	bgt L0
	br L1
L2:
	ret
}

}

