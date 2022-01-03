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
            IStack<int> intStack1 = new Stack<int>();
            Console.WriteLine($"The stack is empty: {intStack1.IsEmpty()}");
            intStack1.Push(1);
            intStack1.Push(2);
            intStack1.Push(3);
            intStack1.Push(4);
            intStack1.Push(5);
            intStack1.Push(6);
            Console.WriteLine($"The stack is empty: {intStack1.IsEmpty()}");
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
            Console.WriteLine();
            Console.WriteLine("Float stack items:");
            while (!floatStack1.IsEmpty())
            {
                Console.WriteLine(floatStack1.Pop());
            }
        }
    }
}
