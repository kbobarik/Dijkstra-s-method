using DijkstraAlgorithm;
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

            DijkstraSolver dijkstraSolver = new DijkstraSolver("input.txt");
            dijkstraSolver.Run();

            
            Console.ReadKey();
        }
    }
}
