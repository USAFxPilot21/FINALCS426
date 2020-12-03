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
	ldc.i4 1
	stloc x
	ldc.i4 10
	ldloc x
	bgt L0
	ldc.i4 0
	br L1
L0:
	ldc.i4 1
L1:
	ldc.i4 1
	beq L2
	ldloc x
	ldc.i4 1
	add
	stloc x
	br L1
L2:
	ldloc x
	call void [mscorlib]System.Console::Write(int32)
	ldc.i4 10
	ldloc x
	bgt L4
	ldc.i4 0
	br L5
L4:
	ldc.i4 1
L5:
	ldc.i4 0
	beq L6
	ldloc x
	ldc.i4 4
	add
	stloc x
	br L7
L6:
	ldc.i4 3
	stloc x
L7:
	ret
}

}

