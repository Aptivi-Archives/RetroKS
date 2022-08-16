using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace RetroKS
{

    // RetroKS  Copyright (C) 2022  Aptivi
    // 
    // This file is part of RetroKS
    // 
    // RetroKS is free software: you can redistribute it and/or modify
    // it under the terms of the GNU General Public License as published by
    // the Free Software Foundation, either version 3 of the License, or
    // (at your option) any later version.
    // 
    // RetroKS is distributed in the hope that it will be useful,
    // but WITHOUT ANY WARRANTY; without even the implied warranty of
    // MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    // GNU General Public License for more details.
    // 
    // You should have received a copy of the GNU General Public License
    // along with this program.  If not, see <https://www.gnu.org/licenses/>.

    static class sciCalc
    {

        public static void expressionCalculate(bool sciMode, params object[] exps)
        {

            try
            {
                if (sciMode == false)
                {
                    if (exps.Count() >= 3)
                    {
                        var expressions = new List<string>();
                        var ops = new List<string>();
                        string finalExp = "";
                        int numOps = 0;
                        for (int i = 0, loopTo = exps.Count() - 1; i <= loopTo; i += 2)
                        {
                            if ((string)exps[i] == "pi")
                            {
                                expressions.Add(Math.PI.ToString());
                            }
                            else if ((string)exps[i] == "e")
                            {
                                expressions.Add(Math.E.ToString());
                            }
                            else
                            {
                                expressions.Add(Convert.ToString(exps[i]));
                            }
                        }
                        for (int i = 1, loopTo1 = exps.Count() - 1; i <= loopTo1; i += 2)
                            ops.Add(Convert.ToString(exps[i]));
                        for (int i = 0, loopTo2 = expressions.Count - 1; i <= loopTo2; i++)
                        {
                            finalExp = finalExp + expressions[i] + " ";
                            if (i != expressions.Count - 1)
                            {
                                finalExp = finalExp + ops[numOps] + " ";
                                numOps += 1;
                            }
                        }
                        var finalRes = new DataTable().Compute(finalExp, null);
                        TextWriterColor.Wln("{0}= {1}", "neutralText", finalExp, finalRes, 2);
                    }
                    else
                    {
                        TextWriterColor.Wln("Usage: scical <expression1|pi|e> <+|-|*|/|%> <expression2|pi|e> ..." + Kernel.NewLine + 
                                            "       scical <sqrt|tan|sin|cos> <number>", "neutralText");
                    }
                }
                else if (exps.Count() == 2)
                {
                    object finalRes;
                    if ((string)exps[0] == "sqrt")
                    {
                        finalRes = Math.Sqrt(Convert.ToDouble(exps[1]));
                    }
                    else if ((string)exps[0] == "tan")
                    {
                        finalRes = Math.Tan(Convert.ToDouble(exps[1]));
                    }
                    else if ((string)exps[0] == "sin")
                    {
                        finalRes = Math.Sin(Convert.ToDouble(exps[1]));
                    }
                    else if ((string)exps[0] == "cos")
                    {
                        finalRes = Math.Cos(Convert.ToDouble(exps[1]));
                    }
                    else
                    {
                        TextWriterColor.Wln("Usage: scical <expression1|pi|e> <+|-|*|/|%> <expression2|pi|e> ..." + Kernel.NewLine + "       scical <sqrt|tan|sin|cos> <number>", "neutralText");
                        return;
                    }
                    TextWriterColor.Wln("{0} of {1} = {2}", "neutralText", exps[0], exps[1], finalRes);
                }
                else
                {
                    TextWriterColor.Wln("Usage: scical <expression1|pi|e> <+|-|*|/|%> <expression2|pi|e> ..." + Kernel.NewLine + "       scical <sqrt|tan|sin|cos> <number>", "neutralText");
                }
            }
            catch (DivideByZeroException ex)
            {
                TextWriterColor.Wln("Attempt to divide by zero is not allowed.", "neutralText");
                if (Flags.DebugMode == true)
                {
                    TextWriterColor.Wln(ex.StackTrace, "neutralText");
                    DebugWriter.Wdbg(ex.StackTrace, true);
                }
            }
            catch (Exception ex)
            {
                TextWriterColor.Wln("There is an error while calculating: {0}", "neutralText", ex.Message);
                if (Flags.DebugMode == true)
                {
                    TextWriterColor.Wln(ex.StackTrace, "neutralText");
                    DebugWriter.Wdbg(ex.StackTrace, true);
                }
            }

        }

    }
}