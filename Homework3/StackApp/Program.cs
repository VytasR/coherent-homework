using StackApp.StackItems;
using System;
//using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IStack<int> intStack1 = new Stack<int>(10);
            Console.WriteLine($"Integer stack is empty: {intStack1.IsEmpty()}");
            intStack1.Push(1);
            intStack1.Push(2);
            intStack1.Push(3);
            intStack1.Push(4);
            intStack1.Push(5);
            intStack1.Push(6);
            Console.WriteLine($"Integer stack is empty: {intStack1.IsEmpty()}");
            Console.WriteLine();
            Console.WriteLine("Integer stack items:");            
            while (!intStack1.IsEmpty())
            {
                Console.WriteLine(intStack1.Pop());
            }

            var floatStack1 = new Stack<float>();
            floatStack1.Push(25.6f);
            floatStack1.Push(11.58f);
            floatStack1.Push(0.689f);
            floatStack1.Push(-48.654f);            
            var reverseFloatStack1 = Helper.Reverse<float>(floatStack1);
            Console.WriteLine();
            Console.WriteLine("Reverse float stack items:");
            while (!reverseFloatStack1.IsEmpty())
            {
                Console.WriteLine(reverseFloatStack1.Pop());
            }            
        }
    }
}
