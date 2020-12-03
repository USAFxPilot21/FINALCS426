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
	ldc.i4 132
	stloc x
	.locals init(int32 y)
	ldc.i4 2
	stloc y
	ldloc x
	ldc.i4 132
	beq L0
	ldc.i4 0
	br L1
	ldloc y
	ldc.i4 2
	beq L1
	ldc.i4 0
	br L2
L1:
	ldc.i4 1
L2:
	ldc.i4 0
	beq L3
	ldc.i4 4
	stloc x
	ldc.i4 5
	stloc y
	br L4
L3:
L4:
	ldloc x
	call void [mscorlib]System.Console::Write(int32)
	ldloc y
	call void [mscorlib]System.Console::Write(int32)
	ldc.i4 1
	ldloc x
	blt L5
	ldc.i4 0
	br L6
	ldc.i4 122
	ldloc y
	blt L6
	ldc.i4 0
	br L7
L6:
	ldc.i4 1
L7:
	ldc.i4 0
	beq L8
	ldc.i4 12
	stloc x
	ldc.i4 32
	stloc y
	br L9
L8:
L9:
	ldc.i4 3
	ldloc x
	blt L10
	ldc.i4 0
	br L11
L10:
	ldc.i4 1
L11:
	ldc.i4 0
	beq L12
	ldc.i4 32
	stloc x
	br L13
L12:
L13:
	ret
}

}

