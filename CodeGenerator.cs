using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using CS426.node;

namespace CS426.analysis
{
    class Globals
    {
        // global int
        public static int counter = -1;
        public static int ifCode = -100;
        public static int elseCode = -100;
        public static int contCode = -100;
 
    }

        class CodeGenerator : DepthFirstAdapter
    {
        StreamWriter _output; //change to stream

        public CodeGenerator(StreamWriter fileio) //change to stream
        {
            _output = fileio;
        }

        // int x;  ---->  .locals init (int32, x)
        public override void OutADeclarestmt(ADeclarestmt node)
        {
            if (node.GetTypename().Text.Equals("string"))
            {
                _output.Write("\t.locals init(");
                _output.WriteLine(node.GetTypename().Text + " " + node.GetVarname().Text + ")");
            }
            else
            {
                _output.Write("\t.locals init(");
                _output.WriteLine(node.GetTypename().Text + "32 " + node.GetVarname().Text + ")");
            }

        }


        //.assembly extern mscorlib {}
        //.assembly Add
        //{
        //  .ver 1:0:1:0
        //}
        //.class OuterClass
        //.method static void main() cil managed
        public override void InAProg(AProg node)
        {
            _output.WriteLine(".assembly extern mscorlib {}");
            _output.WriteLine(".assembly Test");
            _output.WriteLine("{");
            _output.WriteLine("\t.ver 1:0:1:0");
            _output.WriteLine("}");
            _output.WriteLine(".class OuterClass");
            _output.WriteLine("{");
            _output.WriteLine(".method static void main() cil managed");
            _output.WriteLine("{");
            _output.WriteLine("\t.maxstack 128");
            _output.WriteLine("\t.entrypoint");
        }

        //  ret
        //}
        public override void OutAProg(AProg node)
        {
            _output.Close();
        }

        public override void CaseAProg(AProg node)
        {
            InAProg(node);
            if (node.GetMainmethod() != null)
            {
                node.GetMainmethod().Apply(this);
            }
            {
                Object[] temp = new Object[node.GetFunctionDeclarations().Count];
                node.GetFunctionDeclarations().CopyTo(temp, 0);
                for (int i = temp.Length - 1; i >= 0; i--)
                {
                    ((PFunctionDeclarations)temp[i]).Apply(this);
    
                }
            }
            {
                Object[] temp = new Object[node.GetConstantDeclarations().Count];
                node.GetConstantDeclarations().CopyTo(temp, 0);
                for (int i = temp.Length - 1; i >= 0; i--)
                {
                    ((PConstantDeclarations)temp[i]).Apply(this);
                }
            }
            OutAProg(node);
        }

        public override void CaseAMainmethod(AMainmethod node)
        {
            InAMainmethod(node);
            if (node.GetMain() != null)
            {
                node.GetMain().Apply(this);
            }
            if (node.GetLparen() != null)
            {
                node.GetLparen().Apply(this);
            }
            if (node.GetStmts() != null)
            {
                node.GetStmts().Apply(this);
            }
            _output.WriteLine("\tret");
            _output.WriteLine("}\n");
            _output.WriteLine("}\n");

            if (node.GetRparen() != null)
            {
                node.GetRparen().Apply(this);
            }
            OutAMainmethod(node);
        }

        // x = 34; -----> ldc.i4 34
        public override void OutAIntOperand(AIntOperand node)
        {
            _output.WriteLine("\tldc.i4 " + node.GetInteger().Text);
        }

        public override void OutAFloatOperand(AFloatOperand node)
        {
            _output.WriteLine("\tldc.r4 " + node.GetFloat().Text);
        }

        public override void OutAVariableOperand(AVariableOperand node)
        {
            _output.WriteLine("\tldloc " + node.GetId().Text);
        }

        public override void OutAStringOperand(AStringOperand node)
        {
            _output.WriteLine("\tldstr " + node.GetString().Text);
        }

        // x = 5;
        public override void OutAAssignstmt(AAssignstmt node)
        {
            _output.WriteLine("\tstloc " + node.GetId().Text);
        }

        // PrintInt(9); PrintFloat(3.4); Print("hello world"); NewLine();
        public override void OutAFunctioncall(AFunctioncall node)
        {
            if(node.GetId().Text.Equals("PrintInt"))
            {
                _output.WriteLine("\tcall void [mscorlib]System.Console::Write(int32)");
            }
            else if(node.GetId().Text.Equals("PrintFloat"))
            {
                _output.WriteLine("\tcall void [mscorlib]System.Console::Write(float32)");
            }
            else if (node.GetId().Text.Equals("Print"))
            {
                _output.WriteLine("\tcall void [mscorlib]System.Console::Write(string)");
            }
            else if (node.GetId().Text.Equals("NewLine"))
            {
                _output.WriteLine("\tldstr \"\\n\"");
                _output.WriteLine("\tcall void [mscorlib]System.Console::Write(string)");
            }
            else
            {
                _output.WriteLine("\tcall void " + node.GetId().Text + "()");
            }

        }

        // x + 5   ------   ldloc x
        //                  ldc.i4 5
        //                  add

        //START MATH
        public override void OutAPlusExpr(APlusExpr node)
        {
            _output.WriteLine("\tadd");
        }

        public override void OutASubtractExpr(ASubtractExpr node)
        {
            _output.WriteLine("\tsub");
        }

        public override void OutADivideExpr2(ADivideExpr2 node)
        {
            _output.WriteLine("\tdiv");
        }

        public override void OutAMultExpr2(AMultExpr2 node)
        {
            _output.WriteLine("\tmul");
        }
        //END MATH

        public override void CaseAFunctionDeclarations(AFunctionDeclarations node)
        {
            InAFunctionDeclarations(node);
            if (node.GetVarname() != null)
            {
                node.GetVarname().Apply(this);
            }
            if (node.GetLparen() != null)
            {
                node.GetLparen().Apply(this);
            }
            if (node.GetParameters() != null)
            {
                node.GetParameters().Apply(this);
            }
            if (node.GetRparen() != null)
            {
                node.GetRparen().Apply(this);
            }
            
            _output.WriteLine(".method static void " + node.GetVarname().Text + "() cil managed");
            _output.WriteLine("{");
            if (node.GetLb() != null)
            {
                node.GetLb().Apply(this);
            }
            if (node.GetStmts() != null)
            {
                node.GetStmts().Apply(this);
            }
            if (node.GetRb() != null)
            {
                node.GetRb().Apply(this);
            }
            _output.WriteLine("\tret");
            _output.WriteLine("}");
            OutAFunctionDeclarations(node);
        }

        public override void CaseALogicwhile(ALogicwhile node)
        {
            InALogicwhile(node);
            if (node.GetWhile() != null)
            {
                node.GetWhile().Apply(this);
            }
            if (node.GetLparen() != null)
            {
                node.GetLparen().Apply(this);
            }
            if (node.GetBoolexp() != null)
            {
                node.GetBoolexp().Apply(this);
            }
            if (node.GetRparen() != null)
            {
                node.GetRparen().Apply(this);
            }
            _output.WriteLine("L" + Globals.counter + ":");
            _output.WriteLine("\tldc.i4 1");
            _output.WriteLine("L" + Globals.ifCode + ":");
            _output.WriteLine("\tldc.i4 1");
            _output.WriteLine("\tbeq L" + Globals.elseCode);
            if (node.GetLb() != null)
            {
                node.GetLb().Apply(this);
            }
            if (node.GetStmts() != null)
            {
                node.GetStmts().Apply(this);
            }
            if (node.GetRb() != null)
            {
                node.GetRb().Apply(this);
            }
            _output.WriteLine("\tbr" + " L" + Globals.ifCode);
            _output.WriteLine("L" + Globals.elseCode + ":");
            Globals.counter += 3;
            OutALogicwhile(node);
        }

        public override void CaseALogicif(ALogicif node)
        {
            InALogicif(node);
            if (node.GetIf() != null)
            {
                node.GetIf().Apply(this);
            }
            if (node.GetLparen() != null)
            {
                node.GetLparen().Apply(this);
            }
            if (node.GetBoolexp() != null)
            {
                node.GetBoolexp().Apply(this);
            }
            if (node.GetRparen() != null)
            {
                node.GetRparen().Apply(this);
            }

            _output.WriteLine("L" + Globals.counter + ":");
            _output.WriteLine("\tldc.i4 1");
            _output.WriteLine("L" + Globals.ifCode + ":");
            _output.WriteLine("\tldc.i4 0");
            _output.WriteLine("\tbeq L" + Globals.elseCode); 
            if (node.GetLb() != null)
            {
                node.GetLb().Apply(this);
            }
            if (node.GetStmts() != null)
            {
                node.GetStmts().Apply(this);
            }
            if (node.GetRb() != null)
            {
                node.GetRb().Apply(this);
            }

            _output.WriteLine("\tbr L" + Globals.contCode);
            _output.WriteLine("L" + Globals.elseCode + ":");
            if (node.GetLogicelse() != null)
            {
                node.GetLogicelse().Apply(this);
            }
            _output.WriteLine("L" + Globals.contCode + ":");
            Globals.counter += 3;
            OutALogicif(node);
        }

        //Logic
        public virtual void OutAEqualCompexpr(AEqualCompexpr node)
        {
            Globals.counter += 1;
            Globals.ifCode = Globals.counter + 1;
            Globals.elseCode = Globals.ifCode + 1;
            Globals.contCode = Globals.elseCode + 1;
            _output.WriteLine("\tbeq " + "L" + Globals.counter);
            _output.WriteLine("\tldc.i4 0");
            _output.WriteLine("\tbr " + "L" + Globals.ifCode);
        }

        public override void CaseAEqualCompexpr(AEqualCompexpr node)
        {
            InAEqualCompexpr(node);
            if (node.GetLhs() != null)
            {
                node.GetLhs().Apply(this);
            }
            if (node.GetEquals() != null)
            {
                node.GetEquals().Apply(this);
            }
            if (node.GetRhs() != null)
            {
                node.GetRhs().Apply(this);
            }
            OutAEqualCompexpr(node);
        }

        public virtual void OutALessthanCompexpr(ALessthanCompexpr node)
        {
            Globals.counter += 1;
            Globals.ifCode = Globals.counter + 1;
            Globals.elseCode = Globals.ifCode + 1;
            Globals.contCode = Globals.elseCode + 1;
            _output.WriteLine("\tbgt " + "L" + Globals.counter);
            _output.WriteLine("\tldc.i4 0");
            _output.WriteLine("\tbr " + "L" + Globals.ifCode);

        }

        public override void CaseALessthanCompexpr(ALessthanCompexpr node)
        {
            InALessthanCompexpr(node);
            if (node.GetRhs() != null)
            {
                node.GetRhs().Apply(this);
            }
            if (node.GetLt() != null)
            {
                node.GetLt().Apply(this);
            }
            if (node.GetLhs() != null)
            {
                node.GetLhs().Apply(this);
            }
            OutALessthanCompexpr(node);
            
        }

        public virtual void OutALessthaneCompexpr(ALessthaneCompexpr node)
        {
            Globals.counter += 1;
            Globals.ifCode = Globals.counter + 1;
            Globals.elseCode = Globals.ifCode + 1;
            Globals.contCode = Globals.elseCode + 1;
            _output.WriteLine("\tbge " + "L" + Globals.counter);
            _output.WriteLine("\tldc.i4 0");
            _output.WriteLine("\tbr " + "L" + Globals.ifCode);
        }

        public override void CaseALessthaneCompexpr(ALessthaneCompexpr node)
        {
            InALessthaneCompexpr(node);
            if (node.GetRhs() != null)
            {
                node.GetRhs().Apply(this);
            }
            if (node.GetLte() != null)
            {
                node.GetLte().Apply(this);
            }
            if (node.GetLhs() != null)
            {
                node.GetLhs().Apply(this);
            }
            OutALessthaneCompexpr(node);
        }

        public virtual void OutAGreatthanCompexpr(AGreatthanCompexpr node)
        {
            Globals.counter += 1;
            Globals.ifCode = Globals.counter + 1;
            Globals.elseCode = Globals.ifCode + 1;
            Globals.contCode = Globals.elseCode + 1;
            _output.WriteLine("\tblt " + "L" + Globals.counter);
            _output.WriteLine("\tldc.i4 0");
            _output.WriteLine("\tbr " + "L" + Globals.ifCode);
        }

        public override void CaseAGreatthanCompexpr(AGreatthanCompexpr node)
        {
            InAGreatthanCompexpr(node);
            if (node.GetRhs() != null)
            {
                node.GetRhs().Apply(this);
            }
            if (node.GetGt() != null)
            {
                node.GetGt().Apply(this);
            }
            if (node.GetLhs() != null)
            {
                node.GetLhs().Apply(this);
            }
            OutAGreatthanCompexpr(node);
        }

        public virtual void OutAGreatthaneCompexpr(AGreatthaneCompexpr node)
        {
            Globals.counter += 1;
            Globals.ifCode = Globals.counter + 1;
            Globals.elseCode = Globals.ifCode + 1;
            Globals.contCode = Globals.elseCode + 1;
            _output.WriteLine("\tble " + "L" + Globals.counter);
            _output.WriteLine("\tldc.i4 0");
            _output.WriteLine("\tbr " + "L" + Globals.ifCode);
        }

        public override void CaseAGreatthaneCompexpr(AGreatthaneCompexpr node)
        {
            InAGreatthaneCompexpr(node);
            if (node.GetRhs() != null)
            {
                node.GetRhs().Apply(this);
            }
            if (node.GetGte() != null)
            {
                node.GetGte().Apply(this);
            }
            if (node.GetLhs() != null)
            {
                node.GetLhs().Apply(this);
            }
            OutAGreatthaneCompexpr(node);
        }        

    }
}
