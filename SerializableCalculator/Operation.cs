using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializableCalculator
{
        [Serializable]
        public class Operation
        {
                private string calculation;
                private string result;
                


                public string Calculation
                {
                        get { return calculation; }
                        set { calculation = value; }
                }
                

                public string Result
                {
                        get { return result; }
                        set { result = value; }
                }

                public Operation()
                {

                }
              
                public Operation(string operation, string result)
                {
                        calculation = operation;
                        this.result = result;
                }
                        


                public override string ToString()
                {
                        return Calculation + "=" + Result;
                }
        }
}
