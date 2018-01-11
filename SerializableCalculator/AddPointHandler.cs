using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializableCalculator
{
        class AddPointHandler
        {
                public bool AllowAddPoint(string input)
                {
                        if (input == "") return false;
                        if (!ContainsOperationSymbol(input) && (!ContainsPoint(input))) return true;
                        

                        char[] inputcheck = input.ToCharArray();
                        int countpoints = 0;
                        int operationsymbolindex = OperationSymbolIndex(input);

                        for (int i = operationsymbolindex;i < inputcheck.Length;i++)
                        {
                                if (IsPoint(inputcheck[i])) return false;

                        }

                        for (int i = 0;i < inputcheck.Length;i++)
                        {
                                if (countpoints > 2) return false;
                                if (IsPoint(inputcheck[i])) countpoints++;
                                
                        }

                        return true;
                }

                private int OperationSymbolIndex(string input)
                {
                        int operationsymbolindex = 0;
                        char[] inputchar = input.ToCharArray();

                        for (int i = 0; i < inputchar.Length;i++)
                        {
                                if (IsOperationSymbol(inputchar[i]))
                                {
                                        operationsymbolindex = i;
                                        break;
                                }
                        }

                        return operationsymbolindex;
                }

                private bool IsPoint(char a)
                {
                        return a == ',';
                }

                private bool ContainsOperationSymbol(string input)
                {
                        return (input.Contains('+') || (input.Contains('-') || 
                                (input.Contains('*')) || input.Contains('/')));
                }

                private bool ContainsPoint(string input)
                {
                        return input.Contains(',');
                }
                             
                private bool IsOperationSymbol(char a)
                {
                        return ((a == '+') || ((a == '-') || (a == '*') || (a == '/')));
                }
        }
}
