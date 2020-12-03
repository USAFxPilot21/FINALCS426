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
	ldc.i4 12
	stloc x
	ldc.i4 22
	ldloc x
	bge L0
	ldc.i4 0
	br L1
L0:
	ldc.i4 1
L1:
	ldc.i4 0
	beq L2
	ldc.i4 34
	stloc x
	br L3
L2:
L3:
	ldloc x
	ldc.i4 34
	beq L4
	ldc.i4 0
	br L5
L4:
	ldc.i4 1
L5:
	ldc.i4 1
	beq L6
	ldloc x
	ldc.i4 1
	add
	stloc x
	br L5
L6:
	ldc.i4 32
	ldloc x
	blt L8
	ldc.i4 0
	br L9
L8:
	ldc.i4 1
L9:
	ldc.i4 0
	beq L10
	ldc.i4 0
	stloc x
	br L11
L10:
L11:
	ret
}

}

