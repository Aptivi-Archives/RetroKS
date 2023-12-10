//
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
// but WITHOUT ANY WARRANTY, without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <https://www.gnu.org/licenses/>.
//

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace RetroKS
{
    static class stdCalc
    {

        public static void expressionCalculate(params string[] exps)
        {

            try
            {
                if (exps.Count() >= 3)
                {
                    var expressions = new List<string>();
                    var ops = new List<string>();
                    string finalExp = "";
                    int numOps = 0;
                    for (int i = 0, loopTo = exps.Count() - 1; i <= loopTo; i += 2)
                        expressions.Add(exps[i]);
                    for (int i = 1, loopTo1 = exps.Count() - 1; i <= loopTo1; i += 2)
                        ops.Add(exps[i]);
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
                    TextWriterColor.Wln("{0}= {1}", "neutralText", finalExp, finalRes);
                }
                else
                {
                    TextWriterColor.Wln("Usage: calc <expression1> <+|-|*|/|%> <expression2> ...", "neutralText");
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