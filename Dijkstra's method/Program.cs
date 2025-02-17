using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijkstra_s_method
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
            MethodsClass obj = new MethodsClass("graph.txt");
            obj.Dijkstra();

            
            Console.ReadKey();
        }
    }
}
