using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace test
{
    public class TestParent
    {
        public static void Main1(string[] args)
        {
            string str = "Hellow World";
            var c = str[1];

            //str[2] = c;     //Property or indexer 'string.this[int]' 
                            //cannot be assigned to -- it is read only
            Console.WriteLine(c);

            
        }
    }
}